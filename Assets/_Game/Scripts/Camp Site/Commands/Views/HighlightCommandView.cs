using DG.Tweening;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace CampSite
{
    public class HighlightCommandView : CampsiteButtonCommandBase
    {
        Tween tween;
        Image image;

        GameDataScriptable.CampSiteScriptableData.HighlightStateScriptableData data => GameDataScriptable.Ins.campSiteScriptableData.highlightStateScriptableData;

        public HighlightCommandView(CSBBase csbBase, Image image) : base(csbBase) => this.image = image;

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

        protected override void OnPointerEnter(PointerEventData eventData)
        {
            base.OnPointerEnter(eventData);
            tween.PlayForward();
        }

        protected override void OnPointerExit(PointerEventData eventData)
        {
            base.OnPointerExit(eventData);
            tween.PlayBackwards();
        }
    }
}