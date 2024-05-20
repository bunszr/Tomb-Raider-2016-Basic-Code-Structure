using UnityEngine;

public class SkillFeatureTypeScriptable : FeatureTypeScriptable
{
    [SerializeField] int skillCostAmount = 1;
    public int SkillCostAmount => skillCostAmount;
}