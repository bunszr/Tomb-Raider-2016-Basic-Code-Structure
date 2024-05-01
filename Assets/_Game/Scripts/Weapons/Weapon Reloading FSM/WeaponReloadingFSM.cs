using FSM;
using UniRx;
using UnityEngine;
using Zenject;

public class WeaponReloadingFSM : MonoBehaviour
{
    CompositeDisposable disposables = new CompositeDisposable();

    [Inject] IInput _input;

    StateMachine fsm;
    [SerializeField] WeaponBase weaponBase;
    [SerializeField] PlayerWeaponBaseInstaller playerWeaponBaseInstaller;
    [SerializeField] Animator animator;

    WeaponCheckFactory factory;

    [SerializeField] StateMachine.StateMachineDebug stateMachineDebug;

    private void Awake()
    {
        fsm = new StateMachine() { stateMachineDebug = stateMachineDebug };

        factory = new WeaponCheckFactory(weaponBase);

        fsm.AddState("EmptyState", new State());
        fsm.AddState("ReloadMagazineState", new ReloadMagazineState(weaponBase, animator, true));
        fsm.AddState("FillMagazineState", new FillMagazineState(weaponBase, false, true));
        fsm.AddState("EmptyShotState", new EmptyShotState(weaponBase, _input.WeaponInput, true, true));

        fsm.AddTriggerTransition("OnMagazineEmpty", new Transition("EmptyState", "ReloadMagazineState"));
        fsm.AddTriggerTransition("OnMagazineAndAmmoIsEmpty", new Transition("EmptyState", "EmptyShotState"));
        fsm.AddTransition(new Transition("EmptyState", "ReloadMagazineState", x => _input.WeaponInput.HasPressedReloadKey && factory.Check(WeaponCheckType.HasAmmoCheck) && !factory.Check(WeaponCheckType.HasMagazineIsFullCheck)));
        fsm.AddTransition(new Transition("ReloadMagazineState", "FillMagazineState"));
        fsm.AddTransition(new Transition("FillMagazineState", "EmptyState"));

        // Interruption due to toggling weapon
        fsm.AddTriggerTransitionFromAny("OnUnEquip", new Transition("", "EmptyState", null, true));

        fsm.SetStartState("EmptyState");
        fsm.Init();

        playerWeaponBaseInstaller.onEquip += OnEquip; // It must be call in Awake
        playerWeaponBaseInstaller.onUnEquip += OnUnEquip; // It must be call in Awake
    }

    private void Update() => fsm.OnLogic();

    void OnEquip(IWeapon _weapon)
    {
        weaponBase._AmmoRP.Value.BulletCountInMagazineRP.Where(x => x == 0).Subscribe(OnBulletCountZero).AddTo(disposables);
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