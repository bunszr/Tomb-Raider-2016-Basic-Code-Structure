using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CampSite
{
    public class ShowTickImageCommandView : CampsiteButtonCommandBase
    {
        Tween tween;
        GameObject image;
        float defaultLocalY;

        GameDataScriptable.CampSiteScriptableData.ShowTickImageCommandScriptableData data => GameDataScriptable.Ins.campSiteScriptableData.showTickImageCommandScriptableData;

        public ShowTickImageCommandView(CSBBase csbBase, GameObject tickImage) : base(csbBase)
        {
            this.image = tickImage;
            defaultLocalY = image.transform.localPosition.y;
        }

        public override void OnActivate()
        {
            base.OnActivate();
            buttonEvents.onPointerClickEvent += OnClick;
            image.gameObject.SetActive(true);
            tween = image.transform.DOScale(1.5f, data.duration).SetAutoKill(false).SetEase(data.ease).Pause();
        }

        public override void OnDeactivate()
        {
            base.OnDeactivate();
            buttonEvents.onPointerClickEvent -= OnClick;
            tween.KillMine();
            image.transform.localScale = Vector3.one;
            image.transform.SetLocalPosY(defaultLocalY);
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

        void OnClick(PointerEventData eventData) => image.transform.DOLocalMoveY(data.yMovement, .2f).SetRelative(true).From(defaultLocalY).SetEase(Ease.InFlash, 2);
    }
}