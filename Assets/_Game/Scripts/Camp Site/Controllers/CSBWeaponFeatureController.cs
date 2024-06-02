using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CampSite
{
    public class CSBWeaponFeatureController : CSBBaseController
    {
        CSBWeaponFeature csbWeaponFeature;
        WeaponFeatureTypeScriptable weaponFeatureTypeScriptable;

        GameObject nextPanelTogglerGO => campSiteHolder.UpgradedPanel.gameObject;

        protected virtual void Start()
        {
            csbWeaponFeature = csbBase.GetComponent<CSBWeaponFeature>();

            FeatureTypeScriptable featureTypeScriptable = csbWeaponFeature.FeatureTypeScriptable;
            weaponFeatureTypeScriptable = (WeaponFeatureTypeScriptable)csbWeaponFeature.FeatureTypeScriptable;

            AddCommand(new HighlightCommandView(csbBase, csbWeaponFeature.highlightImage));
            AddCommand(new ShowWeaponDataCommandView(csbBase, csbWeaponFeature.weaponDataScriptable, campSiteHolder.WeaponDataSliderHolder));
            AddCommand(new ShowFeatureInfoCommandView(csbBase, campSiteHolder.weaponPanelData.featureNameText, campSiteHolder.weaponPanelData.featureDescriptionText));
            AddCommand(new CanvasGroupAndPosAnimationCommandView(csbBase, campSiteHolder.weaponPanelData.featureInfoPanelCanvasGroup, csbWeaponFeature.canvasGroupAndPosAnimationCommandViewData));
            AddCommand(new WeaponRotationCommandView(csbBase, csbWeaponFeature.weaponRotationStateData, campSiteHolder));

            RequirementsCommandController requirementsStateController = new RequirementsCommandController(featureTypeScriptable,

                new ShowAndHighlightRequirementsCommandView(csbBase, campSiteHolder.FeatureInformationPanelHolder.requirementsText, featureTypeScriptable, csbWeaponFeature.lockImage));

            ToggleCommandBasedOnFeatureState toggleCommandBasedOnFeatureState = new ToggleCommandBasedOnFeatureState(featureTypeScriptable,

                new ShowCostDataCommandView(csbBase, campSiteHolder.CostAndInventoryPanel, weaponFeatureTypeScriptable, csbWeaponFeature.featureNameText),
                new ShowOnlyCostDataCommandView(csbBase, campSiteHolder.CostAndInventoryPanel));

            RunCommandWhenFeatureIsOpenCommand upgradedTickCommandController = new RunCommandWhenFeatureIsOpenCommand(featureTypeScriptable,

                new ShowTickImageCommandView(csbBase, csbWeaponFeature.tickImage.gameObject));

            AddCommand(requirementsStateController);
            AddCommand(toggleCommandBasedOnFeatureState);
            AddCommand(upgradedTickCommandController);

            commandExecuter = new CommandExecuterWithCondition(new ICSBExecute[]
            {
                new PanelTogglerCommand(csbBase, nextPanelTogglerGO, campSiteHolder.CSUndoCommandExecuter),
                new BuyInventoryItemCommand(weaponFeatureTypeScriptable),
                new UpgradeCommonWeaponDataCommand(csbWeaponFeature.weaponDataScriptable, weaponFeatureTypeScriptable),
                new UpgradedPanelDataSetterCommand(nextPanelTogglerGO, featureTypeScriptable),
                new SetFeatureTypeBoolToTrueCommand(featureTypeScriptable),
            },
                () => IsUpgrade());
        }

        [Button]
        bool IsUpgrade()
        {
            return !csbWeaponFeature.FeatureTypeScriptable.IsOpenRP.Value && weaponFeatureTypeScriptable.HasEnoughQuantityToBuy() && csbBase.FeatureTypeScriptable.AreRequirementsDone();
        }

        public override void OnPointerClick(PointerEventData eventData)
        {
            base.OnPointerClick(eventData);
            commandExecuter.ExecuteAll();
        }
    }
}