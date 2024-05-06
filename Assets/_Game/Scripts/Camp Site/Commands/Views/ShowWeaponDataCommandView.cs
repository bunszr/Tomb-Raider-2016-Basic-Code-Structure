using System.Linq;
using DG.Tweening;
using UnityEngine.EventSystems;

namespace CampSite
{
    public class ShowWeaponDataCommandView : CampsiteButtonCommandBase
    {
        float defautLocalY;

        WeaponDataSlider weaponDataSlider;
        FeatureTypeScriptable featureTypeScriptable;
        WeaponDataSliderHolder holder;
        IAddableIntValue _addableIntegerValue;
        WeaponDataScriptable weaponDataScriptable;

        GameDataScriptable.CampSiteScriptableData.WeaponDataSliderScriptableData ScriptableData => GameDataScriptable.Ins.campSiteScriptableData.weaponDataSliderScriptableData;

        public ShowWeaponDataCommandView(CSBBase csbBase, WeaponDataScriptable weaponDataScriptable, WeaponDataSliderHolder holder) : base(csbBase)
        {
            this.weaponDataScriptable = weaponDataScriptable;

            this.holder = holder;
            featureTypeScriptable = csbBase.FeatureTypeScriptable;
            _addableIntegerValue = featureTypeScriptable as IAddableIntValue;
            weaponDataSlider = holder.weaponDataSliders.FirstOrDefault(x => featureTypeScriptable.GetType() == x.featureTypeScriptable.GetType());
            defautLocalY = holder.canvasGroup.transform.localPosition.y;
        }

        protected override void OnPointerEnter(PointerEventData eventData)
        {
            GameDataScriptable.WeaponScriptableData.MaxWeaponDataSaveable maxWeaponData = GameDataScriptable.Ins.weaponScriptableData.maxWeaponDataSaveable;
            WeaponData weaponData = weaponDataScriptable.WeaponData;

            holder.damageSlider.currValueImage.fillAmount = weaponData.DamageRP.Value / (float)maxWeaponData.damage;
            holder.recoilStabilitySlider.currValueImage.fillAmount = weaponData.RecoilStabilityRP.Value / (float)maxWeaponData.recoilStability;
            holder.reloadSpeedSlider.currValueImage.fillAmount = weaponData.ReloadSpeedRP.Value / (float)maxWeaponData.reloadSpeed;
            holder.ammoCapacitySlider.currValueImage.fillAmount = weaponData.AmmoCapacityRP.Value / (float)maxWeaponData.ammoCapacity;
            holder.rateOfFireSlider.currValueImage.fillAmount = weaponData.RateOfFireRP.Value / (float)maxWeaponData.rateOfFire;

            holder.damageSlider.addingValueImage.fillAmount = holder.damageSlider.currValueImage.fillAmount;
            holder.recoilStabilitySlider.addingValueImage.fillAmount = holder.recoilStabilitySlider.currValueImage.fillAmount;
            holder.reloadSpeedSlider.addingValueImage.fillAmount = holder.reloadSpeedSlider.currValueImage.fillAmount;
            holder.ammoCapacitySlider.addingValueImage.fillAmount = holder.ammoCapacitySlider.currValueImage.fillAmount;
            holder.rateOfFireSlider.addingValueImage.fillAmount = holder.rateOfFireSlider.currValueImage.fillAmount;

            if (!featureTypeScriptable.IsOpenRP.Value)
            {
                float addingAmount = _addableIntegerValue.ValueToAdd;
                float fillAmount = 0;
                switch (featureTypeScriptable)
                {
                    case DamageFeatureScriptable:
                        fillAmount = (weaponData.DamageRP.Value + addingAmount) / maxWeaponData.damage;
                        break;
                    case RecoilStabilityFeatureScriptable:
                        fillAmount = (weaponData.RecoilStabilityRP.Value + addingAmount) / maxWeaponData.recoilStability;
                        break;
                    case ReloadSpeedFeatureScriptable:
                        fillAmount = (weaponData.ReloadSpeedRP.Value + addingAmount) / maxWeaponData.reloadSpeed;
                        break;
                    case AmmoCapacityFeatureScriptable:
                        fillAmount = (weaponData.AmmoCapacityRP.Value + addingAmount) / maxWeaponData.ammoCapacity;
                        break;
                    case RateOfFireFeatureScriptable:
                        fillAmount = (weaponData.RateOfFireRP.Value + addingAmount) / maxWeaponData.rateOfFire;
                        break;
                    default:
                        break;
                }
                weaponDataSlider.addingValueImage.fillAmount = fillAmount;
            }

            holder.canvasGroup.DOFade(1, ScriptableData.fadeDuration).From(0).SetEase(ScriptableData.fadeEase);
            holder.canvasGroup.transform.DOLocalMoveY(ScriptableData.yAnimationAmount, ScriptableData.yAnimationDuration).SetEase(ScriptableData.yAnimEase).From(true);
        }

        protected override void OnPointerExit(PointerEventData eventData)
        {
            holder.canvasGroup.DOKill();
            holder.canvasGroup.transform.DOKill();

            holder.canvasGroup.alpha = 0;
            holder.canvasGroup.transform.SetLocalPosY(defautLocalY);
        }
    }
}