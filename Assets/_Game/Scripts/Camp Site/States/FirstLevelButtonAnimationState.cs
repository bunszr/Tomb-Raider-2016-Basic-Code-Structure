using Cinemachine;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CampSite
{
    public class FirstLevelButtonAnimationState : CSBStateBase
    {
        Tween tween;
        Tween tweenRot;

        CinemachineVirtualCamera cam;

        GameDataScriptable.CampSiteScriptableData.FirstLevelAnimScriptableData Data => GameDataScriptable.Ins.campSiteScriptableData.firstLevelAnimScriptableData;

        public FirstLevelButtonAnimationState(MonoBehaviour mono, CinemachineVirtualCamera cam, bool needsExitTime, bool isGhostState = false) : base(mono, needsExitTime, isGhostState)
        {
            this.cam = cam;
        }

        public override void Init()
        {
            tween = transform.DOLocalMoveZ(Data.zOffset, Data.duration).SetAutoKill(false).SetEase(Data.ease).Pause();
        }

        public override void OnEnter() => SubcribeButtonEvents();
        public override void OnExit() => UnSubcribeButtonEvents();

        protected override void OnPointerEnter(PointerEventData eventData)
        {
            // cam.LookAt = transform;

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