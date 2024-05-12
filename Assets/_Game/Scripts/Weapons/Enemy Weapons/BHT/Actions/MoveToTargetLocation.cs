using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
using Dreamteck.Splines;
using BehaviorDesigner.Runtime;

namespace EnemyNamescape.BHT
{
    public class MoveToTargetLocation : Action
    {
        IThirdPersonController _thirdPersonController;
        SplineComputer computer;

        float distanceTravel;
        float computerLength;

        [SerializeField] float maxDstBetweenEvaluatedPosAndCharacterPos = .5f;
        [SerializeField] float extraSpeed = .4f;

        public override void OnAwake()
        {
            _thirdPersonController = (Owner.GetVariable(EnemyStaticData.BHTKey.ThirdPersonControllerGo) as SharedGameObject).Value.GetComponent<IThirdPersonController>();
        }

        public override void OnStart()
        {
            computer = (Owner.GetVariable(EnemyStaticData.BHTKey.NavmeshDestinationSplineComputerGo) as SharedGameObject).Value.GetComponent<SplineComputer>();
            computerLength = computer.CalculateLength();
        }

        public override TaskStatus OnUpdate()
        {
            return distanceTravel >= computerLength ? TaskStatus.Success : TaskStatus.Running;
        }

        public override void OnFixedUpdate()
        {
            SplineSample eveluatedSample = computer.Evaluate(distanceTravel / computerLength);
            Vector3 direction = (eveluatedSample.position - _thirdPersonController.Transform.position).normalized;
            _thirdPersonController.Input = direction;

            float dstBetweenEvaluatedPosAndCharacterPos = Vector3.Distance(_thirdPersonController.Transform.position, eveluatedSample.position);

            if (dstBetweenEvaluatedPosAndCharacterPos < maxDstBetweenEvaluatedPosAndCharacterPos)
            {
                distanceTravel += _thirdPersonController.MoveSpeed * Time.fixedDeltaTime + extraSpeed;
                distanceTravel = Mathf.Clamp(distanceTravel, 0, computerLength);
            }
        }

        public override void OnEnd() => distanceTravel = 0;
    }
}