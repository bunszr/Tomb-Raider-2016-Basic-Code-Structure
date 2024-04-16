using UnityEngine;
using Zenject;

namespace CampSite
{
    public class CSBWeaponFeature : CampSiteButtonBase
    {
        public HighlightState.HighlightStateData highlightStateData;
        public ShowWeaponDataState.ShowWeaponDataStateData showWeaponDataStateData;
        public ClickState.ClickStateData clickStateData;
        public ShowInformationState.ShowInformationStateData showInformationState;
        public OpenNewFeatureState.OpenNewFeatureStateData openNewFeatureStateData;
        public WeaponRotationState.WeaponRotationStateData weaponRotationStateData;
    }
}