using DG.Tweening;
using FSM;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace CampSite
{
    public class HighlightState : CSBStateBase
    {
        [System.Serializable]
        public class HighlightStateData
        {
            public Image imageToHighlight;
            public float duration = .4f;
        }

        Tween tween;
        HighlightStateData data;

        public HighlightState(MonoBehaviour mono, bool needsExitTime, HighlightStateData data) : base(mono, needsExitTime)
        {
            this.data = data;
        }

        public override void OnEnter()
        {
            SubcribeButtonEvents();
            tween = data.imageToHighlight.DOFillAmount(1, data.duration).SetAutoKill(false).SetEase(Ease.InOutSine).Pause();
        }

        public override void OnExit()
        {
            UnSubcribeButtonEvents();
            tween.KillMine();
            data.imageToHighlight.fillAmount = 0;
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