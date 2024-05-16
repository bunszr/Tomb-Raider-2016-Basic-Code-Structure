using UnityEngine;
using UniRx;

namespace Character
{
    public class EnemyHealthController : LivingEntityCollisionBase
    {
        HealthDecreaser healthDecreaser;
        ReactiveProperty<float> healthRP;

        public EnemyHealthController(CollisionCustom collisionCustom, ReactiveProperty<float> healthRP) : base(collisionCustom)
        {
            healthDecreaser = new HealthDecreaser(healthRP);
            this.healthRP = healthRP;
        }

        public override void OnCustomCollisionEnter(Collision other)
        {
            if (StaticColliderManager.IGiveDamageDictionary.TryGetValue(other.transform.GetInstanceID(), out IGiveDamage _giveDamage))
            {
                if (!_giveDamage.IsHitTo.Value)
                {
                    healthDecreaser.Execute(_giveDamage.DamageValue);
                    _giveDamage.IsHitTo.Value = true;
                }
            }
        }
    }
}