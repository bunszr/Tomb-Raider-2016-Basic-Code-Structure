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

        MonoEvents monoUpdateEvents;
        Queue<IAreaCommad> queues = new Queue<IAreaCommad>();
        IAreaCommad[] areaCommads;

        public CommandExecuter(MonoEvents monoEvents, IAreaCommad[] areaCommads)
        {
            this.monoUpdateEvents = monoEvents;
            this.areaCommads = areaCommads;
        }

        public void Activate()
        {
            queues.Clear();
            for (int i = 0; i < areaCommads.Length; i++) queues.Enqueue(areaCommads[i]);

            queues.Peek().Enter();
            commandExecuterDebug.Debug(queues.Peek().GetType().Name);
            monoUpdateEvents.onUpdate += OnUpdate;
        }

        public void Deactivate()
        {
            queues.Clear();
            monoUpdateEvents.onUpdate -= OnUpdate;
        }

        private void OnUpdate()
        {
            TaskStatusEnum taskStatusEnum = queues.Peek().OnUpdate();

            if (taskStatusEnum == TaskStatusEnum.Success)
            {
                queues.Peek().Exit();
                queues.Dequeue();
                if (queues.Count == 0)
                {
                    monoUpdateEvents.onUpdate -= OnUpdate;
                    onFinished?.Invoke();
                }
                else
                {
                    queues.Peek().Enter();
                    commandExecuterDebug.Debug(queues.Peek().GetType().Name);
                }
            }
        }
    }
}