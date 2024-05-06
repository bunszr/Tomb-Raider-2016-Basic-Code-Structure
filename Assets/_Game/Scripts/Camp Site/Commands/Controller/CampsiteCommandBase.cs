using UnityEngine.EventSystems;

namespace CampSite
{
    public class CampsiteButtonCommandBase : ICSBActivateable
    {
        protected CSBBase csbBase;
        protected ButtonEvents buttonEvents => csbBase.buttonEvents;

        public CampsiteButtonCommandBase(CSBBase csbBase) => this.csbBase = csbBase;

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