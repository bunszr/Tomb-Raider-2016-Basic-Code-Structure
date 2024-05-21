using UnityEngine;
using UnityEngine.EventSystems;

namespace CampSite
{
    public class PanelTogglerCommand : CampsiteButtonCommandBase, ICSBExecute
    {
        GameObject nextPanelTogglerGO;
        CSUndoCommandExecuter csUndoCommandExecuter;

        public PanelTogglerCommand(CSBBase csbBase, GameObject nextPanelTogglerGO, CSUndoCommandExecuter cSUndoCommandExecuter) : base(csbBase)
        {
            this.nextPanelTogglerGO = nextPanelTogglerGO;
            this.csUndoCommandExecuter = cSUndoCommandExecuter;
        }

        public override void OnActivate() => buttonEvents.onPointerClickEvent += OnClick;
        public override void OnDeactivate() => buttonEvents.onPointerClickEvent -= OnClick;

        void OnClick(PointerEventData eventData)
        {
            Execute();
        }

        public void Execute()
        {
            IPanelToggler _panelToggler = csbBase.GetComponentInParent<IPanelToggler>();
            _panelToggler.Deactive();

            nextPanelTogglerGO.GetComponent<IPanelToggler>().Active();

            csUndoCommandExecuter.AddCommand(new CSPanelUndoCommand(() => _panelToggler.Active()));
        }
    }
}