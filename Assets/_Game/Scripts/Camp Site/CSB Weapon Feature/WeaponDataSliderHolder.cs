using DG.Tweening;
using UnityEngine;

namespace CampSite
{
    public class WeaponDataSliderHolder : MonoBehaviour
    {
        public Tween canvasGroupTween;
        public CanvasGroup canvasGroup;
        public WeaponDataSlider[] weaponDataSliders;
        public WeaponDataSlider damageSlider;
        public WeaponDataSlider recoilStabilitySlider;
        public WeaponDataSlider reloadSpeedSlider;
        public WeaponDataSlider ammoCapacitySlider;
        public WeaponDataSlider rateOfFireSlider;
    }
}