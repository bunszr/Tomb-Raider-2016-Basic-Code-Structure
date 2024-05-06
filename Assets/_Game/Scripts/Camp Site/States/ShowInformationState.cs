using DG.Tweening;
using UnityEngine.EventSystems;

namespace CampSite
{
    public class ShowInformationState : CampsiteButtonCommandBase
    {
        float defautLocalY;
        FeatureTypeScriptable featureTypeScriptable;
        FeatureInformationPanelHolder featureInformationPanelHolder;

        GameDataScriptable.CampSiteScriptableData.ShowInformationScriptableData ScriptableData => GameDataScriptable.Ins.campSiteScriptableData.showInformationScriptableData;

        public ShowInformationState(CampSiteButtonBase csbBase, FeatureInformationPanelHolder featureInformationPanelHolder, FeatureTypeScriptable featureTypeScriptable) : base(csbBase)
        {
            this.featureInformationPanelHolder = featureInformationPanelHolder;
            this.featureTypeScriptable = featureTypeScriptable;
            defautLocalY = featureInformationPanelHolder.canvasGroup.transform.localPosition.y;
        }

        protected override void OnPointerEnter(PointerEventData eventData)
        {
            featureInformationPanelHolder.canvasGroup.DOFade(1, ScriptableData.fadeDuration).From(0).SetEase(ScriptableData.fadeEase);
            featureInformationPanelHolder.canvasGroup.transform.DOLocalMoveY(ScriptableData.yAnimationAmount, ScriptableData.yAnimationDuration).SetEase(ScriptableData.yAnimEase).From(true);

            featureInformationPanelHolder.nameText.text = featureTypeScriptable.FeatureName;
            featureInformationPanelHolder.descriptionText.text = featureTypeScriptable.Description;
        }

        protected override void OnPointerExit(PointerEventData eventData)
        {
            featureInformationPanelHolder.canvasGroup.DOKill();
            featureInformationPanelHolder.canvasGroup.transform.DOKill();

            featureInformationPanelHolder.canvasGroup.alpha = 0;
            featureInformationPanelHolder.canvasGroup.transform.SetLocalPosY(defautLocalY);
        }
    }
}