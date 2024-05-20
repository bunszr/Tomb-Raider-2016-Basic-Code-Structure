using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu(fileName = "AmmoCapacityFeatureScriptable", menuName = "Third-Person-Shooter/Feature Type/AmmoCapacityFeatureScriptable", order = 0)]
public class AmmoCapacityFeatureScriptable : WeaponFeatureTypeScriptable, IAddableIntValue
{
    [SerializeField, PropertyRange(0, "MaxAmmoCapacity")] int valueToAdd;

    public int MaxAmmoCapacity => GameDataScriptable.Ins.weaponScriptableData.maxWeaponDataSaveable.ammoCapacity;

    public int ValueToAdd => valueToAdd;
}