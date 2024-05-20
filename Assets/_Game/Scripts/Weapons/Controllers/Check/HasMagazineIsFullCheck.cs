
public class HasMagazineIsFullCheck : ICheck
{
    WeaponBase weaponBase;
    public HasMagazineIsFullCheck(WeaponBase weapon) => weaponBase = weapon;
    public bool Check() => weaponBase._AmmoRP.Value.BulletCountInMagazineRP.Value == weaponBase._AmmoRP.Value.MagazineCapacityRP.Value;
}