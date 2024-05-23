using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UniRx;

namespace EnemyNamescape.BHT
{
    public class EnemyIsDeath : Conditional
    {
        Enemy enemy;
        bool isDeath;
        System.IDisposable disposable;

        public override void OnAwake()
        {
            base.OnAwake();
            enemy = ((SharedGameObject)Owner.GetVariable(EnemyStaticData.BHTKey.ThirdPersonControllerGo)).Value.GetComponent<Enemy>();
            disposable = enemy.HealthRP.Where(x => x <= 0).Subscribe(OnEnemyDeath);
        }

        public override void OnBehaviorComplete()
        {
            base.OnBehaviorComplete();
            disposable.Dispose();
        }

        void OnEnemyDeath(float health) => isDeath = true;
        public override TaskStatus OnUpdate() => isDeath ? TaskStatus.Success : TaskStatus.Failure;
    }
}