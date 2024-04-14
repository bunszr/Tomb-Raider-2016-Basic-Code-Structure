using Sirenix.OdinInspector;
using UnityEngine;

namespace CampSite
{
    public class CSBSaveable : CampSiteButtonBase, ICSBSaveable
    {
        [SerializeField, Required("MyMesh is nessessary for this component.")]
        FeatureTypeScriptable featureTypeScriptable;
        public FeatureDataSaveable featureDataSaveable;

        public FeatureTypeScriptable FeatureTypeScriptable => featureTypeScriptable;
        public virtual string CSBName { get; }
    }
}
