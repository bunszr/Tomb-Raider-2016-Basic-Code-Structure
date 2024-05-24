
public class HasMagazineIsFullCheck : ICheck
{
    WeaponBase weaponBase;
    public HasMagazineIsFullCheck(WeaponBase weapon) => weaponBase = weapon;
    public bool Check() => weaponBase._AmmoDataRP.Value.BulletCountInMagazineRP.Value == weaponBase._AmmoDataRP.Value.MagazineCapacityRP.Value;
}