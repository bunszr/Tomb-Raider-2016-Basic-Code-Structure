using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
using Dreamteck.Splines;
using BehaviorDesigner.Runtime;

public class PatrolAction : Action
{
    IThirdPersonController _thirdPersonController;
    SplineComputer computer;

    float distanceTravel;
    float computerLength;

    [SerializeField] SharedGameObject thirdPersonControllerSGO;
    [SerializeField] SharedGameObject computerSGO;

    [SerializeField] float maxDstBetweenEvaluatedPosAndCharacterPos = .5f;
    [SerializeField] float extraSpeed = .4f;

    public override void OnAwake()
    {
        _thirdPersonController = thirdPersonControllerSGO.Value.GetComponent<IThirdPersonController>();
        computer = computerSGO.Value.GetComponent<SplineComputer>();
        computerLength = computer.CalculateLength();
    }

    public override void OnStart()
    {
        #region If we would say that AI start to nearest point on spline, first round is okey but second round result of Project might be close to the end of the spline. It is inapproprite
        // SplineSample splineSample = new SplineSample();
        // computer.Project(_thirdPersonController.Transform.position, ref splineSample);
        // distanceTravel = (float)splineSample.percent * computerLength;
        #endregion
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
            // distanceTravel += thirdPersonController._rigidbody.velocity.magnitude * Time.fixedDeltaTime; // It is not suitable. When Rb started to behave strange movement. It will be broken

            distanceTravel += _thirdPersonController.MoveSpeed * Time.fixedDeltaTime + extraSpeed;
            distanceTravel = Mathf.Clamp(distanceTravel, 0, computerLength);
        }

#if UNITY_EDITOR
        // Popcron.Gizmos.Circle(_thirdPersonController.Transform.position, maxDstBetweenEvaluatedPosAndCharacterPos, Quaternion.LookRotation(Vector3.up));
        // Popcron.Gizmos.Line(_thirdPersonController.Transform.position, eveluatedSample.position);
        // Debug.Log($"{thirdPersonController.moveSpeed} {thirdPersonController._rigidbody.velocity.magnitude}");
#endif
    }

    public override void OnEnd() => distanceTravel = 0;
}