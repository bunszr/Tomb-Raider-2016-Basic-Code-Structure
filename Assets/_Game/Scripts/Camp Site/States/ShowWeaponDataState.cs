using System.Linq;
using DG.Tweening;
using FSM;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CampSite
{
    public class ShowWeaponDataState : CSBStateBase
    {
        [System.Serializable]
        public class ShowWeaponDataStateData
        {
            public float fadeDuration = .4f;
            public Ease fadeEase = Ease.InOutSine;
        }

        WeaponDataSlider weaponDataSlider;
        FeatureTypeScriptable featureTypeScriptable;
        WeaponDataSliderHolder weaponDataSliderHolder;
        WeaponData weaponData;
        ShowWeaponDataStateData data;

        public ShowWeaponDataState(MonoBehaviour mono, bool needsExitTime, ShowWeaponDataStateData showWeaponDataStateData) : base(mono, needsExitTime)
        {
            this.data = showWeaponDataStateData;
        }

        public override void Init()
        {
            featureTypeScriptable = csbBase.FeatureTypeScriptable;
            weaponData = campSiteHolder.WeaponShowLocation.GetComponentInChildren<IWeapon>().WeaponData;
            weaponDataSliderHolder = campSiteHolder.WeaponDataSliderHolder;
            weaponDataSlider = weaponDataSliderHolder.weaponDataSliders.FirstOrDefault(x => featureTypeScriptable.GetType() == x.featureTypeScriptable.GetType());
            weaponDataSliderHolder.canvasGroupTween.KillMine();
            weaponDataSliderHolder.canvasGroupTween = weaponDataSliderHolder.canvasGroup.DOFade(1, data.fadeDuration).From(0).SetAutoKill(false).SetEase(data.fadeEase).Pause();
        }

        public override void OnEnter() => SubcribeButtonEvents();
        public override void OnExit() => UnSubcribeButtonEvents();

        protected override void OnPointerEnter(PointerEventData eventData)
        {
            weaponDataSliderHolder.canvasGroupTween.PlayForward();

            weaponDataSliderHolder.damageSlider.currValueImage.fillAmount = weaponData.DamageRP.Value / WeaponHelper.maxWeaponData.damage;
            weaponDataSliderHolder.recoilStabilitySlider.currValueImage.fillAmount = weaponData.RecoilStabilityRP.Value / WeaponHelper.maxWeaponData.recoilStability;
            weaponDataSliderHolder.reloadSpeedSlider.currValueImage.fillAmount = weaponData.ReloadSpeedRP.Value / WeaponHelper.maxWeaponData.reloadSpeed;
            weaponDataSliderHolder.ammoCapacitySlider.currValueImage.fillAmount = weaponData.AmmoCapacityRB.Value / WeaponHelper.maxWeaponData.ammoCapacity;
            weaponDataSliderHolder.rateOfFireSlider.currValueImage.fillAmount = weaponData.RateOfFireRP.Value / WeaponHelper.maxWeaponData.rateOfFire;

            weaponDataSliderHolder.damageSlider.addingValueImage.fillAmount = weaponDataSliderHolder.damageSlider.currValueImage.fillAmount;
            weaponDataSliderHolder.recoilStabilitySlider.addingValueImage.fillAmount = weaponDataSliderHolder.recoilStabilitySlider.currValueImage.fillAmount;
            weaponDataSliderHolder.reloadSpeedSlider.addingValueImage.fillAmount = weaponDataSliderHolder.reloadSpeedSlider.currValueImage.fillAmount;
            weaponDataSliderHolder.ammoCapacitySlider.addingValueImage.fillAmount = weaponDataSliderHolder.ammoCapacitySlider.currValueImage.fillAmount;
            weaponDataSliderHolder.rateOfFireSlider.addingValueImage.fillAmount = weaponDataSliderHolder.rateOfFireSlider.currValueImage.fillAmount;

            float addingAmount = WeaponHelper.CommonWeaponDataAddingAmount;
            float fillAmount = 0;
            if (featureTypeScriptable is DamageFeatureScriptable)
                fillAmount = (weaponData.DamageRP.Value + addingAmount) / WeaponHelper.maxWeaponData.damage;
            else if (featureTypeScriptable is RecoilStabilityFeatureScriptable)
                fillAmount = (weaponData.RecoilStabilityRP.Value + addingAmount) / WeaponHelper.maxWeaponData.recoilStability;
            else if (featureTypeScriptable is ReloadSpeedFeatureScriptable)
                fillAmount = (weaponData.ReloadSpeedRP.Value + addingAmount) / WeaponHelper.maxWeaponData.reloadSpeed;
            else if (featureTypeScriptable is AmmoCapacityFeatureScriptable)
                fillAmount = (weaponData.AmmoCapacityRB.Value + addingAmount) / WeaponHelper.maxWeaponData.ammoCapacity;
            else if (featureTypeScriptable is RateOfFireFeatureScriptable)
                fillAmount = (weaponData.RateOfFireRP.Value + addingAmount) / WeaponHelper.maxWeaponData.rateOfFire;

            weaponDataSlider.addingValueImage.fillAmount = fillAmount;
        }

        protected override void OnPointerExit(PointerEventData eventData)
        {
            weaponDataSliderHolder.canvasGroupTween.PlayBackwards();
        }
    }
}