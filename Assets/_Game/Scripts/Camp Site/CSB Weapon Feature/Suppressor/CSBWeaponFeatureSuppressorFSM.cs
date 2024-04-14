using UnityEngine;
using FSM;
using UnityEngine.EventSystems;
using Zenject;
using Cinemachine;
using System.Collections;

namespace CampSite
{
    public class CSBWeaponFeatureSuppressorFSM : MonoBehaviour
    {
        CSBWeaponFeatureSuppressor cSBWeaponFeatureSuppressor;
        StateMachine fsm;

        [Inject] CinemachineBrain brain;
        [Inject] CampSiteHolder campSiteHolder;

        protected void Start()
        {
            cSBWeaponFeatureSuppressor = GetComponent<CSBWeaponFeatureSuppressor>();

            IStateBaseMine[] _stateBaseMines = new IStateBaseMine[]
            {
                new HighlightState(this, false, cSBWeaponFeatureSuppressor.buttonEvents, cSBWeaponFeatureSuppressor.highlightStateData),
                new ShowInformationState(cSBWeaponFeatureSuppressor.buttonEvents, campSiteHolder, cSBWeaponFeatureSuppressor.showInformationState),
                new WeaponRotationState(cSBWeaponFeatureSuppressor.buttonEvents, campSiteHolder, cSBWeaponFeatureSuppressor.weaponRotationStateData),
                new ShowSuppressorState(cSBWeaponFeatureSuppressor.buttonEvents, campSiteHolder),
            };

            fsm = new StateMachine(this);
            fsm.AddState("InitState", new InitState(this, true, brain));
            fsm.AddState("HighlightState", new ParalelState(this, false, _stateBaseMines));
            fsm.AddState("OpenNewFeatureState", new OpenNewFeatureState(this, false, cSBWeaponFeatureSuppressor.openNewFeatureStateData));

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
            cSBWeaponFeatureSuppressor.buttonEvents.onPointerClickEvent += OnPointerClick;

        }

        private void OnDisable()
        {
            cSBWeaponFeatureSuppressor.buttonEvents.onPointerClickEvent -= OnPointerClick;
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
