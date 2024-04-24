
public class HasMagazineIsFullCheck : ICheck
{
    IWeapon _weapon;
    public HasMagazineIsFullCheck(IWeapon weapon) => _weapon = weapon;
    public bool Check() => _weapon._AmmoRP.Value.BulletCountInMagazineRP.Value == _weapon._AmmoRP.Value.MagazineCapacityRP.Value;
}