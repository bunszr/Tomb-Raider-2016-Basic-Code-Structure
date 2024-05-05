using UnityEngine;
using UnityEngine.EventSystems;

namespace CampSite
{
    public class ClickCommand : CampsiteCommandBase
    {
        GameObject nextPanelTogglerGO;

        public ClickCommand(CampSiteButtonBase csbBase, GameObject nextPanelTogglerGO) : base(csbBase) => this.nextPanelTogglerGO = nextPanelTogglerGO;

        public override void OnActivate() => buttonEvents.onPointerClickEvent += OnClick;
        public override void OnDeactivate() => buttonEvents.onPointerClickEvent -= OnClick;

        void OnClick(PointerEventData eventData)
        {
            IPanelToggler _panelToggler = csbBase.GetComponentInParent<IPanelToggler>();
            _panelToggler.Deactive();

            nextPanelTogglerGO.GetComponent<IPanelToggler>().Active();

            csbBase.GetComponentInParent<CampsiteCommandExecuter>().AddCommand(new CampsitePanelTogglerCommand(_panelToggler.Active));
        }
    }
}