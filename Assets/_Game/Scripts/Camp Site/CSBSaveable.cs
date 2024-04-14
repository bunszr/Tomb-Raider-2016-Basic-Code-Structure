namespace CampSite
{
    public class CSBSaveable : CampSiteButtonBase, ICSBSaveable
    {
        public FeatureDataSaveable featureDataSaveable;
        public virtual string CSBName { get; }
    }
}
