
public class HasBulletInTheMagazineCheck : ICheck
{
    IWeapon _weapon;
    public HasBulletInTheMagazineCheck(IWeapon weapon) => _weapon = weapon;
    public bool Check() => _weapon._AmmoRP.Value.BulletCountInMagazineRP.Value > 0;
}