namespace CampSite
{
    public class CostDataCommandController : ICSBActivateable
    {
        FeatureTypeScriptable featureTypeScriptable;
        ICSBActivateable _showCostDataState;
        ICSBActivateable _showOnlyCostDataState;

        public CostDataCommandController(FeatureTypeScriptable featureTypeScriptable, ICSBActivateable showCostDataState, ICSBActivateable showOnlyCostDataState)
        {
            this.featureTypeScriptable = featureTypeScriptable;
            _showCostDataState = showCostDataState;
            _showOnlyCostDataState = showOnlyCostDataState;
        }


        public void OnActivate()
        {
            if (featureTypeScriptable.IsOpenRP.Value) _showOnlyCostDataState.OnActivate();
            else _showCostDataState.OnActivate();
        }

        public void OnDeactivate()
        {
            if (featureTypeScriptable.IsOpenRP.Value) _showOnlyCostDataState.OnDeactivate();
            else _showCostDataState.OnDeactivate();
        }
    }
}