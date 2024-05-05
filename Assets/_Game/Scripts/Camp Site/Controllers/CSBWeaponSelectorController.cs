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
                cSBEnterExits.Add(new HighlighCommand(csbBase, csbWeaponSelector.highlightImage));
                cSBEnterExits.Add(new ClickCommand(csbBase, csbWeaponSelector.nextPanelTogglerGO));
            }
            else cSBEnterExits.Add(new LockedCommand(csbBase, csbWeaponSelector.lockImage));

            cSBEnterExits.ForEach(x => x.OnActivate());
        }
    }
}