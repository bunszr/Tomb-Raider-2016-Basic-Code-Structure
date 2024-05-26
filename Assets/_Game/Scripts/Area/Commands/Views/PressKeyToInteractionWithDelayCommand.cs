using System;
using UnityEngine;

namespace TriggerableAreaNamespace
{
    public class PressKeyToInteractionWithDelayCommand : IAreaCommad
    {
        GameObject popUpGo;
        Func<bool> pressKeyCondition;
        float delay;
        int maxPressCount = 5;

        float nextTime;
        int pressCount;

        public PressKeyToInteractionWithDelayCommand(GameObject popUpGo, Func<bool> pressKeyCondition, float delay, int maxPressCount)
        {
            this.popUpGo = popUpGo;
            this.pressKeyCondition = pressKeyCondition;
            this.delay = delay;
            this.maxPressCount = maxPressCount;
        }

        public void Enter() { }
        public void Exit() { }

        public TaskStatusEnum OnUpdate()
        {
            if (pressKeyCondition())
            {
                nextTime = Time.time + delay;
                pressCount++;
                popUpGo.SetActive(false);
            }
            else if (Time.time > nextTime) popUpGo.SetActive(true);
            return pressCount >= maxPressCount ? TaskStatusEnum.Success : TaskStatusEnum.Running;
        }
    }
}