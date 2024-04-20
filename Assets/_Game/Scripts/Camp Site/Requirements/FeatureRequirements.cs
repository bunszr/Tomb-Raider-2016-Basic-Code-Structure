using UnityEngine;

[CreateAssetMenu(fileName = "FeatureRequirements", menuName = "Third-Person-Shooter/Requirements/FeatureRequirements", order = 0)]
public class FeatureRequirements : RequirementsScriptableBase
{
    public FeatureTypeScriptable[] requireFeatureTypeScriptables;

    public override bool IsTrue()
    {
        bool require = true;
        for (int i = 0; i < requireFeatureTypeScriptables.Length; i++)
        {
            if (requireFeatureTypeScriptables[i].IsOpenRP.Value == false) require = false;
        }
        return require;
    }
}