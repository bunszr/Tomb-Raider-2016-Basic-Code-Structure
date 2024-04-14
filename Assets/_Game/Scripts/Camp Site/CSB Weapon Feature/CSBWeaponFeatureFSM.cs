using UnityEngine;
using FSM;
using UnityEngine.EventSystems;
using Zenject;
using Cinemachine;
using System.Collections;

namespace CampSite
{
    public class CSBWeaponFeatureFSM : MonoBehaviour
    {
        CSBWeaponFeature cSBWeaponFeature;
        StateMachine fsm;

        [Inject] CinemachineBrain brain;
        [Inject] CampSiteHolder campSiteHolder;

        protected void Start()
        {
            cSBWeaponFeature = GetComponent<CSBWeaponFeature>();

            IStateBaseMine[] _stateBaseMines = new IStateBaseMine[]
            {
                new HighlightState(this, false, cSBWeaponFeature.buttonEvents, cSBWeaponFeature.highlightStateData),
                new ShowWeaponDataState(cSBWeaponFeature.buttonEvents, campSiteHolder, cSBWeaponFeature.showWeaponDataStateData, cSBWeaponFeature.FeatureTypeScriptable),
                new ShowInformationState(cSBWeaponFeature.buttonEvents, campSiteHolder, cSBWeaponFeature.showInformationState),
                new WeaponRotationState(cSBWeaponFeature.buttonEvents, campSiteHolder, cSBWeaponFeature.weaponRotationStateData),
            };

            fsm = new StateMachine(this);
            fsm.AddState("InitState", new InitState(this, true, brain));
            fsm.AddState("HighlightState", new ParalelState(this, false, _stateBaseMines));
            fsm.AddState("OpenNewFeatureState", new OpenNewFeatureState(this, false, cSBWeaponFeature.openNewFeatureStateData));

            fsm.AddTransition(new Transition("InitState", "HighlightState"));
            fsm.AddTriggerTransition("OnClick", new Transition("HighlightState", "OpenNewFeatureState"));

            fsm.SetStartState("InitState");
            fsm.Init();
        }

        private void OnEnable()
        {
            StartCoroutine(MethodCO());
        }

        IEnumerator MethodCO()
        {
            yield return null;
            cSBWeaponFeature.buttonEvents.onPointerClickEvent += OnPointerClick;

        }

        private void OnDisable()
        {
            cSBWeaponFeature.buttonEvents.onPointerClickEvent -= OnPointerClick;
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
