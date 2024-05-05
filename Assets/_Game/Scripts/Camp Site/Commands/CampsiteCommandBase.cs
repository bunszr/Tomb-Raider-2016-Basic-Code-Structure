using UnityEngine.EventSystems;

namespace CampSite
{
    public class CampsiteCommandBase : ICSBActivateable
    {
        protected CampSiteButtonBase csbBase;
        protected ButtonEvents buttonEvents => csbBase.buttonEvents;

        public CampsiteCommandBase(CampSiteButtonBase csbBase) => this.csbBase = csbBase;

        public virtual void OnActivate()
        {
            buttonEvents.onPointerEnterEvent += OnPointerEnter;
            buttonEvents.onPointerExitEvent += OnPointerExit;
        }

        public virtual void OnDeactivate()
        {
            buttonEvents.onPointerEnterEvent -= OnPointerEnter;
            buttonEvents.onPointerExitEvent -= OnPointerExit;
        }

        protected virtual void OnPointerEnter(PointerEventData eventData) { }
        protected virtual void OnPointerExit(PointerEventData eventData) { }
    }
}