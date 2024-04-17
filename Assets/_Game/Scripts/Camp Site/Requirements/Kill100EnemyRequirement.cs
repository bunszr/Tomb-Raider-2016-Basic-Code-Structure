using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu(fileName = "Kill100EnemyRequirement", menuName = "Third-Person-Shooter/Requirements/Kill100EnemyRequirement", order = 0)]
public class Kill100EnemyRequirement : RequirementsScriptableBase
{
    public override bool IsTrue()
    {
        return true;
    }
}