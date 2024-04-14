using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CampSite
{
    public class ShowSuppressorState : IStateBaseMine
    {
        ButtonEvents buttonEvents;
        CampSiteHolder campSiteHolder;
        Vector3 suppressorDefaultlocalPos;

        public ShowSuppressorState(ButtonEvents buttonEvents, CampSiteHolder campSiteHolder)
        {
            this.buttonEvents = buttonEvents;
            this.campSiteHolder = campSiteHolder;
        }

        public void Init()
        {
        }

        public void OnEnter()
        {
            buttonEvents.onPointerEnterEvent += OnPointerEnter;
            buttonEvents.onPointerExitEvent += OnPointerExit;
        }

        public void OnExit()
        {
            buttonEvents.onPointerEnterEvent -= OnPointerEnter;
            buttonEvents.onPointerExitEvent -= OnPointerExit;
        }

        void OnPointerEnter(PointerEventData eventData)
        {
            ISuppressorAddOn _suppressorAddOn = campSiteHolder._Weapon.Transform.GetComponent<ISuppressorAddOn>();
            suppressorDefaultlocalPos = _suppressorAddOn.SuppressorGO.transform.localPosition;
            _suppressorAddOn.SuppressorGO.SetActive(true);
            _suppressorAddOn.SuppressorGO.transform.DOLocalMoveZ(.5f, .4f).From(true);
        }

        void OnPointerExit(PointerEventData eventData)
        {
            ISuppressorAddOn _suppressorAddOn = campSiteHolder._Weapon.Transform.GetComponent<ISuppressorAddOn>();
            _suppressorAddOn.SuppressorGO.transform.DOKill();
            _suppressorAddOn.SuppressorGO.SetActive(false);
            _suppressorAddOn.SuppressorGO.transform.localPosition = suppressorDefaultlocalPos;
        }

        public void OnLogic()
        {
        }

    }
}