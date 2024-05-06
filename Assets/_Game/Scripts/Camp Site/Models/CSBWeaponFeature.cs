using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace CampSite
{
    public class CSBWeaponFeature : CSBFeatureBase
    {
        public Image lockImage;
        public Image highlightImage;

        public WeaponDataScriptable weaponDataScriptable;
        public WeaponRotationState.WeaponRotationStateData weaponRotationStateData;
    }
}