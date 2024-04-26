using UnityEngine;

public static class APs
{
    public static readonly int Steering = Animator.StringToHash("Steering");
    public static readonly int Run = Animator.StringToHash("Run");
    public static readonly int Idle = Animator.StringToHash("Idle");
    public static readonly int Happy = Animator.StringToHash("Happy");
    public static readonly int Attack = Animator.StringToHash("Attack");

    public static readonly int IsStrafing = Animator.StringToHash("IsStrafing");
    public static readonly int Mirror = Animator.StringToHash("Mirror");
    public static readonly int Falling = Animator.StringToHash("Falling");
    public static readonly int CloseWar = Animator.StringToHash("CloseWar");

    public static readonly int DrawWeaponTrigger = Animator.StringToHash("DrawWeaponTrigger");
    public static readonly int DrawWeaponInt = Animator.StringToHash("DrawWeaponInt");
    public static readonly int Shot = Animator.StringToHash("Shot");
    public static readonly int Aim = Animator.StringToHash("Aim");
}