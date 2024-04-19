using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu(fileName = "RecoilStabilityFeatureScriptable", menuName = "Third-Person-Shooter/Feature Type/RecoilStabilityFeatureScriptable", order = 0)]
public class RecoilStabilityFeatureScriptable : WeaponFeatureTypeScriptable, IAddableIntValue
{
    [SerializeField, PropertyRange(0, "MaxRecoilStability")] int valueToAdd;

    public int MaxRecoilStability => GameDataScriptable.Ins.weaponScriptableData.maxWeaponDataSaveable.recoilStability;

    public int ValueToAdd => valueToAdd;
}