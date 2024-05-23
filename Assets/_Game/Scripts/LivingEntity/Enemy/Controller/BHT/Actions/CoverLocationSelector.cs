using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
using Dreamteck.Splines;
using UnityEngine.AI;
using BehaviorDesigner.Runtime;
using DG.Tweening;
using System.Linq;

namespace EnemyNamescape.BHT
{
    public class CoverLocationSelector : Action
    {
        public override void OnStart()
        {
            Transform thirdPersonT = (Owner.GetVariable(EnemyStaticData.BHTKey.ThirdPersonControllerGo) as SharedGameObject).Value.GetComponent<IThirdPersonController>().Transform;

            CoverLocationData coverLocationData = EnemyManager.Ins.coverLocationHolder.coverLocationDatas.OrderBy(x => Vector3.SqrMagnitude(x.transform.position - thirdPersonT.position)).First();
            coverLocationData.EnemyInCoverRP.Value = thirdPersonT.GetComponent<Enemy>();

            Vector3 target = coverLocationData.computer.GetPoint(0).position;

            Owner.SetVariable(EnemyStaticData.BHTKey.NavmeshDestination, (SharedVector3)target);
            Owner.SetVariable(EnemyStaticData.BHTKey.CoverLocationDataGo, (SharedGameObject)coverLocationData.gameObject);
        }

        public override TaskStatus OnUpdate()
        {
            return TaskStatus.Success;
        }
    }
}