using FSM;

namespace CampSite
{
    public class CSBFirstLevelFSM : CSBBaseFSM
    {
        CSBFirstLevel csbFirstLevel;

        protected override void Start()
        {
            base.Start();
            csbFirstLevel = GetComponent<CSBFirstLevel>();

            fsm = new StateMachine(this) { stateMachineDebug = csbBase.stateMachineDebug };

            fsm.AddState("FirstLevelButtonAnimationState", new FirstLevelButtonAnimationState(csbBase, csbFirstLevel.cam, false));
            fsm.AddState("OpenNewPanelState", new OpenNewPanelState(csbBase, csbFirstLevel.nextPanelTogglerGO));

            fsm.AddTriggerTransition("OnClick", new Transition("FirstLevelButtonAnimationState", "OpenNewPanelState"));
            fsm.AddTransition(new Transition("OpenNewPanelState", "FirstLevelButtonAnimationState", null, true));

            fsm.SetStartState("FirstLevelButtonAnimationState");
            fsm.Init();
        }
    }
}
