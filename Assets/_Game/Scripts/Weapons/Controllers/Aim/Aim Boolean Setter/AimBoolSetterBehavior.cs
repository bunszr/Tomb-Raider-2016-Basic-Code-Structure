using System;
using UniRx;
using UnityEngine;

public class AimBoolSetterBehavior : IEquiptable
{
    WeaponBase weaponBase;
    IAimIsTaken _aimIsTaken;
    float nextTime;
    bool aimAnimIsPlaying;
    IAnimator _animator;
    CompositeDisposable disposables = new CompositeDisposable();

    public AimBoolSetterBehavior(WeaponBase weaponBase)
    {
        this.weaponBase = weaponBase;
        _aimIsTaken = weaponBase as IAimIsTaken;
        _animator = weaponBase._Animator;
    }

    public virtual void Enter()
    {
        UpdateManager.Ins.RegisterAsUpdate(weaponBase, OnUpdate);

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
        disposables.Clear();
    }

    public void OnUpdate()
    {
        if (IM.Ins.Input.WeaponInput.HasPressedAimKey) PressedMethod();
        else if (IM.Ins.Input.WeaponInput.HasReleasedAimKey) ReleasedMethod();

        if (aimAnimIsPlaying && nextTime != 0 && Time.time > nextTime && !_aimIsTaken.HasAimed.Value) _aimIsTaken.HasAimed.Value = true;
    }

    void PressedMethod()
    {
        nextTime = 0f;
    }

    void ReleasedMethod()
    {
        _aimIsTaken.HasAimed.Value = false;
    }

    void OnAnimEnter(OnAnimationStateEnterEvent onAnimationStateEnterEvent)
    {
        aimAnimIsPlaying = true;
        nextTime = Time.time + onAnimationStateEnterEvent.stateInfo.length;
    }

    void OnAnimExit(OnAnimationStateExitEvent onAnimationStateExitEvent)
    {
        _aimIsTaken.HasAimed.Value = false;
        aimAnimIsPlaying = false;
    }
}
