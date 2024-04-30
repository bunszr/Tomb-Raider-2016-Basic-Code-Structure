using UnityEngine;

namespace TriggerableAreaNamespace
{
    public class BreakWallCommand : IAreaCommad
    {
        TriggeredPlayerReference triggeredPlayerReference;
        Rigidbody[] fragmentsRb;
        AnimationEventMono animationEventMono;
        int punchCount;
        IAreaInput _areaInput;
        int maxPunchCount;

        public BreakWallCommand(TriggeredPlayerReference triggeredPlayerReference, Rigidbody[] fragmentsRb, IAreaInput areaInput, int maxPunchCount)
        {
            this.triggeredPlayerReference = triggeredPlayerReference;
            this.fragmentsRb = fragmentsRb;
            _areaInput = areaInput;
            this.maxPunchCount = maxPunchCount;
        }

        public void Enter()
        {
            animationEventMono = triggeredPlayerReference.Player.gameObject.GetOrAddComponent<AnimationEventMono>();
            animationEventMono.onAnimationEvent += OnAnimationEvent;
        }

        public void Exit() => animationEventMono.onAnimationEvent -= OnAnimationEvent;

        public TaskStatusEnum OnUpdate()
        {
            if (_areaInput.HasPressedHitKey) triggeredPlayerReference.Player.Animator.SetTrigger(APs.Punch);
            return punchCount >= maxPunchCount ? TaskStatusEnum.Success : TaskStatusEnum.Running;
        }

        void OnAnimationEvent(string name)
        {
            if (name != "Punch") return;

            punchCount++;

            for (int i = 0; i < fragmentsRb.Length; i++)
            {
                float rot = 7;
                Vector3 randomVec = new Vector3(UnityEngine.Random.value * rot, UnityEngine.Random.value * rot, UnityEngine.Random.value * rot);
                fragmentsRb[i].transform.localRotation *= Quaternion.Euler(randomVec);
            }

            if (punchCount >= maxPunchCount)
            {
                for (int i = 0; i < fragmentsRb.Length; i++)
                {
                    fragmentsRb[i].isKinematic = false;
                    fragmentsRb[i].AddExplosionForce(2, triggeredPlayerReference.Player.transform.position + Vector3.up * 2, 3, 1, ForceMode.VelocityChange);
                }
                animationEventMono.onAnimationEvent -= OnAnimationEvent;
            }
        }
    }
}