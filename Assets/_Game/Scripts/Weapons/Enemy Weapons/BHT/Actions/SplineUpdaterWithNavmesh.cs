using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
using Dreamteck.Splines;
using UnityEngine.AI;
using BehaviorDesigner.Runtime;
using DG.Tweening;

namespace EnemyNamescape.BHT
{
    public class SplineUpdaterWithNavmesh : Action
    {
        Tween tween;
        NavMeshPath navMeshPath;
        SplineComputer computer;
        IThirdPersonController _thirdPersonController;

        [SerializeField] SharedGameObject moveToPlayerComputerSGO;
        [SerializeField] SharedGameObject enemyTargetSGO;
        [SerializeField] SharedGameObject thirdPersonControllerSGO;
        [SerializeField] SharedFloat distanceTravelSF;
        [SerializeField] SharedFloat computerLengthSF;

        [SerializeField] float delayedCall = .3f;
        [SerializeField] float enemyTargetNearByThreashold = 3;

        public override void OnAwake()
        {
            computer = moveToPlayerComputerSGO.Value.GetComponent<SplineComputer>();
            computerLengthSF.Value = computer.CalculateLength();
            navMeshPath = new NavMeshPath();
            _thirdPersonController = thirdPersonControllerSGO.Value.GetComponent<IThirdPersonController>();
        }

        public override void OnStart()
        {
            tween = DOVirtual.DelayedCall(delayedCall, UpdateSpline, false).SetLoops(-1);
        }

        public override TaskStatus OnUpdate()
        {
            return TaskStatus.Running;
        }

        public override void OnEnd()
        {
            tween.KillMine();
        }

        public void UpdateSpline()
        {
            Vector3 directionToThis = (_thirdPersonController.Transform.position - enemyTargetSGO.Value.transform.position).normalized;
            Vector3 targetPosition = enemyTargetSGO.Value.transform.position + directionToThis * enemyTargetNearByThreashold;
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
                computerLengthSF.Value = computer.CalculateLength();
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