namespace CampSite
{
    public class ToggleCommandBasedOnFeatureState : ICSBActivateable
    {
        FeatureTypeScriptable featureTypeScriptable;
        ICSBActivateable _activeCommandWhenOpen;
        ICSBActivateable _activeCommandWhenClose;

        public ToggleCommandBasedOnFeatureState(FeatureTypeScriptable featureTypeScriptable, ICSBActivateable activeCommandWhenClose, ICSBActivateable activeCommandWhenOpen)
        {
            this.featureTypeScriptable = featureTypeScriptable;
            _activeCommandWhenOpen = activeCommandWhenOpen;
            _activeCommandWhenClose = activeCommandWhenClose;
        }


        public void OnActivate()
        {
            if (featureTypeScriptable.IsOpenRP.Value) _activeCommandWhenOpen.OnActivate();
            else _activeCommandWhenClose.OnActivate();
        }

        public void OnDeactivate()
        {
            if (featureTypeScriptable.IsOpenRP.Value) _activeCommandWhenOpen.OnDeactivate();
            else _activeCommandWhenClose.OnDeactivate();
        }
    }
}