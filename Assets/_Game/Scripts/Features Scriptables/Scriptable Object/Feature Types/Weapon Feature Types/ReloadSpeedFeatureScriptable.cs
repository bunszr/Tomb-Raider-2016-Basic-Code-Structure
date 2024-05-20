using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu(fileName = "ReloadSpeedFeatureSciptable", menuName = "Third-Person-Shooter/Feature Type/ReloadSpeedFeatureScriptable", order = 0)]
public class ReloadSpeedFeatureScriptable : WeaponFeatureTypeScriptable, IAddableIntValue
{
    [SerializeField, PropertyRange(0, "MaxReloadSpeed")] int valueToAdd;

    public int MaxReloadSpeed => GameDataScriptable.Ins.weaponScriptableData.maxWeaponDataSaveable.reloadSpeed;

    public int ValueToAdd => valueToAdd;
}