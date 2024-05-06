using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;

namespace CampSite
{
    public class CSUpgradedPanel : MonoBehaviour, IUpgradedPanelData
    {
        [ReadOnly, ShowInInspector] FeatureTypeScriptable featureTypeScriptable;
        public GameObject panelGO;
        public TextMeshProUGUI nameText;
        public TextMeshProUGUI descriptionText;

        public FeatureTypeScriptable FeatureTypeScriptable { get => featureTypeScriptable; set => featureTypeScriptable = value; }
    }
}