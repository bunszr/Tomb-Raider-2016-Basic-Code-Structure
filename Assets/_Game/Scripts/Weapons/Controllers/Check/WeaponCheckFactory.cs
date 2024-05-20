
public class WeaponCheckFactory
{
    WeaponBase weaponBase;
    public WeaponCheckFactory(WeaponBase weapon) => weaponBase = weapon;

    ICheck _hasAmmoCheck;
    ICheck _hasMagazineIsFullCheck;
    ICheck _hasBulletInTheMagazineCheck;

    public bool Check(WeaponCheckType weaponCheckType)
    {
        switch (weaponCheckType)
        {
            case WeaponCheckType.HasMagazineIsFullCheck:
                if (_hasMagazineIsFullCheck == null) _hasMagazineIsFullCheck = new HasMagazineIsFullCheck(weaponBase);
                return _hasMagazineIsFullCheck.Check();
            case WeaponCheckType.HasAmmoCheck:
                if (_hasAmmoCheck == null) _hasAmmoCheck = new HasAmmoCheck(weaponBase);
                return _hasAmmoCheck.Check();
            case WeaponCheckType.HasBulletInTheMagazineCheck:
                if (_hasBulletInTheMagazineCheck == null) _hasBulletInTheMagazineCheck = new HasBulletInTheMagazineCheck(weaponBase);
                return _hasBulletInTheMagazineCheck.Check();
        }
        return false;
    }
}