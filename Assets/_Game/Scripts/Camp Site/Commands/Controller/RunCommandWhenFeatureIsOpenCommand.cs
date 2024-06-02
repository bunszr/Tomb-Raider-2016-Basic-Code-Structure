namespace CampSite
{
    public class RunCommandWhenFeatureIsOpenCommand : ICSBActivateable
    {
        FeatureTypeScriptable featureTypeScriptable;
        ICSBActivateable _showTickImageCommand;

        public RunCommandWhenFeatureIsOpenCommand(FeatureTypeScriptable featureTypeScriptable, ICSBActivateable showTickImageCommand)
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