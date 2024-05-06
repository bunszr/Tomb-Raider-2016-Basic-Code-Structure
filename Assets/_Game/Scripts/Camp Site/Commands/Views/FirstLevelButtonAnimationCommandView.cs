using Cinemachine;
using DG.Tweening;
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
            tween = csbBase.transform.DOLocalMoveZ(Data.zOffset, Data.duration).SetAutoKill(false).SetEase(Data.ease).Pause();
        }

        GameDataScriptable.CampSiteScriptableData.FirstLevelAnimScriptableData Data => GameDataScriptable.Ins.campSiteScriptableData.firstLevelAnimScriptableData;

        protected override void OnPointerEnter(PointerEventData eventData)
        {
            // cam.LookAt = transform;
            tween.PlayForward();
        }

        protected override void OnPointerExit(PointerEventData eventData)
        {
            tween.PlayBackwards();
        }
    }
}