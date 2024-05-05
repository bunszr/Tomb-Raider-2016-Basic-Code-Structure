using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace CampSite
{
    public class CSBWeaponFeatureSuppressor : CSBFeatureBase
    {
        public Image imageToHighlight;
        public ClickState.ClickStateData clickStateData;
        public ShowInformationState.ShowInformationStateData showInformationState;
        public WeaponRotationState.WeaponRotationStateData weaponRotationStateData;
    }
}