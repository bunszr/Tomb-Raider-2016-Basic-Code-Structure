using Cinemachine;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace CampSite
{
    public class HighlightState : CampSiteButtonStateBase, IStateBaseMine
    {
        [System.Serializable]
        public class HighlightStateData
        {
            public Image imageToHighlight;
            public float duration = .4f;
        }

        Tween tween;
        ButtonEvents buttonEvents;
        HighlightStateData data;

        public HighlightState(MonoBehaviour mono, bool needsExitTime, ButtonEvents buttonEvents, HighlightStateData data) : base(mono, needsExitTime)
        {
            this.buttonEvents = buttonEvents;
            this.data = data;
        }

        public override void Init()
        {
        }

        public override void OnEnter()
        {
            tween = data.imageToHighlight.DOFillAmount(1, data.duration).SetAutoKill(false).SetEase(Ease.InOutSine).Pause();
            buttonEvents.onPointerEnterEvent += OnPointerEnter;
            buttonEvents.onPointerExitEvent += OnPointerExit;
        }

        public override void OnLogic()
        {
        }

        public override void OnExit()
        {
            buttonEvents.onPointerEnterEvent -= OnPointerEnter;
            buttonEvents.onPointerExitEvent -= OnPointerExit;
            tween.KillMine();
        }

        void OnPointerEnter(PointerEventData eventData)
        {
            tween.PlayForward();
        }

        void OnPointerExit(PointerEventData eventData)
        {
            tween.PlayBackwards();
        }
    }
}