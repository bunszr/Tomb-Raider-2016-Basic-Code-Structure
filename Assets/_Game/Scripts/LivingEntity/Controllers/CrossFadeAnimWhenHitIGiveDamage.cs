using UnityEngine;

namespace Character
{
    public class CrossFadeAnimWhenHitIGiveDamage : LivingEntityCollisionBase
    {
        Animator animator;

        public CrossFadeAnimWhenHitIGiveDamage(CollisionCustom collisionCustom, Animator animator) : base(collisionCustom)
        {
            this.animator = animator;
        }

        public override void OnCustomCollisionEnter(Collision other)
        {
            if (StaticColliderManager.IGiveDamageDictionary.TryGetValue(other.transform.GetInstanceID(), out IGiveDamage _giveDamage) && !_giveDamage.IsHitTo.Value)
            {
                animator.CrossFade(APs.TakeDamageCF, .05f);
            }
        }
    }
}