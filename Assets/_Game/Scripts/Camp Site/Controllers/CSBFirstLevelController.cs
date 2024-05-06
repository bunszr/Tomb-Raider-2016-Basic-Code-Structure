using FSM;
using UnityEngine.EventSystems;

namespace CampSite
{
    public class CSBFirstLevelController : CSBBaseController, IPointerClickHandler
    {
        CSBFirstLevel csbFirstLevel;

        CommandExecuterWithCondition commandExecuter;

        protected void Start()
        {
            csbFirstLevel = GetComponent<CSBFirstLevel>();

            if (csbBase.FeatureTypeScriptable.IsOpenRP.Value)
                AddCommand(new FirstLevelButtonAnimationCommandView(csbBase, csbFirstLevel.cam));
            else AddCommand(new LockedCommand(csbBase, csbFirstLevel.lockImage));

            commandExecuter = new CommandExecuterWithCondition(new ICSBExecute[]
            {
                new OpenNewPanelCommand(csbBase, csbFirstLevel.nextPanelTogglerGO),
            },
                () => csbBase.FeatureTypeScriptable.IsOpenRP.Value);
        }

        public void OnPointerClick(PointerEventData eventData) => commandExecuter.ExecuteAll();
    }
}