using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CampSite
{
    public class ShowSuppressorCommandView : CampsiteButtonCommandBase
    {
        GameObject weaponHolder;
        Vector3 suppressorDefaultlocalPos;

        public ShowSuppressorCommandView(CSBBase csbBase, GameObject weaponHolder) : base(csbBase)
        {
            this.weaponHolder = weaponHolder;
        }

        protected override void OnPointerEnter(PointerEventData eventData)
        {
            base.OnPointerEnter(eventData);
            ISuppressorAddOn _suppressorAddOn = weaponHolder.GetComponentInChildren<ISuppressorAddOn>();
            suppressorDefaultlocalPos = _suppressorAddOn.SuppressorGO.transform.localPosition;
            _suppressorAddOn.SuppressorGO.SetActive(true);
            _suppressorAddOn.SuppressorGO.transform.DOLocalMoveZ(.5f, .4f).From(true);
        }

        protected override void OnPointerExit(PointerEventData eventData)
        {
            base.OnPointerExit(eventData);
            ISuppressorAddOn _suppressorAddOn = weaponHolder.GetComponentInChildren<ISuppressorAddOn>();
            _suppressorAddOn.SuppressorGO.transform.DOKill();
            _suppressorAddOn.SuppressorGO.SetActive(false);
            _suppressorAddOn.SuppressorGO.transform.localPosition = suppressorDefaultlocalPos;
        }
    }
}