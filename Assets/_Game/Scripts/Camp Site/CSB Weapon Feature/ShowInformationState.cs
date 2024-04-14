using DG.Tweening;
using UnityEngine.EventSystems;

namespace CampSite
{
    public class ShowInformationState : IStateBaseMine
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

        ButtonEvents buttonEvents;
        CampSiteHolder campSiteHolder;

        FeatureInformationPanelHolder featureInformationPanelHolder;
        ShowInformationStateData data;


        public ShowInformationState(ButtonEvents buttonEvents, CampSiteHolder campSiteHolder, ShowInformationStateData showPresentationDataStateData)
        {
            this.buttonEvents = buttonEvents;
            this.campSiteHolder = campSiteHolder;
            this.data = showPresentationDataStateData;
        }

        public void Init()
        {
            featureInformationPanelHolder = campSiteHolder.FeatureInformationPanelHolder;
            featureInformationPanelHolder.tweenForActivate.KillMine();
            featureInformationPanelHolder.tweenForActivate = featureInformationPanelHolder.canvasGroup.DOFade(1, data.fadeDuration).From(0).SetAutoKill(false).SetEase(data.fadeEase).Pause();
        }

        public void OnEnter()
        {
            buttonEvents.onPointerEnterEvent += OnPointerEnter;
            buttonEvents.onPointerExitEvent += OnPointerExit;
        }

        public void OnExit()
        {
            buttonEvents.onPointerEnterEvent -= OnPointerEnter;
            buttonEvents.onPointerExitEvent -= OnPointerExit;
        }

        public void OnLogic() { }

        void OnPointerEnter(PointerEventData eventData)
        {
            featureInformationPanelHolder.tweenForActivate.PlayForward();

            featureInformationPanelHolder.nameText.text = data.name;
            featureInformationPanelHolder.descriptionText.text = data.description;
            featureInformationPanelHolder.requirementsText.text = "Fill it later";
        }

        void OnPointerExit(PointerEventData eventData)
        {
            featureInformationPanelHolder.tweenForActivate.PlayBackwards();
        }
    }
}