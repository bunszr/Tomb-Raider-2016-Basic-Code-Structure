using UnityEngine;
using UniRx;

namespace Character
{
    public class ArmorDecreaser : HealthAndArmorChainBase
    {
        ReactiveProperty<float> armorRP;

        public ArmorDecreaser(ReactiveProperty<float> armorRP)
        {
            this.armorRP = armorRP;
        }

        public override void Execute(float damageValue)
        {
            float damageToBeTransferred = armorRP.Value - damageValue < 0 ? Mathf.Abs(armorRP.Value - damageValue) : 0;

            if (damageToBeTransferred == 0) armorRP.Value -= damageValue;
            else
            {
                armorRP.Value = Mathf.Clamp(armorRP.Value - damageValue, 0, float.MaxValue);
                next.Execute(damageToBeTransferred);
            }
        }
    }
}