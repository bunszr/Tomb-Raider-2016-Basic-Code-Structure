using UnityEngine;
using Zenject;

namespace CampSite
{
    public class CSBWeaponFeatureSuppressor : CampSiteButtonBase
    {
        public HighlightState.HighlightStateData highlightStateData;
        public ClickState.ClickStateData clickStateData;
        public ShowInformationState.ShowInformationStateData showInformationState;
        public OpenNewFeatureState.OpenNewFeatureStateData openNewFeatureStateData;
        public WeaponRotationState.WeaponRotationStateData weaponRotationStateData;
    }
}