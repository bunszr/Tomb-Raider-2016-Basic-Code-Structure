using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

public class ShootActionEmpty : Action
{
    public override void OnStart()
    {
        base.OnStart();
    }

    public override TaskStatus OnUpdate()
    {
        Debug.Log("Empty Shoot");
        return TaskStatus.Success;
    }
}