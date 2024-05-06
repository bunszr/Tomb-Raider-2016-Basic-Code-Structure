using UnityEngine;

namespace CampSite
{
    public class UpgradedPanelDataSetterCommand : ICSBExecute
    {
        GameObject nextPanelTogglerGO;
        FeatureTypeScriptable featureTypeScriptable;

        public UpgradedPanelDataSetterCommand(GameObject nextPanelTogglerGO, FeatureTypeScriptable featureTypeScriptable)
        {
            this.nextPanelTogglerGO = nextPanelTogglerGO;
            this.featureTypeScriptable = featureTypeScriptable;
        }

        public void Execute() => nextPanelTogglerGO.GetComponent<IUpgradedPanelData>().FeatureTypeScriptable = featureTypeScriptable;
    }
}