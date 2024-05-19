using UnityEngine.EventSystems;

namespace CampSite
{
    public class CampsiteButtonCommandBase : ICSBActivateable
    {
        protected CSBBase csbBase;
        protected ButtonEvents buttonEvents => csbBase.buttonEvents;

        bool hasEnter;
        bool hasExit;

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

            if (hasEnter && !hasExit) OnPointerExit(new PointerEventData(EventSystem.current)); // To prevent OnPointerExit is not called If pressed Esc key to close panel and mouse is over UI element
        }

        protected virtual void OnPointerEnter(PointerEventData eventData) { hasEnter = true; hasExit = false; }
        protected virtual void OnPointerExit(PointerEventData eventData) { hasEnter = false; hasExit = true; }
    }
}