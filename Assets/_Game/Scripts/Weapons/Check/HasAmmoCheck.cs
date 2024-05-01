public class HasAmmoCheck : ICheck
{
    WeaponBase weaponBase;
    public HasAmmoCheck(WeaponBase weapon) => weaponBase = weapon;
    public bool Check() => weaponBase._AmmoRP.Value.CurrAmmoCapacityRP.Value > 0;
}