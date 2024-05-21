using FSM;
using UnityEngine.EventSystems;

namespace CampSite
{
    public class CSBFirstLevelController : CSBBaseController
    {
        CSBFirstLevel csbFirstLevel;

        protected void Start()
        {
            csbFirstLevel = GetComponent<CSBFirstLevel>();

            if (csbBase.FeatureTypeScriptable.IsOpenRP.Value)
                AddCommand(new FirstLevelButtonAnimationCommandView(csbBase, csbFirstLevel.cam));
            else AddCommand(new LockedCommandView(csbBase, csbFirstLevel.lockImage));

            commandExecuter = new CommandExecuterWithCondition(new ICSBExecute[]
            {
                new PanelTogglerCommand(csbBase, csbFirstLevel.nextPanelTogglerGO, campSiteHolder.CSUndoCommandExecuter),
            },
                () => csbBase.FeatureTypeScriptable.IsOpenRP.Value);
        }

        public override void OnPointerClick(PointerEventData eventData)
        {
            base.OnPointerClick(eventData);
            commandExecuter.ExecuteAll();
        }
    }
}