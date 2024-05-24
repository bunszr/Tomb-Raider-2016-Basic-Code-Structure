using System;
using UniRx;
using UnityEngine;

public class ReloadMagazineState : WeaponStateBase
{
    IDisposable _disposable;
    IAnimator _animator;
    float nextTime;

    public ReloadMagazineState(WeaponBase weaponBase, bool needsExitTime, bool isGhostState = false) : base(weaponBase, needsExitTime, isGhostState)
    {
        this._animator = weaponBase._Animator;
    }

    public override void OnEnter()
    {
        nextTime = 0f;
        _disposable = _animator.AnimatorMessageBroker.Receive<OnAnimationStateEnterEvent>()
                        .Where(x => x.stateInfo.IsName(weaponBase.WeaponAnimationData.reloadMagazineName))
                        .Subscribe(OnReloadingEnter);

        _animator.Animator.CrossFade(weaponBase.WeaponAnimationData.reloadMagazineName, .1f);
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