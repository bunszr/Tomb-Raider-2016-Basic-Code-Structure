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

            IStateBaseMine[] _stateBaseMines = new IStateBaseMine[]
            {
                new HighlightState(csbBase, cSBWeaponFeature.highlightStateData),
                new ShowWeaponDataState(csbBase, cSBWeaponFeature.showWeaponDataStateData),
                new ShowInformationState(csbBase, cSBWeaponFeature.showInformationState),
                new WeaponRotationState(csbBase, cSBWeaponFeature.weaponRotationStateData),
            };

            fsm.AddState("InitState", new InitState(this, true, brain));
            fsm.AddState("HighlightState", new ParalelState(this, false, _stateBaseMines));
            fsm.AddState("OpenNewFeatureState", new OpenNewFeatureState(this, false, cSBWeaponFeature.openNewFeatureStateData));

            fsm.AddTransition(new Transition("InitState", "HighlightState"));
            fsm.AddTriggerTransition("OnClick", new Transition("HighlightState", "OpenNewFeatureState"));

            fsm.SetStartState("InitState");
            fsm.Init();
        }
    }
}
