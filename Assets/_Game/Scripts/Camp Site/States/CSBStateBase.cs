using FSM;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CampSite
{
    public abstract class CSBStateBase : StateBase
    {
        protected MonoBehaviour mono;
        protected Transform transform => mono.transform;
        protected CampSiteButtonBase csbBase;
        protected ButtonEvents buttonEvents;
        protected CampSiteHolder campSiteHolder;

        protected CSBStateBase(MonoBehaviour mono, bool needsExitTime, bool isGhostState = false) : base(needsExitTime, isGhostState)
        {
            this.mono = mono;
            this.csbBase = mono.GetComponent<CampSiteButtonBase>();
            this.buttonEvents = csbBase.buttonEvents;
            campSiteHolder = csbBase.campSiteHolder;
        }

        protected void SubcribeButtonEvents()
        {
            buttonEvents.onPointerEnterEvent += OnPointerEnter;
            buttonEvents.onPointerExitEvent += OnPointerExit;
        }

        protected void UnSubcribeButtonEvents()
        {
            buttonEvents.onPointerEnterEvent -= OnPointerEnter;
            buttonEvents.onPointerExitEvent -= OnPointerExit;
        }

        protected virtual void OnPointerEnter(PointerEventData eventData) { }
        protected virtual void OnPointerExit(PointerEventData eventData) { }
    }
}