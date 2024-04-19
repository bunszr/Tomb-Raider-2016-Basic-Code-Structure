using UnityEngine;
using FSM;
using UnityEngine.EventSystems;
using Zenject;
using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

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
                new ShowCostDataState(csbBase),
            };

            if (!cSBWeaponFeature.FeatureTypeScriptable.IsOpen && csbBase.FeatureTypeScriptable.RequirementsScriptableBases.Any(x => !x.IsTrue()))
                stateBases.Add(new RequirementsState(csbBase, campSiteHolder.FeatureInformationPanelHolder.requirementsText));

            fsm.AddState("InitState", new InitState(csbBase, true, brain));
            fsm.AddState("HighlightState", new ParalelState(this, false, stateBases.ToArray()));
            fsm.AddState("UpgradeWeaponCommonDataState", new UpgradeWeaponCommonDataState(csbBase, cSBWeaponFeature.weaponDataScriptable, false));
            fsm.AddState("ShowUpgradedFeatureState", new ShowUpgradedFeatureState(csbBase, true));

#if UNITY_EDITOR
            fsm.AddTransition(new Transition("HighlightState", "ShowUpgradedFeatureState", x => test, true));
#endif

            fsm.AddTransition(new Transition("InitState", "HighlightState"));
            fsm.AddTriggerTransition("OnClick", new Transition("HighlightState", "UpgradeWeaponCommonDataState", x => IsUpgrade()));
            fsm.AddTransition(new Transition("UpgradeWeaponCommonDataState", "ShowUpgradedFeatureState", null, true));
            fsm.AddTransition(new Transition("ShowUpgradedFeatureState", "HighlightState"));

            fsm.SetStartState("InitState");
            fsm.Init();
        }

        public bool test;

        bool IsUpgrade()
        {
            // Debug.LogError(csbBase.FeatureTypeScriptable.RequirementsScriptableBases.All(x => x.IsTrue()));
            bool b = !cSBWeaponFeature.FeatureTypeScriptable.IsOpen && csbBase.FeatureTypeScriptable.RequirementsScriptableBases.All(x => x.IsTrue());
            // Debug.Log(b, csbBase);
            return b && Input.GetMouseButtonDown(0);
        }
    }
}
