using UnityEngine;

namespace TriggerableAreaNamespace
{
    public class AreaPopUpTrigger
    {
        bool isTrigger;

        TriggerCustom triggerCustom;
        ICondition[] areaConditions;
        IEnterExit[] enterExits;

        public AreaPopUpTrigger(TriggerCustom triggerCustom, ICondition[] areaConditions, params IEnterExit[] enterExits)
        {
            this.triggerCustom = triggerCustom;
            this.areaConditions = areaConditions;
            this.enterExits = enterExits;
        }

        public void Enter()
        {
            triggerCustom.onTriggerEnterEvent += OnCustomTriggerEnter;
            triggerCustom.onTriggerExitEvent += OnCustomTriggerExit;
        }

        public void Exit()
        {
            triggerCustom.onTriggerEnterEvent -= OnCustomTriggerEnter;
            triggerCustom.onTriggerExitEvent -= OnCustomTriggerExit;

            if (isTrigger) enterExits.Foreach(x => x.Exit());
        }

        private void OnCustomTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Player player) && AllCheckListIsTrue())
            {
                isTrigger = true;
                enterExits.Foreach(x => x.Enter());
            }
        }

        private void OnCustomTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out Player player))
            {
                isTrigger = false;
                enterExits.Foreach(x => x.Exit());
            }
        }

        protected bool AllCheckListIsTrue()
        {
            if (areaConditions != null) for (int i = 0; i < areaConditions.Length; i++) if (!areaConditions[i].Check()) return false;
            return true;
        }
    }
}