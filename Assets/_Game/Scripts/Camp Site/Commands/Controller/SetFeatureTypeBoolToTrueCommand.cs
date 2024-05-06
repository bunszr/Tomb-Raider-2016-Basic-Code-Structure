namespace CampSite
{
    public class SetFeatureTypeBoolToTrueCommand : ICSBExecute
    {
        FeatureTypeScriptable featureTypeScriptable;
        public SetFeatureTypeBoolToTrueCommand(FeatureTypeScriptable featureTypeScriptable) => this.featureTypeScriptable = featureTypeScriptable;
        public void Execute() => featureTypeScriptable.IsOpenRP.Value = true;
    }
}