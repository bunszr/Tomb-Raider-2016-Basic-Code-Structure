using DG.Tweening;
using FSM;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace CampSite
{
    public class HighlightState : CSBParalelStateBase
    {
        [System.Serializable]
        public class HighlightStateData
        {
            public Image imageToHighlight;
            public float duration = .4f;
        }

        Tween tween;
        HighlightStateData data;

        public HighlightState(MonoBehaviour mono, HighlightStateData data) : base(mono)
        {
            this.data = data;
        }

        public override void OnEnter()
        {
            base.OnEnter();
            tween = data.imageToHighlight.DOFillAmount(1, data.duration).SetAutoKill(false).SetEase(Ease.InOutSine).Pause();
        }

        public override void OnExit()
        {
            base.OnExit();
            tween.KillMine();
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