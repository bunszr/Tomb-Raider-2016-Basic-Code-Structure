using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu(fileName = "RateOfFireFeatureScriptable", menuName = "Third-Person-Shooter/Feature Type/RateOfFireFeatureScriptable", order = 0)]
public class RateOfFireFeatureScriptable : WeaponFeatureTypeScriptable, IAddableIntValue
{
    [SerializeField, PropertyRange(0, "MaxRateOfFire")] int valueToAdd;

    public int MaxRateOfFire => GameDataScriptable.Ins.weaponScriptableData.maxWeaponDataSaveable.rateOfFire;

    public int ValueToAdd => valueToAdd;
}