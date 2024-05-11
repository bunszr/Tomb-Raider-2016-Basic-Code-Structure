using UnityEngine;

public class EmptyShotState : WeaponStateBase
{
    bool waitAFrame;

    public EmptyShotState(WeaponBase weaponBase, bool needsExitTime, bool isGhostState = false) : base(weaponBase, needsExitTime, isGhostState)
    {
    }

    public override void OnEnter() => waitAFrame = true;

    public override void OnLogic()
    {
        if (waitAFrame) { waitAFrame = false; return; }
        if (IM.Ins.Input.WeaponInput.HasPressedFireKey) Debug.Log("Empty Shot");
    }
}