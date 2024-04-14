using DG.Tweening;
using FSM;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CampSite
{
    public class ShowSuppressorState : CSBParalelStateBase
    {
        Vector3 suppressorDefaultlocalPos;

        public ShowSuppressorState(MonoBehaviour mono) : base(mono) { }

        protected override void OnPointerEnter(PointerEventData eventData)
        {
            ISuppressorAddOn _suppressorAddOn = campSiteHolder._Weapon.Transform.GetComponent<ISuppressorAddOn>();
            suppressorDefaultlocalPos = _suppressorAddOn.SuppressorGO.transform.localPosition;
            _suppressorAddOn.SuppressorGO.SetActive(true);
            _suppressorAddOn.SuppressorGO.transform.DOLocalMoveZ(.5f, .4f).From(true);
        }

        protected override void OnPointerExit(PointerEventData eventData)
        {
            ISuppressorAddOn _suppressorAddOn = campSiteHolder._Weapon.Transform.GetComponent<ISuppressorAddOn>();
            _suppressorAddOn.SuppressorGO.transform.DOKill();
            _suppressorAddOn.SuppressorGO.SetActive(false);
            _suppressorAddOn.SuppressorGO.transform.localPosition = suppressorDefaultlocalPos;
        }
    }
}