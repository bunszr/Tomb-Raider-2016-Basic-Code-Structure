using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace CampSite
{
    public abstract class CampSiteButtonBase : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
    {
        [SerializeField, Required("MyMesh is nessessary for this component.")]
        FeatureTypeScriptable featureTypeScriptable;
        public ButtonEvents buttonEvents = new ButtonEvents();

        [Inject, HideInInspector] public CampSiteHolder campSiteHolder;

        public FeatureTypeScriptable FeatureTypeScriptable => featureTypeScriptable;

        public void OnPointerEnter(PointerEventData eventData) => buttonEvents.onPointerEnterEvent?.Invoke(eventData);
        public void OnPointerExit(PointerEventData eventData) => buttonEvents.onPointerExitEvent?.Invoke(eventData);
        public void OnPointerClick(PointerEventData eventData) => buttonEvents.onPointerClickEvent?.Invoke(eventData);
    }
}