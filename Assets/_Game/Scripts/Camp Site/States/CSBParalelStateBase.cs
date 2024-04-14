using FSM;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CampSite
{
    public abstract class CSBParalelStateBase : IStateBaseMine
    {
        protected ButtonEvents buttonEvents;
        protected MonoBehaviour mono;
        protected CampSiteButtonBase csbBase;
        protected CampSiteHolder campSiteHolder;

        protected Transform transform => mono.transform;

        protected CSBParalelStateBase(MonoBehaviour mono)
        {
            this.mono = mono;
            csbBase = mono.GetComponent<CampSiteButtonBase>();
            this.buttonEvents = csbBase.buttonEvents;
            campSiteHolder = csbBase.campSiteHolder;
        }

        public virtual void Init()
        {
        }

        public virtual void OnEnter()
        {
            buttonEvents.onPointerEnterEvent += OnPointerEnter;
            buttonEvents.onPointerExitEvent += OnPointerExit;
        }

        public virtual void OnExit()
        {
            buttonEvents.onPointerEnterEvent -= OnPointerEnter;
            buttonEvents.onPointerExitEvent -= OnPointerExit;
        }

        protected virtual void OnPointerEnter(PointerEventData eventData)
        {
        }

        protected virtual void OnPointerExit(PointerEventData eventData)
        {
        }
    }
}