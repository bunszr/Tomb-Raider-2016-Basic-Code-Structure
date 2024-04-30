using UnityEngine;

namespace TriggerableAreaNamespace
{
    public class DestroyFragmentWallCommand : IAreaCommad
    {
        Rigidbody[] fragmentsRb;
        int counter;

        public DestroyFragmentWallCommand(Rigidbody[] fragmentsRb)
        {
            this.fragmentsRb = fragmentsRb;
        }

        public void Enter() => counter = fragmentsRb.Length - 1;
        public void Exit() { }

        public TaskStatusEnum OnUpdate()
        {
            GameObject.Destroy(fragmentsRb[counter].gameObject);
            counter--;
            return counter < 0 ? TaskStatusEnum.Success : TaskStatusEnum.Running;
        }
    }
}