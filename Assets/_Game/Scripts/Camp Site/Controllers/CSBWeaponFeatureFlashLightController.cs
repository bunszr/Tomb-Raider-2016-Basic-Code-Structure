namespace CampSite
{
    public class CSBWeaponFeatureFlashLightController : CSBWeaponFeatureController
    {
        protected override void Start()
        {
            base.Start();

            CSBWeaponFeatureFlashLight csbWeaponFeatureFlashLight = csbBase as CSBWeaponFeatureFlashLight;

            RemoveCommand(x => x is ShowWeaponDataCommandView);
            AddCommand(new ToggleCommandAccordingFeatureOpenController(csbBase.FeatureTypeScriptable,

                new ShowFlashLightCommandView(csbBase, campSiteHolder.WeaponShowLocation.gameObject, csbWeaponFeatureFlashLight.showFlashLightCommandViewData),
                new ShowFlashLightAfterOpenCommandView(csbBase, campSiteHolder.WeaponShowLocation.gameObject)
            ));
        }
    }
}