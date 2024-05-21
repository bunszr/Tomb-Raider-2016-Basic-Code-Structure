using UnityEngine.EventSystems;

namespace CampSite
{
    public class CSBWeaponSelectorController : CSBBaseController
    {
        CSBWeaponSelector csbWeaponSelector;

        CommandExecuterWithCondition commandExecuterWhenPanelOnActive;

        protected void Start()
        {
            csbWeaponSelector = GetComponent<CSBWeaponSelector>();

            if (csbWeaponSelector.FeatureTypeScriptable.IsOpenRP.Value) AddCommand(new HighlightCommandView(csbBase, csbWeaponSelector.highlightImage));
            else AddCommand(new LockedCommandView(csbBase, csbWeaponSelector.lockImage));

            commandExecuter = new CommandExecuterWithCondition(new ICSBExecute[]
            {
                new PanelTogglerCommand(csbBase, csbWeaponSelector.nextPanelTogglerGO, campSiteHolder.CSUndoCommandExecuter),
                new ToggleActivationGameObjectCommand(csbWeaponSelector.weaponFeatureButtonsHolderGo, true),
                new ToggleActivationGameObjectCommand(csbWeaponSelector.weaponParentGo, true)
            },
                () => csbWeaponSelector.FeatureTypeScriptable.IsOpenRP.Value);

            commandExecuterWhenPanelOnActive = new CommandExecuterWithCondition(new ICSBExecute[]
            {
                new ToggleActivationGameObjectCommand(csbWeaponSelector.weaponFeatureButtonsHolderGo, false),
                new ToggleActivationGameObjectCommand(csbWeaponSelector.weaponParentGo, false),
            },
                () => true);
        }

        public override void OnPanelActive()
        {
            base.OnPanelActive();
            commandExecuterWhenPanelOnActive.ExecuteAll();
        }

        public override void OnPointerClick(PointerEventData eventData)
        {
            base.OnPointerClick(eventData);
            commandExecuter.ExecuteAll();
        }
    }
}