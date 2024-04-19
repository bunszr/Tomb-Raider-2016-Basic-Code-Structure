using UnityEngine;
using Zenject;

namespace CampSite
{
    public class CSBWeaponFeature : CSBFeatureBase
    {
        public WeaponDataScriptable weaponDataScriptable;
        public HighlightState.HighlightStateData highlightStateData;
        public ClickState.ClickStateData clickStateData;
        public ShowInformationState.ShowInformationStateData showInformationState;
        public WeaponRotationState.WeaponRotationStateData weaponRotationStateData;
    }
}