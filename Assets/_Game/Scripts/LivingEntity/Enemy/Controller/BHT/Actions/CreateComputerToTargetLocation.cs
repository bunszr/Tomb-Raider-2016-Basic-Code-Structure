using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
using Dreamteck.Splines;
using UnityEngine.AI;
using BehaviorDesigner.Runtime;
using DG.Tweening;

namespace EnemyNamescape.BHT
{
    public class CreateComputerAccordingNavmesh : Action
    {
        NavMeshPath navMeshPath = new NavMeshPath();
        SplineComputer computer;

        IThirdPersonController _thirdPersonController;

        public override void OnAwake()
        {
            _thirdPersonController = (Owner.GetVariable(EnemyStaticData.BHTKey.ThirdPersonControllerGo) as SharedGameObject).Value.GetComponent<IThirdPersonController>();

            GameObject go = new GameObject(GetType().Name + "Computer Go", typeof(SplineComputer));
            go.transform.parent = Owner.transform;
            computer = go.GetComponent<SplineComputer>();

            computer.space = SplineComputer.Space.World;
            computer.type = Spline.Type.Linear;

            Owner.SetVariable(EnemyStaticData.BHTKey.NavmeshDestinationSplineComputerGo, (SharedGameObject)computer.gameObject);
        }

        public override TaskStatus OnUpdate()
        {
            Vector3 destination = (Owner.GetVariable(EnemyStaticData.BHTKey.NavmeshDestination) as SharedVector3).Value;
            bool hasPath = NavMesh.CalculatePath(_thirdPersonController.Transform.position, destination, NavMesh.AllAreas, navMeshPath);

            if (hasPath)
            {
                SplinePoint[] points = new SplinePoint[navMeshPath.corners.Length];
                for (int i = 0; i < points.Length; i++)
                {
                    points[i] = new SplinePoint(navMeshPath.corners[i]);
                }
                computer.SetPoints(points);
                computer.RebuildImmediate();
            }
            else Debug.LogWarning("No path", Owner.gameObject);

            return hasPath ? TaskStatus.Success : TaskStatus.Running;
        }
    }
}