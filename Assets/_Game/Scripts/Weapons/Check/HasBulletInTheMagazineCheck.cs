
public class HasBulletInTheMagazineCheck : ICheck
{
    WeaponBase weaponBase;
    public HasBulletInTheMagazineCheck(WeaponBase weapon) => weaponBase = weapon;
    public bool Check() => weaponBase._AmmoRP.Value.BulletCountInMagazineRP.Value > 0;
}