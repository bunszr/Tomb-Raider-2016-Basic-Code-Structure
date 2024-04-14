using UnityEngine;
using FSM;
using UnityEngine.EventSystems;

namespace CampSite
{
    public class CampSiteButtonFirstLevelFSM : MonoBehaviour
    {
        CampSiteButtonFirstLevel campSiteButton;
        StateMachine fsm;

        protected void Awake()
        {
            campSiteButton = GetComponent<CampSiteButtonFirstLevel>();

            fsm = new StateMachine(this);
            fsm.AddState("ResetState", new ResetState(this, true));
            fsm.AddState("ButtonAnimationState", new ButtonAnimationState(this, false, campSiteButton.buttonEvents, campSiteButton.buttonAnimationStateData));
            fsm.AddState("ClickState", new ClickState(this, false, campSiteButton.clickStateData));

            fsm.AddTriggerTransition("OnClick", new Transition("ButtonAnimationState", "ClickState"));
            fsm.AddTransition(new Transition("ResetState", "ButtonAnimationState"));

            fsm.SetStartState("ResetState");
            fsm.Init();
        }

        private void OnEnable()
        {
            campSiteButton.buttonEvents.onPointerClickEvent += OnPointerClick;
        }

        private void OnDisable()
        {
            campSiteButton.buttonEvents.onPointerClickEvent -= OnPointerClick;
        }

        private void Update()
        {
            fsm.OnLogic();
        }

        void OnPointerClick(PointerEventData eventData)
        {
            fsm.Trigger("OnClick");
        }
    }
}
