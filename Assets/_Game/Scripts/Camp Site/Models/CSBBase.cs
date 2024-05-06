using Cinemachine;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace CampSite
{
    public abstract class CSBBase : MonoBehaviour
    {
        [SerializeField, Required("Feature Type is nessessary for this component.")]
        FeatureTypeScriptable featureTypeScriptable;

        [Inject, HideInInspector] public CampSiteHolder campSiteHolder;
        [Inject, HideInInspector] public CinemachineBrain brain;

        public ButtonEvents buttonEvents = new ButtonEvents();

        public FeatureTypeScriptable FeatureTypeScriptable => featureTypeScriptable;
    }
}