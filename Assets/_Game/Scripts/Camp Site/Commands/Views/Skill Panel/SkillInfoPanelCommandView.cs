using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CampSite
{
    public class SkillInfoPanelCommandView : CampsiteButtonCommandBase
    {
        CanvasGroup canvasGroup;
        float defautLocalY;

        GameDataScriptable.CampSiteScriptableData.SkillInfoPanelScriptableData ScriptableData => GameDataScriptable.Ins.campSiteScriptableData.skillInfoPanelScriptableData;

        public SkillInfoPanelCommandView(CSBBase csbBase, CanvasGroup canvasGroup) : base(csbBase)
        {
            this.canvasGroup = canvasGroup;
            defautLocalY = canvasGroup.transform.localPosition.y;
        }

        protected override void OnPointerEnter(PointerEventData eventData)
        {
            base.OnPointerEnter(eventData);
            canvasGroup.DOFade(1, ScriptableData.fadeDuration).From(0).SetEase(ScriptableData.fadeEase);
            canvasGroup.transform.DOLocalMoveY(ScriptableData.yAnimationAmount, ScriptableData.yAnimationDuration).SetEase(ScriptableData.yAnimEase).From(true);
        }

        protected override void OnPointerExit(PointerEventData eventData)
        {
            base.OnPointerExit(eventData);
            canvasGroup.DOKill();
            canvasGroup.transform.DOKill();

            canvasGroup.alpha = 0;
            canvasGroup.transform.SetLocalPosY(defautLocalY);
        }
    }
}