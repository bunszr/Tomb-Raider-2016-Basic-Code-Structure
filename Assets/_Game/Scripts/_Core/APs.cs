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

    public static readonly int DrawHand = Animator.StringToHash("DrawHand");
    public static readonly int DrawPistol = Animator.StringToHash("DrawPistol");
    public static readonly int DrawSMG = Animator.StringToHash("DrawSMG");
    public static readonly int DrawRiffle = Animator.StringToHash("DrawRiffle");
}