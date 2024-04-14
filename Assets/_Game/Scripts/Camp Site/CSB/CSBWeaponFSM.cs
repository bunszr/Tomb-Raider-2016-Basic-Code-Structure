using UnityEngine;
using FSM;
using UnityEngine.EventSystems;
using Zenject;
using Cinemachine;

namespace CampSite
{
    public class CSBWeaponFSM : MonoBehaviour
    {
        CSBWeapon cSBWeapon;
        StateMachine fsm;

        [Inject] CinemachineBrain brain;
        [Inject] private DiContainer _container;

        protected void Awake()
        {
            cSBWeapon = GetComponent<CSBWeapon>();

            // cSBWeaponFeature.weaponDataSliderHolder, _weaponToggler.GetWeapons().FirstOrDefault(x => x.WeaponTypeScriptable == cSBWeaponFeature.we

            fsm = new StateMachine(this);
            fsm.AddState("InitState", new InitState(this, true, brain));
            fsm.AddState("HighlightState", new HighlightState(this, false, cSBWeapon.buttonEvents, cSBWeapon.highlightStateData));
            fsm.AddState("ClickState", new ClickState(this, false, cSBWeapon.clickStateData));

            fsm.AddTransition(new Transition("InitState", "HighlightState"));
            fsm.AddTriggerTransition("OnClick", new Transition("HighlightState", "ClickState"));

            fsm.SetStartState("InitState");
            fsm.Init();
        }

        private void OnEnable()
        {
            cSBWeapon.buttonEvents.onPointerClickEvent += OnPointerClick;
        }

        private void OnDisable()
        {
            cSBWeapon.buttonEvents.onPointerClickEvent -= OnPointerClick;
        }

        private void Update()
        {
            fsm.OnLogic();
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            fsm.Trigger("OnClick");
        }
    }
}
