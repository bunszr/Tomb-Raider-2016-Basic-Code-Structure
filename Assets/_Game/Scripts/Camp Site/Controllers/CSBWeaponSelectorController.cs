namespace CampSite
{
    public class CSBWeaponSelectorController : CSBBaseController
    {
        CSBWeaponSelector csbWeaponSelector;

        protected override void Start()
        {
            base.Start();

            csbWeaponSelector = GetComponent<CSBWeaponSelector>();

            if (csbWeaponSelector.FeatureTypeScriptable.IsOpenRP.Value)
            {
                csbActivateableList.Add(new HighlightCommandView(csbBase, csbWeaponSelector.highlightImage));
                csbActivateableList.Add(new OpenNewPanelCommand(csbBase, csbWeaponSelector.nextPanelTogglerGO));
            }
            else csbActivateableList.Add(new LockedCommand(csbBase, csbWeaponSelector.lockImage));

            csbActivateableList.ForEach(x => x.OnActivate());
        }
    }
}