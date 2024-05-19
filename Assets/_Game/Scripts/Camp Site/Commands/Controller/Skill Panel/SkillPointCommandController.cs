namespace CampSite
{
    public class SkillPointCommandController : ICSBActivateable
    {
        FeatureTypeScriptable featureTypeScriptable;
        ICSBActivateable _showSkillPoint;
        ICSBActivateable _dontShowSkillPoint;

        public SkillPointCommandController(FeatureTypeScriptable featureTypeScriptable, ICSBActivateable showSkillPoint, ICSBActivateable dontShowSkillPoint)
        {
            this.featureTypeScriptable = featureTypeScriptable;
            _showSkillPoint = showSkillPoint;
            _dontShowSkillPoint = dontShowSkillPoint;
        }

        public void OnActivate()
        {
            if (featureTypeScriptable.IsOpenRP.Value) _dontShowSkillPoint.OnActivate();
            else _showSkillPoint.OnActivate();
        }

        public void OnDeactivate()
        {
            if (featureTypeScriptable.IsOpenRP.Value) _dontShowSkillPoint.OnDeactivate();
            else _showSkillPoint.OnDeactivate();
        }
    }
}