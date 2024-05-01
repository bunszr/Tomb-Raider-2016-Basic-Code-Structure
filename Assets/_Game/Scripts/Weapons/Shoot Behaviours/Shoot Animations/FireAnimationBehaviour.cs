using UnityEngine;

public class FireAnimationBehaviour : IExtraFire
{
    Animator animator;
    public FireAnimationBehaviour(Animator animator) => this.animator = animator;
    public void Fire() => animator.SetTrigger(APs.Shot);
}