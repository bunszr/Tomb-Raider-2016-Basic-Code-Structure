using Sirenix.OdinInspector;
using UniRx;

[System.Serializable]
public class WeaponData
{
    [ReadOnly, ShowInInspector] public ReactiveProperty<int> DamageRP { get; private set; }
    [ReadOnly, ShowInInspector] public ReactiveProperty<int> RecoilStabilityRP { get; private set; }
    [ReadOnly, ShowInInspector] public ReactiveProperty<int> ReloadSpeedRP { get; private set; }
    [ReadOnly, ShowInInspector] public ReactiveProperty<int> AmmoCapacityRP { get; private set; }
    [ReadOnly, ShowInInspector] public ReactiveProperty<int> RateOfFireRP { get; private set; }

    public WeaponData(WeaponDataSaveable weaponDataSaveable)
    {
        DamageRP = new ReactiveProperty<int>(weaponDataSaveable.damage);
        RecoilStabilityRP = new ReactiveProperty<int>(weaponDataSaveable.recoilStability);
        ReloadSpeedRP = new ReactiveProperty<int>(weaponDataSaveable.reloadSpeed);
        AmmoCapacityRP = new ReactiveProperty<int>(weaponDataSaveable.ammoCapacity);
        RateOfFireRP = new ReactiveProperty<int>(weaponDataSaveable.rateOfFire);
    }
}