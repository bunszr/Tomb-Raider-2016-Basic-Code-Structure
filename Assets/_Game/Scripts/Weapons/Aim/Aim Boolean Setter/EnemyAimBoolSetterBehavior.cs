using UnityEngine;

public class EnemyAimBoolSetterBehavior : IEquiptable
{
    WeaponBase weaponBase;
    IAimIsTaken _aimIsTaken;

    float nextTime;
    float delay = 1;

    public EnemyAimBoolSetterBehavior(WeaponBase weaponBase)
    {
        this.weaponBase = weaponBase;
        _aimIsTaken = weaponBase as IAimIsTaken;
    }

    public virtual void Enter()
    {
        nextTime = Time.time + delay; // Fix Later - Subscribe SMB event, then calculate delay like area commands classes
        UpdateManager.Ins.RegisterAsUpdate(weaponBase, OnUpdate);
    }

    public virtual void Exit()
    {
        _aimIsTaken.HasAimed.Value = false;
        UpdateManager.Ins.UnregisterAsUpdate(weaponBase, OnUpdate);
    }

    public void OnUpdate()
    {
        if (Time.time > nextTime && !_aimIsTaken.HasAimed.Value) _aimIsTaken.HasAimed.Value = true;
    }
}