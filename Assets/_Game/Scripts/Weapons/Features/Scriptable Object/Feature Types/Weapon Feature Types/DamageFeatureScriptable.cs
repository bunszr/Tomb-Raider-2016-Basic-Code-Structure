using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu(fileName = "DamageFeatureScriptable", menuName = "Third-Person-Shooter/Feature Type/DamageFeatureScriptable", order = 0)]
public class DamageFeatureScriptable : WeaponFeatureTypeScriptable, IAddableIntValue
{
    [SerializeField, PropertyRange(0, "MaxDamage")] int valueToAdd;

    public int MaxDamage => GameDataScriptable.Ins.weaponScriptableData.maxWeaponDataSaveable.damage;

    public int ValueToAdd => valueToAdd;
}