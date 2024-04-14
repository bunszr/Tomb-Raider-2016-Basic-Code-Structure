[System.Serializable]
public class WeaponDataSaveable
{
    public float damage;
    public float recoilStability;
    public float reloadSpeed;
    public float ammoCapacity;
    public float rateOfFire;

    public WeaponDataSaveable(float damage, float recoilStability, float reloadSpeed, float ammoCapacity, float rateOfFire)
    {
        this.damage = damage;
        this.recoilStability = recoilStability;
        this.reloadSpeed = reloadSpeed;
        this.ammoCapacity = ammoCapacity;
        this.rateOfFire = rateOfFire;
    }

    public static implicit operator WeaponDataSaveable(WeaponData weaponData)
    {
        return new WeaponDataSaveable(weaponData.DamageRP.Value, weaponData.RecoilStabilityRP.Value, weaponData.ReloadSpeedRP.Value, weaponData.AmmoCapacityRB.Value, weaponData.RateOfFireRP.Value);
    }
}