using UnityEngine;
using DG.Tweening;
using Cinemachine;
using UniRx;

namespace CampSite
{
    public class CSPanelToggler : MonoBehaviour, IPanelToggler
    {
        [SerializeField] CanvasGroup canvasGroup;
        [SerializeField] CinemachineVirtualCamera cam;

        GameDataScriptable.CampSiteScriptableData.CampsitePanelScriptableData Data => GameDataScriptable.Ins.campSiteScriptableData.campsitePanelScriptableData;

        public ReactiveProperty<bool> IsActiveRP { get; private set; } = new ReactiveProperty<bool>();

        public void Active()
        {
            canvasGroup.blocksRaycasts = false;
            canvasGroup.interactable = false;
            canvasGroup.DOKill();
            canvasGroup.DOFade(1, Data.fadeOutDuration).From(0).SetEase(Data.fadeEase).onComplete = OnComplete;
            cam.gameObject.SetActive(true);
            IsActiveRP.Value = true;
        }

        public void Deactive()
        {
            canvasGroup.blocksRaycasts = false;
            canvasGroup.interactable = false;
            canvasGroup.DOKill();
            canvasGroup.DOFade(0, Data.fadeInDuration).From(1).SetEase(Data.fadeEase);
            cam.gameObject.SetActive(false);
            IsActiveRP.Value = false;
        }

        public void OnComplete()
        {
            canvasGroup.blocksRaycasts = true;
            canvasGroup.interactable = true;
        }
    }
}