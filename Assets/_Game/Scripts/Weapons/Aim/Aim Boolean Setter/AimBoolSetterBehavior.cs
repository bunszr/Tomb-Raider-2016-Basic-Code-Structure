using System;
using UniRx;
using UnityEngine;

public class AimBoolSetterBehavior : IEquiptable
{
    WeaponBase weaponBase;
    IAimIsTaken _aimIsTaken;

    IDisposable _disposable;
    float nextTime;
    bool firstEnter;
    bool isPressed;

    public AimBoolSetterBehavior(WeaponBase weaponBase)
    {
        this.weaponBase = weaponBase;

        _aimIsTaken = weaponBase as IAimIsTaken;
    }

    public virtual void Enter()
    {
        firstEnter = true;
        nextTime = 0f;
        UpdateManager.Ins.RegisterAsUpdate(weaponBase, OnUpdate);
    }

    public virtual void Exit()
    {
        _disposable?.Dispose();
        UpdateManager.Ins.UnregisterAsUpdate(weaponBase, OnUpdate);
    }

    public void OnUpdate()
    {
        if (IM.Ins.Input.WeaponInput.HasHoldingAimKey && firstEnter) PressedMethod();
        else if (IM.Ins.Input.WeaponInput.HasPressedAimKey) PressedMethod();
        else if (IM.Ins.Input.WeaponInput.HasReleasedAimKey) ReleasedMethod();

        if (isPressed && nextTime != 0 && Time.time > nextTime && !_aimIsTaken.HasAimed.Value) _aimIsTaken.HasAimed.Value = true;

        firstEnter = false;
    }

    void PressedMethod()
    {
        if (firstEnter && IM.Ins.Input.WeaponInput.HasHoldingAimKey) _aimIsTaken.HasAimed.Value = true;
        else
        {
            _disposable = MessageBroker.Default.Receive<OnAnimationStateEnterEvent>().Where(x => x.stateInfoEnum == StateInfoEnum.HasAimed).Subscribe(OnAnimEnter);
            nextTime = 0f;
        }
        isPressed = true;
    }

    void OnAnimEnter(OnAnimationStateEnterEvent onAnimationStateEnterEvent) => nextTime = Time.time + onAnimationStateEnterEvent.stateInfo.length;
    void ReleasedMethod()
    {
        isPressed = false;
        _aimIsTaken.HasAimed.Value = false;
        _disposable?.Dispose();
    }
}