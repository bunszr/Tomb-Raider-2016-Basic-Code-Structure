using Cinemachine;
using FSM;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace CampSite
{
    public abstract class CSBBase : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
    {
        [SerializeField, Required("Feature Type is nessessary for this component.")]
        FeatureTypeScriptable featureTypeScriptable;


        [Inject, HideInInspector] public CampSiteHolder campSiteHolder;
        [Inject, HideInInspector] public CinemachineBrain brain;

        public ButtonEvents buttonEvents = new ButtonEvents();

        public FeatureTypeScriptable FeatureTypeScriptable => featureTypeScriptable;

        public void OnPointerEnter(PointerEventData eventData) => buttonEvents.onPointerEnterEvent?.Invoke(eventData);
        public void OnPointerExit(PointerEventData eventData) => buttonEvents.onPointerExitEvent?.Invoke(eventData);
        public void OnPointerClick(PointerEventData eventData) => buttonEvents.onPointerClickEvent?.Invoke(eventData);
    }
}