namespace CampSite
{
    public class CSBWeaponFeatureSuppressorController : CSBWeaponFeatureController
    {
        protected override void Start()
        {
            base.Start();
            RemoveCommand(x => x is ShowWeaponDataCommandView);
            AddCommand(new ShowSuppressorCommandView(csbBase, campSiteHolder.WeaponShowLocation.gameObject));
        }
    }
}