public class HasAmmoCheck : ICheck
{
    IWeapon _weapon;
    public HasAmmoCheck(IWeapon weapon) => _weapon = weapon;
    public bool Check() => _weapon._AmmoRP.Value.CurrAmmoCapacityRP.Value > 0;
}