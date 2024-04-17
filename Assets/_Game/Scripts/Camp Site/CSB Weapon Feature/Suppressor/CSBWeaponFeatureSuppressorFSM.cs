using System.Collections.Generic;
using System.Linq;
using FSM;

namespace CampSite
{
    public class CSBWeaponFeatureSuppressorFSM : CSBBaseFSM
    {
        CSBWeaponFeatureSuppressor cSBWeaponFeatureSuppressor;

        protected override void Start()
        {
            base.Start();

            cSBWeaponFeatureSuppressor = GetComponent<CSBWeaponFeatureSuppressor>();

            bool useless = true;
            List<StateBase> stateBases = new List<StateBase>()
            {
                new HighlightState(csbBase, useless, cSBWeaponFeatureSuppressor.highlightStateData),
                new ShowInformationState(csbBase, useless, cSBWeaponFeatureSuppressor.showInformationState),
                new WeaponRotationState(csbBase, useless, cSBWeaponFeatureSuppressor.weaponRotationStateData),
                new ShowSuppressorState(csbBase, useless),
            };

            if (!cSBWeaponFeatureSuppressor.FeatureTypeScriptable.IsOpen && csbBase.FeatureTypeScriptable.RequirementsScriptableBases.Any(x => !x.IsTrue()))
                stateBases.Add(new RequirementsState(csbBase, campSiteHolder.FeatureInformationPanelHolder.requirementsText));

            fsm.AddState("InitState", new InitState(csbBase, true, brain));
            fsm.AddState("HighlightState", new ParalelState(this, false, stateBases.ToArray()));
            fsm.AddState("OpenNewFeatureState", new OpenNewFeatureState(csbBase, false, cSBWeaponFeatureSuppressor.openNewFeatureStateData));

            fsm.AddTransition(new Transition("InitState", "HighlightState"));
            fsm.AddTriggerTransition("OnClick", new Transition("HighlightState", "OpenNewFeatureState"));

            fsm.SetStartState("InitState");
            fsm.Init();
        }
    }
}