using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
using Dreamteck.Splines;
using UnityEngine.AI;
using BehaviorDesigner.Runtime;
using DG.Tweening;

namespace EnemyNamescape.BHT
{
    public class MoveToEnemyTargetWithUpdatingSpline : Action
    {
        Tween tween;
        NavMeshPath navMeshPath = new NavMeshPath();
        SplineComputer computer;
        IThirdPersonController _thirdPersonController;

        [SerializeField] SharedGameObject thirdPersonControllerSGO;
        [SerializeField] SharedFloat distanceTravelSF;
        [SerializeField] SharedFloat computerLengthSF;

        [SerializeField] float delayedCall = .3f;
        [SerializeField] float enemyTargetNearByThreashold = 3;


        [SerializeField] float maxDstBetweenEvaluatedPosAndCharacterPos = .4f;
        [SerializeField] float extraSpeed = .4f;


        public override void OnAwake()
        {
            SharedGameObject sharedGameObject = (SharedGameObject)Owner.GetVariable(EnemyStaticData.BHTKey.MoveToEnemyTargetComputerGo);
            if (sharedGameObject == null)
            {
                GameObject go = new GameObject(GetType().Name + "Computer Go", typeof(SplineComputer));
                go.transform.parent = Owner.transform;
                computer = go.GetComponent<SplineComputer>();

                computer.space = SplineComputer.Space.World;
                computer.type = Spline.Type.Linear;

                SplinePoint[] points = new SplinePoint[3];
                computer.SetPoints(points);
                computer.Rebuild();

                Owner.SetVariable(EnemyStaticData.BHTKey.MoveToEnemyTargetComputerGo, (SharedGameObject)computer.gameObject);
            }

            _thirdPersonController = thirdPersonControllerSGO.Value.GetComponent<IThirdPersonController>();
        }

        public override void OnStart()
        {
            tween = DOVirtual.DelayedCall(delayedCall, UpdateSpline, false).SetLoops(-1);
            _thirdPersonController.IsStrafe = true;
        }

        public override void OnEnd()
        {
            _thirdPersonController.Input *= .001f;
            _thirdPersonController.IsStrafe = false;
            tween.KillMine();
        }

        public override TaskStatus OnUpdate()
        {
            Vector3 directionToEnemyTarget = (EnemyManager.Ins.player.transform.position - _thirdPersonController.Transform.position).normalized;
            _thirdPersonController.StrafeDirectionTransform.rotation = Quaternion.Slerp(_thirdPersonController.StrafeDirectionTransform.rotation, Quaternion.LookRotation(directionToEnemyTarget), Time.deltaTime * 2);
            return TaskStatus.Running;
        }

        public override void OnFixedUpdate()
        {
            float percent = Mathf.Clamp01(distanceTravelSF.Value / (computerLengthSF.Value + .0001f));
            SplineSample eveluatedSample = computer.Evaluate(percent);
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

        public void UpdateSpline()
        {
            Vector3 directionToThis = (_thirdPersonController.Transform.position - EnemyManager.Ins.player.transform.position).normalized;
            Vector3 targetPosition = EnemyManager.Ins.player.transform.position + directionToThis * enemyTargetNearByThreashold;
            bool hasPath = NavMesh.CalculatePath(_thirdPersonController.Transform.position, targetPosition, NavMesh.AllAreas, navMeshPath);

            if (hasPath)
            {
                int loopCount = Mathf.Min(navMeshPath.corners.Length, computer.pointCount);

                for (int i = 0; i < loopCount; i++)
                {
                    computer.SetPointPosition(i, navMeshPath.corners[i]);
                }

                if (navMeshPath.corners.Length < computer.pointCount)
                {
                    for (int i = navMeshPath.corners.Length; i < computer.pointCount; i++)
                    {
                        computer.SetPointPosition(i, navMeshPath.corners[^1]);
                    }
                }
                computerLengthSF.Value = computer.CalculateLength() + .0001f;
                distanceTravelSF.Value = 0;
            }

#if UNITY_EDITOR
            Popcron.Gizmos.Line(targetPosition, targetPosition + Vector3.up, Color.black);
#endif
        }

        public override void OnDrawGizmos()
        {
#if UNITY_EDITOR
            if (navMeshPath != null && navMeshPath.corners != null)
            {
                for (int i = 0; i < navMeshPath.corners.Length - 1; i++) Gizmos.DrawLine(navMeshPath.corners[i], navMeshPath.corners[i + 1]);
            }
#endif
        }
    }
}