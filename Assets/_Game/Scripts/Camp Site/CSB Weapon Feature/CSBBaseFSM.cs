using UnityEngine;
using FSM;
using UnityEngine.EventSystems;
using Zenject;
using Cinemachine;
using System.Collections;

namespace CampSite
{
    public abstract class CSBBaseFSM : MonoBehaviour
    {
        protected CampSiteButtonBase csbBase;
        protected StateMachine fsm;

        [Inject] protected CinemachineBrain brain;
        [Inject] protected CampSiteHolder campSiteHolder;

        protected virtual void Awake()
        {
            csbBase = GetComponent<CampSiteButtonBase>();
            fsm = new StateMachine(this);
        }

        protected virtual void Start() { }
        protected virtual void OnEnable() => csbBase.buttonEvents.onPointerClickEvent += OnPointerClick;
        protected virtual void OnDisable() => csbBase.buttonEvents.onPointerClickEvent -= OnPointerClick;
        private void Update() => fsm.OnLogic();
        public void OnPointerClick(PointerEventData eventData) => fsm.Trigger("OnClick");
    }
}
