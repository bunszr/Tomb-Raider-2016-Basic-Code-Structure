using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace CampSite
{
    public abstract class CampSiteButtonBase : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
    {

        public ButtonEvents buttonEvents = new ButtonEvents();

        [Inject, HideInInspector] public CampSiteHolder campSiteHolder;


        public void OnPointerEnter(PointerEventData eventData) => buttonEvents.onPointerEnterEvent?.Invoke(eventData);
        public void OnPointerExit(PointerEventData eventData) => buttonEvents.onPointerExitEvent?.Invoke(eventData);
        public void OnPointerClick(PointerEventData eventData) => buttonEvents.onPointerClickEvent?.Invoke(eventData);
    }
}