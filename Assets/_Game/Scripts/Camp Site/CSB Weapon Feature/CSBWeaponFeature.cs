using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace CampSite
{
    public class CSBWeaponFeature : CSBFeatureBase
    {
        public Image imageToHighlight;
        public WeaponDataScriptable weaponDataScriptable;
        public ClickState.ClickStateData clickStateData;
        public ShowInformationState.ShowInformationStateData showInformationState;
        public WeaponRotationState.WeaponRotationStateData weaponRotationStateData;
    }
}