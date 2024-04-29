using DG.Tweening;
using UnityEngine;

namespace TriggerableAreaNamespace
{
    public class AreaNormalTriggerPopUpView : AreaTriggerBase
    {
        ITriggerablePopUp _triggerablePopUp;

        public AreaNormalTriggerPopUpView(AreaBase areaBase) : base(areaBase)
        {
            _triggerablePopUp = areaBase as ITriggerablePopUp;
        }

        public override void OnCustomTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Player player) && _triggerablePopUp.HasPopUp)
            {
                _triggerablePopUp.PopUpGo.SetActive(true);
                _triggerablePopUp.PopUpGo.transform.DOScale(1, .3f).From(0);
            }
        }

        public override void OnCustomTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out Player player))
            {
                _triggerablePopUp.PopUpGo.SetActive(false);
                _triggerablePopUp.PopUpGo.transform.DOKill();
            }
        }
    }
}