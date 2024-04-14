using Sirenix.OdinInspector;
using UniRx;

[System.Serializable]
public class WeaponData
{
    [ReadOnly, ShowInInspector] public ReactiveProperty<float> DamageRP { get; private set; }
    [ReadOnly, ShowInInspector] public ReactiveProperty<float> RecoilStabilityRP { get; private set; }
    [ReadOnly, ShowInInspector] public ReactiveProperty<float> ReloadSpeedRP { get; private set; }
    [ReadOnly, ShowInInspector] public ReactiveProperty<float> AmmoCapacityRB { get; private set; }
    [ReadOnly, ShowInInspector] public ReactiveProperty<float> RateOfFireRP { get; private set; }

    public WeaponData(WeaponDataSaveable weaponDataSaveable)
    {
        DamageRP = new ReactiveProperty<float>(weaponDataSaveable.damage);
        RecoilStabilityRP = new ReactiveProperty<float>(weaponDataSaveable.recoilStability);
        ReloadSpeedRP = new ReactiveProperty<float>(weaponDataSaveable.reloadSpeed);
        AmmoCapacityRB = new ReactiveProperty<float>(weaponDataSaveable.ammoCapacity);
        RateOfFireRP = new ReactiveProperty<float>(weaponDataSaveable.rateOfFire);
    }
}