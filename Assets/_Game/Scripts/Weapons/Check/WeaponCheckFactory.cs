
public class WeaponCheckFactory
{
    IWeapon _weapon;
    public WeaponCheckFactory(IWeapon weapon) => _weapon = weapon;

    ICheck _hasAmmoCheck;
    ICheck _hasMagazineIsFullCheck;
    ICheck _hasBulletInTheMagazineCheck;

    public bool Check(WeaponCheckType weaponCheckType)
    {
        switch (weaponCheckType)
        {
            case WeaponCheckType.HasMagazineIsFullCheck:
                if (_hasMagazineIsFullCheck == null) _hasMagazineIsFullCheck = new HasMagazineIsFullCheck(_weapon);
                return _hasMagazineIsFullCheck.Check();
            case WeaponCheckType.HasAmmoCheck:
                if (_hasAmmoCheck == null) _hasAmmoCheck = new HasAmmoCheck(_weapon);
                return _hasAmmoCheck.Check();
            case WeaponCheckType.HasBulletInTheMagazineCheck:
                if (_hasBulletInTheMagazineCheck == null) _hasBulletInTheMagazineCheck = new HasBulletInTheMagazineCheck(_weapon);
                return _hasBulletInTheMagazineCheck.Check();
        }
        return false;
    }
}

public enum WeaponCheckType
{
    HasMagazineIsFullCheck,
    HasAmmoCheck,
    HasBulletInTheMagazineCheck,
};