using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace CampSite
{
    public class LockedCommandView : CampsiteButtonCommandBase
    {
        Tween tween;
        Image image;
        float defaultLocalY;

        GameDataScriptable.CampSiteScriptableData.LockedCommandScriptableData data => GameDataScriptable.Ins.campSiteScriptableData.lockedCommandScriptableData;

        public LockedCommandView(CSBBase csbBase, Image image) : base(csbBase)
        {
            this.image = image;
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