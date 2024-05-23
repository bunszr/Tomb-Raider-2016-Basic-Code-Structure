using UnityEngine;
using Sirenix.OdinInspector;
using BehaviorDesigner.Runtime;
using Zenject;
using BehaviorDesigner.Runtime.Tasks;

namespace Character
{
    // https://www.opsive.com/forum/index.php?threads/proper-way-to-integrate-dependency-injection-with-behavior-tree-reference-tasks.5092/ 
    public class EnemyBHTInjector : MonoBehaviour
    {
        [Inject, ReadOnly] DiContainer diContainer;
        public BehaviorTree tree;

        private void Awake()
        {
            QueueAllTasksForInject(tree, diContainer);
        }

        public void QueueAllTasksForInject(BehaviorTree tree, DiContainer container)
        {
            tree.CheckForSerialization();

            tree.OnBehaviorStart += behavior => { InjectIntoBehavior(container, behavior); };
        }

        private void InjectIntoBehavior(DiContainer container, Behavior behavior)
        {
            foreach (var task in behavior.FindTasks<Task>())
            {
                if (task is BehaviorTreeReference referenceTask)
                {
                    foreach (var externalBehavior in referenceTask.GetExternalBehaviors())
                    {
                        externalBehavior.Init();
                        var tasks = externalBehavior.FindTasks<Task>();
                        tasks.ForEach(container.Inject);
                    }
                }
                container.Inject(task);
            }
        }
    }
}