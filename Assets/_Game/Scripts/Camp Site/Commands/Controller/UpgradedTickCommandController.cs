namespace CampSite
{
    public class UpgradedTickCommandController : ICSBActivateable
    {
        FeatureTypeScriptable featureTypeScriptable;
        ICSBActivateable _showTickImageCommand;

        public UpgradedTickCommandController(FeatureTypeScriptable featureTypeScriptable, ICSBActivateable showTickImageCommand)
        {
            this.featureTypeScriptable = featureTypeScriptable;
            _showTickImageCommand = showTickImageCommand;
        }

        public void OnActivate()
        {
            if (featureTypeScriptable.IsOpenRP.Value) _showTickImageCommand.OnActivate();
        }

        public void OnDeactivate()
        {
            if (featureTypeScriptable.IsOpenRP.Value) _showTickImageCommand.OnDeactivate();
        }
    }
}