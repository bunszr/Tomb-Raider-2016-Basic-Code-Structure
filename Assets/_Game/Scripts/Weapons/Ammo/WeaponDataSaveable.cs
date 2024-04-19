using Sirenix.OdinInspector;
using UnityEngine;

[System.Serializable]
public class WeaponDataSaveable
{
    [PropertyRange(0f, "MaxDamage")] public int damage;
    [PropertyRange(0f, "MaxRecoilStability")] public int recoilStability;
    [PropertyRange(0f, "MaxReloadSpeed")] public int reloadSpeed;
    [PropertyRange(0f, "MaxAmmoCapacity")] public int ammoCapacity;
    [PropertyRange(0f, "MaxRateOfFire")] public int rateOfFire;

    public int MaxDamage { get { return GameDataScriptable.Ins.weaponScriptableData.maxWeaponDataSaveable.damage; } }
    public int MaxRecoilStability { get { return GameDataScriptable.Ins.weaponScriptableData.maxWeaponDataSaveable.recoilStability; } }
    public int MaxReloadSpeed { get { return GameDataScriptable.Ins.weaponScriptableData.maxWeaponDataSaveable.reloadSpeed; } }
    public int MaxAmmoCapacity { get { return GameDataScriptable.Ins.weaponScriptableData.maxWeaponDataSaveable.ammoCapacity; } }
    public int MaxRateOfFire { get { return GameDataScriptable.Ins.weaponScriptableData.maxWeaponDataSaveable.rateOfFire; } }


    public WeaponDataSaveable(int damage, int recoilStability, int reloadSpeed, int ammoCapacity, int rateOfFire)
    {
        this.damage = damage;
        this.recoilStability = recoilStability;
        this.reloadSpeed = reloadSpeed;
        this.ammoCapacity = ammoCapacity;
        this.rateOfFire = rateOfFire;
    }

    public static implicit operator WeaponDataSaveable(WeaponData weaponData)
    {
        return new WeaponDataSaveable(weaponData.DamageRP.Value, weaponData.RecoilStabilityRP.Value, weaponData.ReloadSpeedRP.Value, weaponData.AmmoCapacityRP.Value, weaponData.RateOfFireRP.Value);
    }
}