using UnityEngine;
using UniRx;

namespace Character
{
    public class HealthAndArmorController : LivingEntityCollisionBase
    {
        ArmorDecreaser armorDecreaser;
        HealthDecreaser healthDecreaser;

        CompositeDisposable disposables = new CompositeDisposable();

        ReactiveProperty<float> healthRP;
        ReactiveProperty<float> armorRP;
        FeatureTypeScriptable armorFeature;

        HealthAndArmorChainBase baseChain;

        public HealthAndArmorController(CollisionCustom collisionCustom, ReactiveProperty<float> healthRP, ReactiveProperty<float> armorRP, FeatureTypeScriptable armorFeature) : base(collisionCustom)
        {
            this.healthRP = healthRP;
            this.armorRP = armorRP;
            this.armorFeature = armorFeature;

            armorDecreaser = new ArmorDecreaser(armorRP);
            healthDecreaser = new HealthDecreaser(healthRP);

            armorDecreaser.SetNext(healthDecreaser);

            armorFeature.IsOpenRP.Subscribe(OnArmorFeature).AddTo(disposables);
        }

        void ReassingChain()
        {
            if (armorFeature.IsOpenRP.Value) baseChain = armorDecreaser;
            else baseChain = healthDecreaser;
        }

        public void OnArmorFeature(bool isOpen) => ReassingChain();

        public override void OnCustomCollisionEnter(Collision other)
        {
            if (StaticColliderManager.IGiveDamageDictionary.TryGetValue(other.transform.GetInstanceID(), out IGiveDamage _giveDamage))
            {
                if (!_giveDamage.IsHitTo.Value)
                {
                    baseChain.Execute(_giveDamage.DamageValue);
                    _giveDamage.IsHitTo.Value = true;
                }
            }
        }

        public override void Deactivate()
        {
            base.Deactivate();
            disposables.Clear();
        }
    }
}