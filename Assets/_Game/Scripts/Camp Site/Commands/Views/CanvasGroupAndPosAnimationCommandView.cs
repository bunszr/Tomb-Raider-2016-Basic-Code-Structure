using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CampSite
{
    public class CanvasGroupAndPosAnimationCommandView : CampsiteButtonCommandBase
    {
        [System.Serializable]
        public class CanvasGroupAndPosAnimationCommandViewData
        {
            public Vector3 targetLocalPos = new Vector3(0, 30, 0);
            public float posDuration = .4f;
            public Ease posEase = Ease.OutQuad;
            public float fadeDuration = .2f;
            public Ease fadeEase = Ease.InOutSine;
        }

        CanvasGroup canvasGroup;
        CanvasGroupAndPosAnimationCommandViewData data;
        TransformRecovery transformRecovery;

        public CanvasGroupAndPosAnimationCommandView(CSBBase csbBase, CanvasGroup canvasGroup, CanvasGroupAndPosAnimationCommandViewData data) : base(csbBase)
        {
            this.canvasGroup = canvasGroup;
            transformRecovery = new TransformRecovery(canvasGroup.transform);
            this.data = data;
        }

        protected override void OnPointerEnter(PointerEventData eventData)
        {
            base.OnPointerEnter(eventData);
            canvasGroup.DOFade(1, data.fadeDuration).From(0).SetEase(data.fadeEase);
            canvasGroup.transform.DOLocalMove(data.targetLocalPos, data.posDuration).SetEase(data.posEase).From(true);
        }

        protected override void OnPointerExit(PointerEventData eventData)
        {
            base.OnPointerExit(eventData);
            canvasGroup.DOKill();
            canvasGroup.transform.DOKill();

            canvasGroup.alpha = 0;
            transformRecovery.ResetWitLocalSpaceNoParent();
        }
    }
}