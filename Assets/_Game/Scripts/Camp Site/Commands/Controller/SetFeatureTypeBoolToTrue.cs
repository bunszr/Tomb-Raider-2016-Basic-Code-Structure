namespace CampSite
{
    public class SetFeatureTypeBoolToTrue : ICSBExecute
    {
        FeatureTypeScriptable featureTypeScriptable;
        public SetFeatureTypeBoolToTrue(FeatureTypeScriptable featureTypeScriptable) => this.featureTypeScriptable = featureTypeScriptable;
        public void Execute() => featureTypeScriptable.IsOpenRP.Value = true;
    }
}