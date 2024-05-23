using BehaviorDesigner.Runtime.Tasks;
using Zenject;

namespace EnemyNamescape.BHT
{
    public class IsThereEmptyCover : Conditional
    {
        [Inject] CoverLocationHolder coverLocationHolder;

        public override TaskStatus OnUpdate()
        {
            bool allCoverIsFull = true;
            for (int i = 0; i < coverLocationHolder.coverLocationDatas.Length; i++)
            {
                CoverLocationData data = coverLocationHolder.coverLocationDatas[i];
                if (data.EnemyInCoverRP.Value == null) allCoverIsFull = false;
            }
            return !allCoverIsFull ? TaskStatus.Success : TaskStatus.Failure;
        }
    }
}