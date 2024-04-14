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

            IStateBaseMine[] _stateBaseMines = new IStateBaseMine[]
            {
                new HighlightState(csbBase, cSBWeaponFeatureSuppressor.highlightStateData),
                new ShowInformationState(csbBase, cSBWeaponFeatureSuppressor.showInformationState),
                new WeaponRotationState(csbBase, cSBWeaponFeatureSuppressor.weaponRotationStateData),
                new ShowSuppressorState(csbBase),
            };

            fsm.AddState("InitState", new InitState(this, true, brain));
            fsm.AddState("HighlightState", new ParalelState(this, false, _stateBaseMines));
            fsm.AddState("OpenNewFeatureState", new OpenNewFeatureState(this, false, cSBWeaponFeatureSuppressor.openNewFeatureStateData));

            fsm.AddTransition(new Transition("InitState", "HighlightState"));
            fsm.AddTriggerTransition("OnClick", new Transition("HighlightState", "OpenNewFeatureState"));

            fsm.SetStartState("InitState");
            fsm.Init();
        }
    }
}