using System.Collections.Generic;
using UnityEngine;

namespace TriggerableAreaNamespace
{
    public class AreaCommonViewer : MonoBehaviour
    {
        [SerializeField] AreaBase areaBase;
        List<ITriggerEnterExit> _triggerEnterExits;

        private void Start()
        {
            TriggerCustom triggerCustom = areaBase.controller.GetOrAddComponent<TriggerCustom>();

            _triggerEnterExits = new List<ITriggerEnterExit>()
            {
                new AreaNormalTriggerPopUpView(areaBase),
                new AreaInventoryItemTriggerNotAllowedView(areaBase),
            };

            _triggerEnterExits.ForEach(x => x.Activate());
        }

        private void OnDestroy() => _triggerEnterExits.ForEach(x => x.Deactivate());
    }
}