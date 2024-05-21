using System;
using UniRx;
using UnityEngine;

public class EnemyAimBoolSetterBehavior : IEquiptable
{
    WeaponBase weaponBase;
    IAimIsTaken _aimIsTaken;
    IAnimator _animator;

    float nextTime;
    CompositeDisposable disposables;

    public EnemyAimBoolSetterBehavior(WeaponBase weaponBase)
    {
        this.weaponBase = weaponBase;
        _aimIsTaken = weaponBase as IAimIsTaken;
        _animator = weaponBase._Animator;
    }

    public virtual void Enter()
    {
        UpdateManager.Ins.RegisterAsUpdate(weaponBase, OnUpdate);
        disposables = new CompositeDisposable();

        _animator.AnimatorMessageBroker.Receive<OnAnimationStateEnterEvent>()
            .Where(x => x.stateInfoEnum == StateInfoEnum.HasAimed)
            .Subscribe(OnAnimEnter).AddTo(disposables);

        _animator.AnimatorMessageBroker.Receive<OnAnimationStateExitEvent>()
            .Where(x => x.stateInfoEnum == StateInfoEnum.HasAimed)
            .Subscribe(OnAnimExit).AddTo(disposables);

        nextTime = 0f;
    }

    public virtual void Exit()
    {
        _aimIsTaken.HasAimed.Value = false;
        UpdateManager.Ins.UnregisterAsUpdate(weaponBase, OnUpdate);
        disposables.Dispose();
    }

    public void OnUpdate()
    {
        if (nextTime != 0 && Time.time > nextTime && !_aimIsTaken.HasAimed.Value) _aimIsTaken.HasAimed.Value = true;
    }

    void OnAnimEnter(OnAnimationStateEnterEvent onAnimationStateEnterEvent)
    {
        nextTime = Time.time + onAnimationStateEnterEvent.stateInfo.length;
    }

    void OnAnimExit(OnAnimationStateExitEvent onAnimationStateExitEvent)
    {
        _aimIsTaken.HasAimed.Value = false;
        nextTime = 0f;
    }
}