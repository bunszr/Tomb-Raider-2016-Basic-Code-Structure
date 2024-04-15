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
            public FeatureTypeScriptable[] requirements;

            public float fadeDuration = .4f;
            public Ease fadeEase = Ease.InOutSine;
        }

        FeatureInformationPanelHolder featureInformationPanelHolder;
        ShowInformationStateData data;

        public ShowInformationState(MonoBehaviour mono, bool needsExitTime, ShowInformationStateData data) : base(mono, needsExitTime)
        {
            this.data = data;
        }

        public override void OnEnter() => SubcribeButtonEvents();
        public override void OnExit() => UnSubcribeButtonEvents();

        public override void Init()
        {
            base.Init();
            featureInformationPanelHolder = campSiteHolder.FeatureInformationPanelHolder;
            featureInformationPanelHolder.tweenForActivate.KillMine();
            featureInformationPanelHolder.tweenForActivate = featureInformationPanelHolder.canvasGroup.DOFade(1, data.fadeDuration).From(0).SetAutoKill(false).SetEase(data.fadeEase).Pause();
        }

        protected override void OnPointerEnter(PointerEventData eventData)
        {
            featureInformationPanelHolder.tweenForActivate.PlayForward();

            featureInformationPanelHolder.nameText.text = data.name;
            featureInformationPanelHolder.descriptionText.text = data.description;
            featureInformationPanelHolder.requirementsText.text = "Fill it later";
        }

        protected override void OnPointerExit(PointerEventData eventData)
        {
            featureInformationPanelHolder.tweenForActivate.PlayBackwards();
        }
    }
}