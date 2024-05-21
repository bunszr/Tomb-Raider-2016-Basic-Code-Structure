using BehaviorDesigner.Runtime.Tasks;
using Character;
using UniRx;
using UnityEngine;

namespace EnemyNamescape.BHT
{
    public class PlayerIsDeath : Conditional
    {
        bool isDeath;
        System.IDisposable disposable;

        public override void OnAwake()
        {
            base.OnAwake();
            disposable = MessageBroker.Default.Receive<OnPlayerDeathEvent>().Subscribe(OnPlayerDeath);
        }

        public override void OnBehaviorComplete()
        {
            base.OnBehaviorComplete();
            disposable.Dispose();
        }

        void OnPlayerDeath(OnPlayerDeathEvent onPlayerDeathEvent) => isDeath = true;
        public override TaskStatus OnUpdate() => isDeath ? TaskStatus.Success : TaskStatus.Failure;
    }
}