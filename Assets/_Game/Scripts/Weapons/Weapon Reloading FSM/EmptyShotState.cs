using UnityEngine;

public class EmptyShotState : WeaponStateBase
{
    IWeaponInput _weaponInput;
    bool waitAFrame;

    public EmptyShotState(IWeapon _weapon, IWeaponInput _weaponInput, bool needsExitTime, bool isGhostState = false) : base(_weapon, needsExitTime, isGhostState)
    {
        this._weaponInput = _weaponInput;
    }

    public override void OnEnter() => waitAFrame = true;

    public override void OnLogic()
    {
        if (waitAFrame) { waitAFrame = false; return; }
        if (_weaponInput.HasPressedFireKey) Debug.Log("Empty Shot");
    }
}