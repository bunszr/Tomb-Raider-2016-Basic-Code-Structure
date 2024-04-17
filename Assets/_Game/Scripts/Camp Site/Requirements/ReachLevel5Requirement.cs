using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu(fileName = "ReachLevel5Requirement", menuName = "Third-Person-Shooter/Requirements/ReachLevel5Requirement", order = 0)]
public class ReachLevel5Requirement : RequirementsScriptableBase
{
    public override bool IsTrue()
    {
        return true;
    }
}