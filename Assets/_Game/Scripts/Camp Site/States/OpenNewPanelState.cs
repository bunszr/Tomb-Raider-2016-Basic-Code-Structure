using UnityEngine;

namespace CampSite
{
    public class OpenNewPanelState : CSBStateBase
    {
        GameObject nextPanelTogglerGO;

        public OpenNewPanelState(MonoBehaviour mono, GameObject nextPanelTogglerGO, bool needsExitTime = false, bool isGhostState = false) : base(mono, needsExitTime, isGhostState)
        {
            this.nextPanelTogglerGO = nextPanelTogglerGO;
        }

        public override void OnEnter()
        {
            IPanelToggler _panelToggler = mono.GetComponentInParent<IPanelToggler>();
            _panelToggler.Deactive();

            nextPanelTogglerGO.GetComponent<IPanelToggler>().Active();

            mono.GetComponentInParent<CampsiteCommandExecuter>().AddCommand(new CampsitePanelTogglerCommand(_panelToggler.Active));
        }
    }
}