using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
using BehaviorDesigner.Runtime;
using Zenject;

namespace EnemyNamescape.BHT
{
    public class SetToCoverEmpty : Action
    {
        Enemy enemy;
        [Inject] CoverLocationHolder coverLocationHolder;

        public override void OnAwake()
        {
            base.OnAwake();
            enemy = ((SharedGameObject)Owner.GetVariable(EnemyStaticData.BHTKey.ThirdPersonControllerGo)).Value.GetComponent<Enemy>();
        }

        public override void OnStart()
        {
            for (int i = 0; i < coverLocationHolder.coverLocationDatas.Length; i++)
            {
                CoverLocationData data = coverLocationHolder.coverLocationDatas[i];
                if (data.EnemyInCoverRP.Value == enemy) data.EnemyInCoverRP.Value = null;
            }
        }

        public override TaskStatus OnUpdate()
        {
            return TaskStatus.Success;
        }
    }
}