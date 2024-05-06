using UnityEngine.EventSystems;

namespace CampSite
{
    public class CampsiteButtonCommandBase : ICSBActivateable
    {
        protected CampSiteButtonBase csbBase;
        protected ButtonEvents buttonEvents => csbBase.buttonEvents;

        public CampsiteButtonCommandBase(CampSiteButtonBase csbBase) => this.csbBase = csbBase;

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