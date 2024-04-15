using Cinemachine;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CampSite
{
    public class FirstLevelButtonAnimationState : CSBStateBase
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
        ButtonAnimationStateData data;
        CinemachineVirtualCamera virtualCamera;

        public FirstLevelButtonAnimationState(CampSiteButtonBase csbBase, bool needsExitTime, ButtonEvents buttonEvents = null, ButtonAnimationStateData data = null) : base(csbBase, needsExitTime)
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
            SubcribeButtonEvents();
            tween = transform.DOLocalMoveZ(data.zOffset, data.duration).SetAutoKill(false).SetEase(data.ease).Pause();
        }

        public override void OnExit()
        {
            UnSubcribeButtonEvents();
            tween.KillMine();
        }

        protected override void OnPointerEnter(PointerEventData eventData)
        {
            virtualCamera.Follow = transform;
            tween.PlayForward();
            tweenRot.PlayForward();
        }

        protected override void OnPointerExit(PointerEventData eventData)
        {
            tween.PlayBackwards();
            tweenRot.PlayBackwards();
        }
    }
}