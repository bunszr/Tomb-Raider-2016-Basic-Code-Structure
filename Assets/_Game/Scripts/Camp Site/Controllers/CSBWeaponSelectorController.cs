using UnityEngine.EventSystems;

namespace CampSite
{
    public class CSBWeaponSelectorController : CSBBaseController, IPointerClickHandler
    {
        CSBWeaponSelector csbWeaponSelector;

        CommandExecuterWithCondition commandExecuter;

        protected override void Start()
        {
            base.Start();

            csbWeaponSelector = GetComponent<CSBWeaponSelector>();

            if (csbWeaponSelector.FeatureTypeScriptable.IsOpenRP.Value) AddCommand(new HighlightCommandView(csbBase, csbWeaponSelector.highlightImage));
            else AddCommand(new LockedCommand(csbBase, csbWeaponSelector.lockImage));

            commandExecuter = new CommandExecuterWithCondition(new ICSBExecute[]
            {
                new OpenNewPanelCommand(csbBase, csbWeaponSelector.nextPanelTogglerGO),
                new ToggleActivationGameObjectCommand(csbWeaponSelector.weaponFeatureButtonsHolderGo, true)
            },
                () => csbWeaponSelector.FeatureTypeScriptable.IsOpenRP.Value);
        }

        public void OnPointerClick(PointerEventData eventData) => commandExecuter.ExecuteAll();

        public override void OnPanelActive()
        {
            base.OnPanelActive();
            csbWeaponSelector.weaponFeatureButtonsHolderGo.SetActive(false);
        }
    }
}