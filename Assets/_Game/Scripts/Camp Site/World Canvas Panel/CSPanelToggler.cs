using UnityEngine;
using DG.Tweening;
using Cinemachine;
using System.Collections.Generic;

namespace CampSite
{
    public class CSPanelToggler : MonoBehaviour, IPanelToggler, ISubject<IPanelObserver>
    {
        [SerializeField] CanvasGroup canvasGroup;
        [SerializeField] CinemachineVirtualCamera cam;

        GameDataScriptable.CampSiteScriptableData.CampsitePanelScriptableData Data => GameDataScriptable.Ins.campSiteScriptableData.campsitePanelScriptableData;

        List<IPanelObserver> _panelObservers = new List<IPanelObserver>();

        public void Active()
        {
            canvasGroup.blocksRaycasts = false;
            canvasGroup.interactable = false;
            canvasGroup.DOKill();
            canvasGroup.DOFade(1, Data.fadeOutDuration).From(0).SetEase(Data.fadeEase).onComplete = OnComplete;
            cam.gameObject.SetActive(true);
            _panelObservers.ForEach(x => x.OnPanelActive());
        }

        public void Deactive()
        {
            canvasGroup.blocksRaycasts = false;
            canvasGroup.interactable = false;
            canvasGroup.DOKill();
            canvasGroup.DOFade(0, Data.fadeInDuration).From(1).SetEase(Data.fadeEase);
            cam.gameObject.SetActive(false);
            _panelObservers.ForEach(x => x.OnPanelDeactive());
        }

        public void OnComplete()
        {
            canvasGroup.blocksRaycasts = true;
            canvasGroup.interactable = true;
        }

        public void Register(IPanelObserver panelObserver) => _panelObservers.Add(panelObserver);
        public void Unregister(IPanelObserver panelObserver) => _panelObservers.Remove(panelObserver);
    }
}