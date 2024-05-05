using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace CampSite
{
    public class HighlightState : CSBStateBase
    {
        Tween tween;
        Image image;

        GameDataScriptable.CampSiteScriptableData.HighlightStateScriptableData data => GameDataScriptable.Ins.campSiteScriptableData.highlightStateScriptableData;

        public HighlightState(MonoBehaviour mono, Image image, bool needsExitTime = false, bool isGhostState = false) : base(mono, needsExitTime, isGhostState)
        {
            this.image = image;
        }

        public override void OnEnter()
        {
            SubcribeButtonEvents();
            tween = image.DOFillAmount(1, data.duration).SetAutoKill(false).SetEase(Ease.InOutSine).Pause();
        }

        public override void OnExit()
        {
            UnSubcribeButtonEvents();
            tween.KillMine();
            image.fillAmount = 0;
        }

        protected override void OnPointerEnter(PointerEventData eventData)
        {
            tween.PlayForward();
        }

        protected override void OnPointerExit(PointerEventData eventData)
        {
            tween.PlayBackwards();
        }
    }
}