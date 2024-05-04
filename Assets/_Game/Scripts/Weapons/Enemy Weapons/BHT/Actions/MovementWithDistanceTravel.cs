using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
using Dreamteck.Splines;
using BehaviorDesigner.Runtime;

namespace EnemyNamescape.BHT
{
    public class MovementWithDistanceTravel : Action
    {
        SplineComputer computer;
        IThirdPersonController _thirdPersonController;

        [SerializeField] SharedGameObject moveToPlayerComputerSGO;
        [SerializeField] SharedGameObject thirdPersonControllerSGO;
        [SerializeField] SharedFloat distanceTravelSF;
        [SerializeField] SharedFloat computerLengthSF;


        [SerializeField] float maxDstBetweenEvaluatedPosAndCharacterPos = .4f;
        [SerializeField] float extraSpeed = .4f;

        public override void OnAwake()
        {
            computer = moveToPlayerComputerSGO.Value.GetComponent<SplineComputer>();
            _thirdPersonController = thirdPersonControllerSGO.Value.GetComponent<IThirdPersonController>();
        }

        public override TaskStatus OnUpdate()
        {
            return TaskStatus.Running;
        }

        public override void OnFixedUpdate()
        {
            SplineSample eveluatedSample = computer.Evaluate(distanceTravelSF.Value / computerLengthSF.Value);
            Vector3 direction = (eveluatedSample.position - _thirdPersonController.Transform.position).normalized;
            if (distanceTravelSF.Value == computerLengthSF.Value) direction = _thirdPersonController.Transform.forward * .001f; //Small input protect from rotation jiggling
            _thirdPersonController.Input = direction;

            float dstBetweenEvaluatedPosAndCharacterPos = Vector3.Distance(_thirdPersonController.Transform.position, eveluatedSample.position);

            if (dstBetweenEvaluatedPosAndCharacterPos < maxDstBetweenEvaluatedPosAndCharacterPos)
            {
                distanceTravelSF.Value += _thirdPersonController.MoveSpeed * Time.fixedDeltaTime + extraSpeed;
                distanceTravelSF.Value = Mathf.Clamp(distanceTravelSF.Value, 0, computerLengthSF.Value);
            }
        }

        public override void OnEnd()
        {
            _thirdPersonController.Input *= .001f;
        }
    }
}