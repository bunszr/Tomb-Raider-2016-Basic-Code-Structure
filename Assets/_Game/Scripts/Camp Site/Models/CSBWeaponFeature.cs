using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace CampSite
{
    public class CSBWeaponFeature : CSBBase
    {
        public TextMeshProUGUI featureNameText;
        public Image lockImage;
        public Image tickImage;
        public Image highlightImage;

        public WeaponDataScriptable weaponDataScriptable;
        public WeaponRotationCommandView.WeaponRotationStateData weaponRotationStateData;
        public CanvasGroupAndPosAnimationCommandView.CanvasGroupAndPosAnimationCommandViewData canvasGroupAndPosAnimationCommandViewData;
    }
}