using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
using Dreamteck.Splines;
using Invector.vCharacterController;

public class PatrolAction : Action
{
    float computerLength;
    [SerializeField] SplineComputer computer;
    [SerializeField] vThirdPersonController thirdPersonController;

    float distanceTravel;

    [SerializeField] float maxDstBetweenEvaluatedPosAndCharacterPos = .5f;
    [SerializeField] float extraSpeed = .4f;

    public override void OnAwake()
    {
        computerLength = computer.CalculateLength();
    }

    public override void OnStart()
    {
        #region If we would say that AI start to nearest point on spline, first round is okey but second round result of Project might be close to the end of the spline. It is inapproprite
        // SplineSample splineSample = new SplineSample();
        // computer.Project(thirdPersonController.transform.position, ref splineSample);
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
        Vector3 direction = (eveluatedSample.position - thirdPersonController.transform.position).normalized;
        thirdPersonController.input = direction;

        float dstBetweenEvaluatedPosAndCharacterPos = Vector3.Distance(thirdPersonController.transform.position, eveluatedSample.position);

        if (dstBetweenEvaluatedPosAndCharacterPos < maxDstBetweenEvaluatedPosAndCharacterPos)
        {
            // distanceTravel += thirdPersonController._rigidbody.velocity.magnitude * Time.fixedDeltaTime; // It is not suitable. When Rb started to behave strange movement. It will be broken

            distanceTravel += thirdPersonController.moveSpeed * Time.fixedDeltaTime + extraSpeed;
            distanceTravel = Mathf.Clamp(distanceTravel, 0, computerLength);
        }

#if UNITY_EDITOR
        // Popcron.Gizmos.Circle(thirdPersonController.transform.position, maxDstBetweenEvaluatedPosAndCharacterPos, Quaternion.LookRotation(Vector3.up));
        // Popcron.Gizmos.Line(thirdPersonController.transform.position, eveluatedSample.position);
        // Debug.Log($"{thirdPersonController.moveSpeed} {thirdPersonController._rigidbody.velocity.magnitude}");
#endif
    }

    public override void OnEnd() => distanceTravel = 0;
}