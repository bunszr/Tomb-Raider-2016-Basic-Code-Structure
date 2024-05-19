using UniRx;

namespace CampSite
{
    public class SpendSkillPointCommand : ICSBExecute
    {
        SkillFeatureTypeScriptable skillFeatureTypeScriptable;
        ReactiveProperty<int> numSkillPointRP;

        public SpendSkillPointCommand(SkillFeatureTypeScriptable skillFeatureTypeScriptable, ReactiveProperty<int> numSkillPoint)
        {
            this.skillFeatureTypeScriptable = skillFeatureTypeScriptable;
            this.numSkillPointRP = numSkillPoint;
        }

        public void Execute() => numSkillPointRP.Value -= skillFeatureTypeScriptable.SkillCostAmount;
    }
}