using DG.Tweening;
using UnityEngine;

namespace TriggerableAreaNamespace
{
    public class AreaInventoryItemTriggerNotAllowedView : AreaTriggerBase
    {
        INotAllowedTriggerable _notAllowedTriggerable;

        public AreaInventoryItemTriggerNotAllowedView(AreaBase areaBase) : base(areaBase)
        {
            _notAllowedTriggerable = areaBase as INotAllowedTriggerable;
        }

        public override void OnCustomTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Player player) && _notAllowedTriggerable.NotAllowedCondition)
            {
                _notAllowedTriggerable.NotAllowedGo.SetActive(true);
                _notAllowedTriggerable.NotAllowedGo.transform.DOScale(1, .3f).From(0);
            }
        }

        public override void OnCustomTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out Player player))
            {
                _notAllowedTriggerable.NotAllowedGo.SetActive(false);
                _notAllowedTriggerable.NotAllowedGo.transform.DOKill();
            }
        }
    }
}