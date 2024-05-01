using System;
using UniRx;
using UnityEngine;

public class AimBoolSetterBehavior : IEquiptable
{
    WeaponBase weaponBase;
    IWeaponInput _weaponInput;
    IAimIsTaken _aimIsTaken;

    IDisposable _disposable;
    float nextTime;
    bool firstEnter;
    bool isPressed;

    public AimBoolSetterBehavior(WeaponBase weaponBase, IWeaponInput weaponInput)
    {
        this.weaponBase = weaponBase;
        _weaponInput = weaponInput;
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
        if (_weaponInput.HasHoldingAimKey && firstEnter) PressedMethod();
        else if (_weaponInput.HasPressedAimKey) PressedMethod();
        else if (_weaponInput.HasReleasedAimKey) ReleasedMethod();

        if (isPressed && nextTime != 0 && Time.time > nextTime && !_aimIsTaken.HasAimed.Value) _aimIsTaken.HasAimed.Value = true;

        firstEnter = false;
    }

    void PressedMethod()
    {
        if (firstEnter && _weaponInput.HasHoldingAimKey) _aimIsTaken.HasAimed.Value = true;
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