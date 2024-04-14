using UnityEngine;
using Zenject;

namespace CampSite
{
    public class CSBWeaponFeatureSuppressor : CSBSaveable
    {
        public HighlightState.HighlightStateData highlightStateData;
        public ClickState.ClickStateData clickStateData;
        public ShowInformationState.ShowInformationStateData showInformationState;
        public OpenNewFeatureState.OpenNewFeatureStateData openNewFeatureStateData;
        public WeaponRotationState.WeaponRotationStateData weaponRotationStateData;

        public override string CSBName => GetComponentInParent<WeaponFeatureSaver>(true).weaponTypeScriptable.WeaponName + " - " + FeatureTypeScriptable.GetType().Name;
    }
}