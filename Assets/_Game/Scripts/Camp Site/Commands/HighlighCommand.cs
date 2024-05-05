using DG.Tweening;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace CampSite
{
    public class HighlighCommand : CampsiteCommandBase
    {
        Tween tween;
        Image image;

        GameDataScriptable.CampSiteScriptableData.HighlightStateScriptableData data => GameDataScriptable.Ins.campSiteScriptableData.highlightStateScriptableData;

        public HighlighCommand(CampSiteButtonBase csbBase, Image image) : base(csbBase) => this.image = image;

        public override void OnActivate()
        {
            base.OnActivate();
            tween = image.DOFillAmount(1, data.duration).SetAutoKill(false).SetEase(Ease.InOutSine).Pause();
        }

        public override void OnDeactivate()
        {
            base.OnDeactivate();
            tween.KillMine();
            image.fillAmount = 0;
        }

        protected override void OnPointerEnter(PointerEventData eventData) => tween.PlayForward();
        protected override void OnPointerExit(PointerEventData eventData) => tween.PlayBackwards();
    }
}