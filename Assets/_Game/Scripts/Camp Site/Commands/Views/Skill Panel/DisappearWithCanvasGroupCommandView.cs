using UnityEngine;
using TMPro;
using UniRx;
using UnityEngine.EventSystems;
using DG.Tweening;

namespace CampSite
{
    public class DisappearWithCanvasGroupCommandView : CampsiteButtonCommandBase
    {
        CanvasGroup canvasGroup;

        public DisappearWithCanvasGroupCommandView(CSBBase csbBase, CanvasGroup canvasGroup) : base(csbBase)
        {
            this.canvasGroup = canvasGroup;
        }

        protected override void OnPointerEnter(PointerEventData eventData)
        {
            base.OnPointerEnter(eventData);
            canvasGroup.alpha = 0;
        }

        protected override void OnPointerExit(PointerEventData eventData)
        {
            base.OnPointerExit(eventData);
            canvasGroup.alpha = 1;
        }
    }
}