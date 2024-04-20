using FSM;
using UniRx;
using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using UnityEngine;

namespace CampSite
{
    public class CSBWeaponFeatureFSM : CSBBaseFSM
    {
        CSBWeaponFeature cSBWeaponFeature;

        protected override void Start()
        {
            base.Start();

            cSBWeaponFeature = GetComponent<CSBWeaponFeature>();

            bool useless = true;
            List<StateBase> stateBases = new List<StateBase>()
            {
                new HighlightState(csbBase, useless, cSBWeaponFeature.highlightStateData),
                new ShowWeaponDataState(csbBase, cSBWeaponFeature.weaponDataScriptable),
                new ShowInformationState(csbBase, useless, cSBWeaponFeature.showInformationState),
                new WeaponRotationState(csbBase, useless, cSBWeaponFeature.weaponRotationStateData),
            };

            if (!csbBase.FeatureTypeScriptable.IsOpenRP.Value)
            {
                if (!csbBase.FeatureTypeScriptable.AreRequirementsDone()) stateBases.Add(new RequirementsState(csbBase, campSiteHolder.FeatureInformationPanelHolder.requirementsText));
                stateBases.Add(new ShowCostDataState(csbBase));
            }
            else stateBases.Add(new ShowOnlyCostDataState(csbBase));

            StateBase[] stateBasesAfterUpgrading = new StateBase[]
            {
                new HighlightState(csbBase, useless, cSBWeaponFeature.highlightStateData),
                new ShowWeaponDataState(csbBase, cSBWeaponFeature.weaponDataScriptable),
                new ShowInformationState(csbBase, useless, cSBWeaponFeature.showInformationState),
                new WeaponRotationState(csbBase, useless, cSBWeaponFeature.weaponRotationStateData),
                new ShowOnlyCostDataState(csbBase),
            };

            StateBase[] paralelUpgradingStates = new StateBase[]
            {
                new UpgradeWeaponCommonDataState(csbBase, cSBWeaponFeature.weaponDataScriptable, false),
                new BuyInventoryItemState(csbBase, cSBWeaponFeature.weaponDataScriptable, false),
            };

            fsm.AddState("InitState", new InitState(csbBase, true, brain));
            fsm.AddState("HighlightState", new ParalelState(stateBases.ToArray(), false));
            fsm.AddState("UpgradeState", new ParalelState(paralelUpgradingStates, false, true));
            fsm.AddState("ShowUpgradedFeatureState", new ShowUpgradedFeatureState(csbBase, true));
            fsm.AddState("HighlightStateAfterUpgrading", new ParalelState(stateBasesAfterUpgrading, false));

#if UNITY_EDITOR
            fsm.AddTransition(new Transition("HighlightState", "ShowUpgradedFeatureState", x => test, true));
#endif

            fsm.AddTransition(new Transition("InitState", "HighlightState"));
            fsm.AddTriggerTransition("OnClick", new Transition("HighlightState", "UpgradeState", x => IsUpgrade()));
            fsm.AddTransition(new Transition("UpgradeState", "ShowUpgradedFeatureState"));
            fsm.AddTransition(new Transition("ShowUpgradedFeatureState", "HighlightStateAfterUpgrading"));

            fsm.SetStartState("InitState");
            fsm.Init();
        }

        public bool test;

        [Button]
        bool IsUpgrade()
        {
            return !cSBWeaponFeature.FeatureTypeScriptable.IsOpenRP.Value && (csbBase.FeatureTypeScriptable as WeaponFeatureTypeScriptable).HasEnoughQuantityToBuy() && csbBase.FeatureTypeScriptable.AreRequirementsDone();
        }
    }
}
