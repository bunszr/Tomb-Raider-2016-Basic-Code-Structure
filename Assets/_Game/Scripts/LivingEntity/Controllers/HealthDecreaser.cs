using UnityEngine;
using UniRx;

namespace Character
{
    public class HealthDecreaser : HealthAndArmorChainBase
    {
        ReactiveProperty<float> healthRP;

        public HealthDecreaser(ReactiveProperty<float> healthRP)
        {
            this.healthRP = healthRP;
        }

        public override void Execute(float damageValue)
        {
            healthRP.Value = Mathf.Clamp(healthRP.Value - damageValue, 0, float.MaxValue);
        }
    }
}