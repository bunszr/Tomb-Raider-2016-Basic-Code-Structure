using System;
using UniRx;
using UnityEngine;

public class ReloadMagazineState : WeaponStateBase
{
    IDisposable _disposable;
    Animator animator;
    float nextTime;

    public ReloadMagazineState(IWeapon _weapon, Animator animator, bool needsExitTime, bool isGhostState = false) : base(_weapon, needsExitTime, isGhostState)
    {
        this.animator = animator;
    }

    public override void OnEnter()
    {
        nextTime = 0f;
        _disposable = MessageBroker.Default.Receive<OnAnimationStateEnterEvent>()
                        .Where(x => x.stateInfo.IsName(weaponBase.weaponDataScriptable.weaponAnimationData.reloadMagazineName))
                        .Subscribe(OnReloadingEnter);

        animator.SetTrigger(weaponBase.weaponDataScriptable.weaponAnimationData.reloadMagazineTriggerName);
    }

    public void OnReloadingEnter(OnAnimationStateEnterEvent onReloadingEnterEvent)
    {
        nextTime = Time.time + onReloadingEnterEvent.stateInfo.length;
        _disposable.Dispose();
    }

    public override void OnExit()
    {
        _disposable?.Dispose();
    }

    public override void OnLogic()
    {
        if (nextTime != 0f && Time.time > nextTime) fsm.StateCanExit();
    }
}