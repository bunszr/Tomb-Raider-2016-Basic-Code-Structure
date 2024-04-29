using UnityEngine;

namespace TriggerableAreaNamespace
{
    public class AreaTriggerBase : ITriggerEnterExit
    {
        protected AreaBase areaBase;
        protected TriggerCustom triggerCustom;

        public AreaTriggerBase(AreaBase areaBase)
        {
            this.areaBase = areaBase;
            this.triggerCustom = areaBase.controller.GetComponent<TriggerCustom>();
        }

        public virtual void Activate()
        {
            triggerCustom.onTriggerEnterEvent += OnCustomTriggerEnter;
            triggerCustom.onTriggerExitEvent += OnCustomTriggerExit;
        }

        public virtual void Deactivate()
        {
            triggerCustom.onTriggerEnterEvent -= OnCustomTriggerEnter;
            triggerCustom.onTriggerExitEvent -= OnCustomTriggerExit;
        }

        public virtual void OnCustomTriggerEnter(Collider other) { }
        public virtual void OnCustomTriggerExit(Collider other) { }
    }
}