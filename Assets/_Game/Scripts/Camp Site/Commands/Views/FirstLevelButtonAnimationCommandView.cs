using Cinemachine;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CampSite
{
    public class FirstLevelButtonAnimationCommandView : CampsiteButtonCommandBase
    {
        Tween tween;

        CinemachineVirtualCamera cam;

        public FirstLevelButtonAnimationCommandView(CSBBase csbBase, CinemachineVirtualCamera cam) : base(csbBase)
        {
            this.cam = cam;
        }

        GameDataScriptable.CampSiteScriptableData.FirstLevelAnimScriptableData Data => GameDataScriptable.Ins.campSiteScriptableData.firstLevelAnimScriptableData;

        public override void OnActivate()
        {
            base.OnActivate();
            // csbBase.transform.SetLocalPosZ(0);
            tween = csbBase.transform.DOLocalMoveZ(Data.zOffset, Data.duration).From(0).SetAutoKill(false).SetEase(Data.ease).Pause();
        }

        protected override void OnPointerEnter(PointerEventData eventData)
        {
            // cam.LookAt = transform;
            tween.PlayForward();
            Debug.Log("enter");
        }

        protected override void OnPointerExit(PointerEventData eventData)
        {
            tween.PlayBackwards();
        }
    }
}