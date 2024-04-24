using FSM;
using UniRx;
using UnityEngine;
using Zenject;

public class WeaponReloadingFSM : MonoBehaviour
{
    CompositeDisposable disposables = new CompositeDisposable();

    [Inject] IInput _input;

    StateMachine fsm;
    WeaponBase weaponBase;
    IWeapon _weapon;
    Animator animator;

    WeaponCheckFactory factory;

    [SerializeField] StateMachine.StateMachineDebug stateMachineDebug;

    private void Awake()
    {
        fsm = new StateMachine() { stateMachineDebug = stateMachineDebug };
        _weapon = transform.parent.GetComponentInChildren<IWeapon>();
        weaponBase = _weapon.Transform.GetComponent<WeaponBase>();
        animator = GetComponentInParent<LivingEntity>().Animator;

        factory = new WeaponCheckFactory(_weapon);

        fsm.AddState("EmptyState", new State());
        fsm.AddState("ReloadMagazineState", new ReloadMagazineState(_weapon, animator, true));
        fsm.AddState("FillMagazineState", new FillMagazineState(_weapon, false, true));
        fsm.AddState("EmptyShotState", new EmptyShotState(_weapon, _input.WeaponInput, true, true));

        fsm.AddTriggerTransition("OnMagazineEmpty", new Transition("EmptyState", "ReloadMagazineState"));
        fsm.AddTriggerTransition("OnMagazineAndAmmoIsEmpty", new Transition("EmptyState", "EmptyShotState"));
        fsm.AddTransition(new Transition("EmptyState", "ReloadMagazineState", x => _input.WeaponInput.HasPressedReloadKey && factory.Check(WeaponCheckType.HasAmmoCheck) && !factory.Check(WeaponCheckType.HasMagazineIsFullCheck)));
        fsm.AddTransition(new Transition("ReloadMagazineState", "FillMagazineState"));
        fsm.AddTransition(new Transition("FillMagazineState", "EmptyState"));

        // Interruption due to toggling weapon
        fsm.AddTriggerTransitionFromAny("OnUnEquip", new Transition("", "EmptyState", null, true));

        fsm.SetStartState("EmptyState");
        fsm.Init();

        weaponBase.onEquip += OnEquip;
        weaponBase.onUnEquip += OnUnEquip;
    }

    private void Update() => fsm.OnLogic();

    void OnEquip(IWeapon _weapon)
    {
        _weapon._AmmoRP.Value.BulletCountInMagazineRP.Where(x => x == 0).Subscribe(OnBulletCountZero).AddTo(disposables);
    }

    void OnUnEquip(IWeapon _weapon)
    {
        disposables.Clear();
        fsm.TriggerLocally("OnUnEquip");
    }

    void OnBulletCountZero(int count)
    {
        if (!factory.Check(WeaponCheckType.HasAmmoCheck)) fsm.TriggerLocally("OnMagazineAndAmmoIsEmpty");
        else fsm.TriggerLocally("OnMagazineEmpty");
    }
}