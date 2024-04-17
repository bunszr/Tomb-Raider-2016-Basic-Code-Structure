using DG.Tweening;
using FSM;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CampSite
{
    public class ShowInformationState : CSBStateBase
    {
        [System.Serializable]
        public class ShowInformationStateData
        {
            public string name;
            public string description;
        }

        FeatureInformationPanelHolder featureInformationPanelHolder;
        ShowInformationStateData data;
        GameDataScriptable.CampSiteScriptableData.ShowInformationScriptableData ScriptableData => GameDataScriptable.Ins.campSiteScriptableData.showInformationScriptableData;

        public ShowInformationState(MonoBehaviour mono, bool needsExitTime, ShowInformationStateData data) : base(mono, needsExitTime)
        {
            this.data = data;
        }

        public override void OnEnter() => SubcribeButtonEvents();
        public override void OnExit() => UnSubcribeButtonEvents();

        float defautLocalY;

        public override void Init()
        {
            featureInformationPanelHolder = campSiteHolder.FeatureInformationPanelHolder;
            defautLocalY = featureInformationPanelHolder.canvasGroup.transform.localPosition.y;
        }

        protected override void OnPointerEnter(PointerEventData eventData)
        {
            featureInformationPanelHolder.canvasGroup.DOFade(1, ScriptableData.fadeDuration).From(0).SetEase(ScriptableData.fadeEase);
            featureInformationPanelHolder.canvasGroup.transform.DOLocalMoveY(ScriptableData.yAnimationAmount, ScriptableData.yAnimationDuration).SetEase(ScriptableData.yAnimEase).From(true);

            featureInformationPanelHolder.nameText.text = data.name;
            featureInformationPanelHolder.descriptionText.text = data.description;
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