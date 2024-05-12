using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
using Dreamteck.Splines;
using BehaviorDesigner.Runtime;
using System.Linq;

namespace EnemyNamescape.BHT
{
    public class MoveInCoverAsPingPong : Action
    {
        Enemy enemy;
        IThirdPersonController _thirdPersonController;
        SplineComputer computer;
        SplineSample eveluatedSample;

        float distanceTravel;
        float computerLength;

        [SerializeField] float strafeTurnSmoothSpeed = 1.65f;
        [SerializeField] float extraSpeed = .4f;
        [SerializeField] float maxDstBetweenEvaluatedPosAndCharacterPos = .5f;

        public override void OnAwake()
        {
            _thirdPersonController = (Owner.GetVariable(EnemyStaticData.BHTKey.ThirdPersonControllerGo) as SharedGameObject).Value.GetComponent<IThirdPersonController>();
            enemy = _thirdPersonController.Transform.GetComponent<Enemy>();
        }

        public override void OnStart()
        {
            CoverLocationData coverLocationData = EnemyManager.Ins.coverLocationHolder.coverLocationDatas.FirstOrDefault(x => x.EnemyInCoverRP.Value == enemy);
            computer = coverLocationData.computer;
            computerLength = computer.CalculateLength();

            _thirdPersonController.IsStrafe = true;

            eveluatedSample = computer.Evaluate(0);
        }

        public override void OnEnd()
        {
            distanceTravel = 0;
            _thirdPersonController.IsStrafe = false;
        }

        public override TaskStatus OnUpdate()
        {
            _thirdPersonController.StrafeDirectionTransform.rotation = Quaternion.Slerp(_thirdPersonController.StrafeDirectionTransform.rotation, Quaternion.LookRotation(eveluatedSample.right), Time.deltaTime * strafeTurnSmoothSpeed);
            return TaskStatus.Running;
        }

        public override void OnFixedUpdate()
        {
            float pingPongDst = Mathf.PingPong(distanceTravel, computerLength);
            eveluatedSample = computer.Evaluate(pingPongDst / computerLength);
            Vector3 direction = (eveluatedSample.position - _thirdPersonController.Transform.position).normalized;
            _thirdPersonController.Input = direction;

            float dstBetweenEvaluatedPosAndCharacterPos = Vector3.Distance(_thirdPersonController.Transform.position, eveluatedSample.position);

            if (dstBetweenEvaluatedPosAndCharacterPos < maxDstBetweenEvaluatedPosAndCharacterPos)
            {
                distanceTravel += _thirdPersonController.MoveSpeed * Time.fixedDeltaTime + extraSpeed;
            }
        }

    }
}