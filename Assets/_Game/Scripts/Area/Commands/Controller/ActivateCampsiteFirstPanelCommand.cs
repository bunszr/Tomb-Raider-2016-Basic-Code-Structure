using CampSite;
using UniRx;
using UnityEngine;

namespace TriggerableAreaNamespace
{
    [System.Serializable]
    public class ActivateCampsiteFirstPanelCommand : IAreaCommad
    {
        GameObject panelGo;
        public ActivateCampsiteFirstPanelCommand(GameObject panelGo) => this.panelGo = panelGo;
        public void Enter()
        {
            panelGo.GetComponent<IPanelToggler>().Active();
            MessageBroker.Default.Publish(new OnCampsiteEnterEvent() { });
        }

        public void Exit() { }
        public TaskStatusEnum OnUpdate() => TaskStatusEnum.Success;
    }
}