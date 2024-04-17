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
                new ShowWeaponDataState(csbBase, useless, cSBWeaponFeature.showWeaponDataStateData),
                new ShowInformationState(csbBase, useless, cSBWeaponFeature.showInformationState),
                new WeaponRotationState(csbBase, useless, cSBWeaponFeature.weaponRotationStateData),
            };

            if (!cSBWeaponFeature.FeatureTypeScriptable.IsOpen && csbBase.FeatureTypeScriptable.RequirementsScriptableBases.Any(x => !x.IsTrue()))
                stateBases.Add(new RequirementsState(csbBase, campSiteHolder.FeatureInformationPanelHolder.requirementsText));

            fsm.AddState("InitState", new InitState(csbBase, true, brain));
            fsm.AddState("HighlightState", new ParalelState(this, false, stateBases.ToArray()));
            fsm.AddState("OpenNewFeatureState", new OpenNewFeatureState(csbBase, false, cSBWeaponFeature.openNewFeatureStateData));

            fsm.AddTransition(new Transition("InitState", "HighlightState"));
            fsm.AddTriggerTransition("OnClick", new Transition("HighlightState", "OpenNewFeatureState"));

            fsm.SetStartState("InitState");
            fsm.Init();
        }
    }
}
