using Sirenix.OdinInspector;
using UniRx;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace CampSite
{
    public class CSBSkillFeatureController : CSBBaseController
    {
        CSBSkillFeature csbSkillFeature;
        FeatureTypeScriptable featureTypeScriptable;
        SkillFeatureTypeScriptable skillFeatureTypeScriptable;

        GameObject nextPanelTogglerGO => campSiteHolder.UpgradedPanel.gameObject;

        protected virtual void Start()
        {
            csbSkillFeature = csbBase.GetComponent<CSBSkillFeature>();

            featureTypeScriptable = csbSkillFeature.FeatureTypeScriptable;
            skillFeatureTypeScriptable = (SkillFeatureTypeScriptable)csbSkillFeature.FeatureTypeScriptable;

            ReactiveProperty<int> NumSkillPointRP = player.PlayerDataScriptable.NumSkillPointRP;

            AddCommand(new HighlightCommandView(csbBase, csbSkillFeature.highlightImage));
            AddCommand(new SkillInfoPanelCommandView(csbBase, campSiteHolder.skillInfoPanel.canvasGroup));
            AddCommand(new ShowFeatureInfoCommandView(csbBase, campSiteHolder.skillInfoPanel.skillInfoPanel.skillNameText, campSiteHolder.skillInfoPanel.skillInfoPanel.skillDescriptionText));
            AddCommand(new ShowAvailableNumSkillPointCommandView(csbBase, campSiteHolder.skillInfoPanel.availableSkillPanel.numSkillPointText, NumSkillPointRP));

            RequirementsCommandController requirementsStateController = new RequirementsCommandController(featureTypeScriptable,

                new ShowAndHighlightRequirementsCommandView(csbBase, campSiteHolder.skillInfoPanel.requirementSkillPanel.requirementText, featureTypeScriptable, csbSkillFeature.lockImage));

            ToggleCommandBasedOnFeatureState toggleCommandBasedOnFeatureState = new ToggleCommandBasedOnFeatureState(featureTypeScriptable,

                new SkillPointCostCommandView(csbBase, campSiteHolder.skillInfoPanel.skillCostPanel.numSkillPointText, NumSkillPointRP, csbSkillFeature.skillPointCostCommandViewData),
                new DisappearWithCanvasGroupCommandView(csbBase, campSiteHolder.skillInfoPanel.skillCostPanel.canvasGroup));

            UpgradedTickCommandController upgradedTickCommandController = new UpgradedTickCommandController(featureTypeScriptable,

                new ShowTickImageCommandView(csbBase, csbSkillFeature.tickImage.gameObject));

            AddCommand(requirementsStateController);
            AddCommand(toggleCommandBasedOnFeatureState);
            AddCommand(upgradedTickCommandController);

            commandExecuter = new CommandExecuterWithCondition(new ICSBExecute[]
            {
                new OpenNewPanelCommand(csbBase, nextPanelTogglerGO),
                new SpendSkillPointCommand(skillFeatureTypeScriptable, NumSkillPointRP),
                new UpgradedPanelDataSetterCommand(nextPanelTogglerGO, featureTypeScriptable),
                new SetFeatureTypeBoolToTrueCommand(featureTypeScriptable),
            },
                () => IsUpgrade());
        }

        [Button]
        bool IsUpgrade()
        {
            return !csbSkillFeature.FeatureTypeScriptable.IsOpenRP.Value && skillFeatureTypeScriptable.SkillCostAmount <= player.PlayerDataScriptable.NumSkillPointRP.Value && csbBase.FeatureTypeScriptable.AreRequirementsDone();
        }

        public override void OnPointerClick(PointerEventData eventData)
        {
            base.OnPointerClick(eventData);
            commandExecuter.ExecuteAll();
        }
    }
}