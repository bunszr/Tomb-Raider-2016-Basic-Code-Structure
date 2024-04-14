using Cinemachine;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CampSite
{
    public class ButtonAnimationState : CampSiteButtonStateBase
    {
        [System.Serializable]
        public class ButtonAnimationStateData
        {
            public float zOffset = -1;
            public float duration = .5f;
            public Ease ease = Ease.InOutSine;
        }

        Tween tween;
        Tween tweenRot;
        ButtonEvents buttonEvents;
        ButtonAnimationStateData data;
        CinemachineVirtualCamera virtualCamera;

        public ButtonAnimationState(MonoBehaviour mono, bool needsExitTime, ButtonEvents buttonEvents = null, ButtonAnimationStateData data = null) : base(mono, needsExitTime)
        {
            this.buttonEvents = buttonEvents;
            this.data = data;
        }

        public override void Init()
        {
            virtualCamera = transform.GetComponentInParent<Canvas>().GetComponentInChildren<CinemachineVirtualCamera>();
        }

        public override void OnEnter()
        {
            tween = transform.DOLocalMoveZ(data.zOffset, data.duration).SetAutoKill(false).SetEase(data.ease).Pause();
            buttonEvents.onPointerEnterEvent += OnPointerEnter;
            buttonEvents.onPointerExitEvent += OnPointerExit;
        }

        public override void OnExit()
        {
            buttonEvents.onPointerEnterEvent -= OnPointerEnter;
            buttonEvents.onPointerExitEvent -= OnPointerExit;
            tween.KillMine();
        }

        void OnPointerEnter(PointerEventData eventData)
        {
            virtualCamera.Follow = transform;
            tween.PlayForward();
            tweenRot.PlayForward();
        }

        void OnPointerExit(PointerEventData eventData)
        {
            tween.PlayBackwards();
            tweenRot.PlayBackwards();
        }
    }
}