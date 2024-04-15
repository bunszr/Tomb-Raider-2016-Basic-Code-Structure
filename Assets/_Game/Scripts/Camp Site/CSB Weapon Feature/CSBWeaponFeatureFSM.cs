using UnityEngine;
using FSM;
using UnityEngine.EventSystems;
using Zenject;
using Cinemachine;
using System.Collections;

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
            StateBase[] stateBases = new StateBase[]
            {
                new HighlightState(csbBase, useless, cSBWeaponFeature.highlightStateData),
                new ShowWeaponDataState(csbBase, useless, cSBWeaponFeature.showWeaponDataStateData),
                new ShowInformationState(csbBase, useless, cSBWeaponFeature.showInformationState),
                new WeaponRotationState(csbBase, useless, cSBWeaponFeature.weaponRotationStateData),
            };

            fsm.AddState("InitState", new InitState(csbBase, true, brain));
            fsm.AddState("HighlightState", new ParalelState(this, false, stateBases));
            fsm.AddState("OpenNewFeatureState", new OpenNewFeatureState(csbBase, false, cSBWeaponFeature.openNewFeatureStateData));

            fsm.AddTransition(new Transition("InitState", "HighlightState"));
            fsm.AddTriggerTransition("OnClick", new Transition("HighlightState", "OpenNewFeatureState"));

            fsm.SetStartState("InitState");
            fsm.Init();
        }
    }
}
