using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace TriggerableAreaNamespace
{
    public class CommandExecuter
    {
        public System.Action onFinished;
        public CommandExecuterDebug commandExecuterDebug;

        [System.Serializable]
        public class CommandExecuterDebug
        {
            int counter = 1;
            [HorizontalGroup("a"), SerializeField] bool isDebug = false;
            [HorizontalGroup("a"), SerializeField] int maxStateCountToShow = 8;
            [SerializeField] List<string> enteringStatesList;

            public void Debug(string stateName)
            {
#if UNITY_EDITOR
                if (isDebug)
                {
                    if (enteringStatesList.Count > maxStateCountToShow - 1) enteringStatesList.RemoveAt(0);
                    enteringStatesList.Add(counter++ + " " + stateName);
                }
#endif
            }
        }

        Queue<IAreaCommad> queues = new Queue<IAreaCommad>();
        MonoBehaviour monoToUpdate;
        IAreaCommad[] areaCommads;

        public CommandExecuter(MonoBehaviour monoToUpdate, IAreaCommad[] areaCommads)
        {
            this.monoToUpdate = monoToUpdate;
            this.areaCommads = areaCommads;
        }

        public void Activate()
        {
            queues.Clear();
            for (int i = 0; i < areaCommads.Length; i++) queues.Enqueue(areaCommads[i]);

            queues.Peek().Enter();
            commandExecuterDebug.Debug(queues.Peek().GetType().Name);

            UpdateManager.Ins.RegisterAsUpdate(monoToUpdate, OnUpdate);
        }

        public void Deactivate()
        {
            queues.Clear();
            UpdateManager.Ins.UnregisterAsUpdate(monoToUpdate, OnUpdate);
        }

        private void OnUpdate()
        {
            TaskStatusEnum taskStatusEnum = queues.Peek().OnUpdate();

            if (taskStatusEnum == TaskStatusEnum.Success)
            {
                queues.Peek().Exit();
                queues.Dequeue();
                if (queues.Count == 0) onFinished?.Invoke();
                else
                {
                    queues.Peek().Enter();
                    commandExecuterDebug.Debug(queues.Peek().GetType().Name);
                }
            }
        }
    }
}