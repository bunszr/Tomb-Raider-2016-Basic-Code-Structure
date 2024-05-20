using FSM;
using UniRx;
using UnityEngine;

public class WeaponReloadingEnemyFSM : IEquiptable
{
    StateMachine fsm;
    WeaponCheckFactory factory;
    CompositeDisposable disposables = new CompositeDisposable();

    WeaponBase weaponBase;

    [SerializeField] StateMachine.StateMachineDebug stateMachineDebug;

    public WeaponReloadingEnemyFSM(WeaponBase weaponBase)
    {
        this.weaponBase = weaponBase;

        fsm = new StateMachine() { stateMachineDebug = stateMachineDebug };

        Animator animator = weaponBase._ThirdPersonController.Animator;
        factory = new WeaponCheckFactory(weaponBase);

        fsm.AddState("EmptyState", new State());
        fsm.AddState("ReloadMagazineState", new ReloadMagazineState(weaponBase, animator, true));
        fsm.AddState("FillMagazineState", new FillMagazineState(weaponBase, false, true));

        fsm.AddTriggerTransition("OnMagazineEmpty", new Transition("EmptyState", "ReloadMagazineState"));
        fsm.AddTransition(new Transition("ReloadMagazineState", "FillMagazineState"));
        fsm.AddTransition(new Transition("FillMagazineState", "EmptyState"));

        // Interruption due to toggling weapon
        fsm.AddTriggerTransitionFromAny("OnUnEquip", new Transition("", "EmptyState", null, true));

        fsm.SetStartState("EmptyState");
        fsm.Init();
    }

    public void Enter()
    {
        weaponBase._AmmoRP.Value.BulletCountInMagazineRP.Where(x => x == 0).Subscribe(OnBulletCountZero).AddTo(disposables);
        UpdateManager.Ins.RegisterAsUpdate(weaponBase, fsm.OnLogic);
    }

    public void Exit()
    {
        disposables.Clear();
        fsm.TriggerLocally("OnUnEquip");
        UpdateManager.Ins.UnregisterAsUpdate(weaponBase, fsm.OnLogic);
    }

    void OnBulletCountZero(int count)
    {
        if (factory.Check(WeaponCheckType.HasAmmoCheck)) fsm.TriggerLocally("OnMagazineEmpty");
    }
}