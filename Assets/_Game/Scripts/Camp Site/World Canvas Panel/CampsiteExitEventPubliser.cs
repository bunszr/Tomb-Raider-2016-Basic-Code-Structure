using UnityEngine;
using UnityEngine.UI;
using UniRx;

namespace CampSite
{
    public class CampsiteExitEventPubliser : MonoBehaviour, IPanelObserver
    {
        [SerializeField] Button closeButton;

        bool hasExit;
        private void Start() => GetComponentInParent<ISubject<IPanelObserver>>().Register(this);
        private void OnDestroy() => GetComponentInParent<ISubject<IPanelObserver>>(true).Unregister(this);

        public void OnPanelActive()
        {
            hasExit = false;
            closeButton.onClick.AddListener(OnClick);
            UpdateManager.Ins.RegisterAsUpdate(this, OnUpdate);
        }

        public void OnPanelDeactive()
        {
            closeButton.onClick.RemoveListener(OnClick);
            UpdateManager.Ins.UnregisterAsUpdate(this, OnUpdate);
        }

        private void OnUpdate()
        {
            if (IM.Ins.Input.ClosePanelPressKey && !hasExit)
            {
                hasExit = true;
                MessageBroker.Default.Publish(new OnCampsiteExitEvent { });
            }
        }

        public void OnClick()
        {
            if (!hasExit)
            {
                hasExit = true;
                MessageBroker.Default.Publish(new OnCampsiteExitEvent() { });
            }
        }
    }
}