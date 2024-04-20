using Cinemachine;
using DG.Tweening;
using UnityEngine;

namespace CampSite
{
    public class ShowUpgradedFeatureState : CSBStateBase
    {
        bool hasExit = false;

        public ShowUpgradedFeatureState(MonoBehaviour mono, bool needsExitTime, bool isGhostState = false) : base(mono, needsExitTime, isGhostState) { }

        GameDataScriptable.CampSiteScriptableData.ShowUpgradedFeatureStateScriptableData ScriptableData => GameDataScriptable.Ins.campSiteScriptableData.showUpgradedFeatureStateScriptableData;

        public override void Init() { }

        public override void OnEnter()
        {
            hasExit = false;

            csbBase.FeatureTypeScriptable.IsOpenRP.Value = true;
            csbBase.GetComponent<CSBFeatureBase>().upgradedIndicatorImage.gameObject.SetActive(true);

            CanvasGroup upgradeGroup = campSiteHolder.UpgradedPanel.canvasGroup;

            CanvasGroup currCanvasGroup = transform.GetComponentInParent<Canvas>().GetComponent<CanvasGroup>();
            currCanvasGroup.blocksRaycasts = false;
            currCanvasGroup.interactable = false;

            campSiteHolder.UpgradedPanel.virtualCamera.Priority = csbBase.brain.ActiveVirtualCamera.Priority + 1;

            DOTween.Sequence()
                .Append(currCanvasGroup.DOFade(0, ScriptableData.fadeInDuration))
                .Join(upgradeGroup.DOFade(1, ScriptableData.fadeOutDuration).From(0))
                .Join(upgradeGroup.transform.DOLocalMoveY(ScriptableData.yAnimationAmount, ScriptableData.yAnimationDuration).SetEase(ScriptableData.yAnimEase).From(true))
                .AppendInterval(ScriptableData.stateDuration)
                .AppendCallback(() =>
                {
                    campSiteHolder.UpgradedPanel.virtualCamera.Priority -= 2;
                })
                .Append(currCanvasGroup.DOFade(1, ScriptableData.fadeOutDuration))
                .Append(upgradeGroup.DOFade(0, ScriptableData.fadeInDuration))
                .AppendCallback(() =>
                {
                    currCanvasGroup.blocksRaycasts = true;
                    currCanvasGroup.interactable = true;
                    hasExit = true;
                });


            campSiteHolder.UpgradedPanel.nameText.text = csbBase.FeatureTypeScriptable.FeatureName;
            campSiteHolder.UpgradedPanel.descriptionText.text = csbBase.FeatureTypeScriptable.Description;
        }

        public override void OnLogic()
        {
            if (hasExit) fsm.StateCanExit();
        }
    }
}