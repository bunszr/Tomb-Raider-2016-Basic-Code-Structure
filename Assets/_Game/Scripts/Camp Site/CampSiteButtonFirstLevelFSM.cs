using UnityEngine;
using FSM;
using UnityEngine.EventSystems;

namespace CampSite
{
    public class CampSiteButtonFirstLevelFSM : CSBBaseFSM
    {
        CampSiteButtonFirstLevel campSiteButton;

        protected override void Start()
        {
            base.Start();
            campSiteButton = GetComponent<CampSiteButtonFirstLevel>();

            fsm = new StateMachine(this);
            fsm.AddState("ResetState", new ResetState(csbBase, true));
            fsm.AddState("ButtonAnimationState", new FirstLevelButtonAnimationState(csbBase, false, campSiteButton.buttonEvents, campSiteButton.buttonAnimationStateData));
            fsm.AddState("ClickState", new ClickState(csbBase, false, campSiteButton.clickStateData));

            fsm.AddTriggerTransition("OnClick", new Transition("ButtonAnimationState", "ClickState"));
            fsm.AddTransition(new Transition("ResetState", "ButtonAnimationState"));

            fsm.SetStartState("ResetState");
            fsm.Init();
        }
    }
}
