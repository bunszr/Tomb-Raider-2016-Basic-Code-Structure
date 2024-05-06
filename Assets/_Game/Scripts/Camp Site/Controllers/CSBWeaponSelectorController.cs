using UnityEngine.EventSystems;

namespace CampSite
{
    public class CSBWeaponSelectorController : CSBBaseController
    {
        CSBWeaponSelector csbWeaponSelector;

        CommandExecuterWithCondition commandExecuter;

        protected void Start()
        {
            csbWeaponSelector = GetComponent<CSBWeaponSelector>();

            if (csbWeaponSelector.FeatureTypeScriptable.IsOpenRP.Value) AddCommand(new HighlightCommandView(csbBase, csbWeaponSelector.highlightImage));
            else AddCommand(new LockedCommandView(csbBase, csbWeaponSelector.lockImage));

            commandExecuter = new CommandExecuterWithCondition(new ICSBExecute[]
            {
                new OpenNewPanelCommand(csbBase, csbWeaponSelector.nextPanelTogglerGO),
                new ToggleActivationGameObjectCommand(csbWeaponSelector.weaponFeatureButtonsHolderGo, true)
            },
                () => csbWeaponSelector.FeatureTypeScriptable.IsOpenRP.Value);
        }

        public override void OnPanelActive()
        {
            base.OnPanelActive();
            csbWeaponSelector.weaponFeatureButtonsHolderGo.SetActive(false);
        }

        public override void OnPointerClick(PointerEventData eventData)
        {
            base.OnPointerClick(eventData);
            commandExecuter.ExecuteAll();
        }
    }
}