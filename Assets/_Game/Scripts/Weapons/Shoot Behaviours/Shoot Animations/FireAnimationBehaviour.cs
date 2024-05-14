using UnityEngine;

public class FireAnimationBehaviour : IExtraFire
{
    Animator animator;
    int hash;
    public FireAnimationBehaviour(Animator animator, string name)
    {
        this.animator = animator;
        this.hash = Animator.StringToHash(name);
    }

    public void Fire() => animator.CrossFade(hash, .05f);
}