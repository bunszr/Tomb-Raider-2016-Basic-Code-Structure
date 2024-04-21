using UnityEngine;

namespace CampSite
{
    public class UpgradeWeaponCommonDataState : CSBStateBase
    {
        WeaponDataScriptable weaponDataScriptable;

        public UpgradeWeaponCommonDataState(MonoBehaviour mono, WeaponDataScriptable weaponDataScriptable, bool needsExitTime, bool isGhostState = false) : base(mono, needsExitTime, isGhostState)
        {
            this.weaponDataScriptable = weaponDataScriptable;
        }

        public override void OnEnter()
        {
            Debug.Log("enter UpgradeWeaponCommonDataState");
            IAddableIntValue _iAddableIntValue = csbBase.FeatureTypeScriptable as IAddableIntValue;

            switch (csbBase.FeatureTypeScriptable)
            {
                case DamageFeatureScriptable:
                    weaponDataScriptable.WeaponData.DamageRP.Value += _iAddableIntValue.ValueToAdd; break;
                case RecoilStabilityFeatureScriptable:
                    weaponDataScriptable.WeaponData.RecoilStabilityRP.Value += _iAddableIntValue.ValueToAdd; break;
                case ReloadSpeedFeatureScriptable:
                    weaponDataScriptable.WeaponData.ReloadSpeedRP.Value += _iAddableIntValue.ValueToAdd; break;
                case AmmoCapacityFeatureScriptable:
                    weaponDataScriptable.WeaponData.AmmoCapacityRP.Value += _iAddableIntValue.ValueToAdd; break;
                case RateOfFireFeatureScriptable:
                    weaponDataScriptable.WeaponData.RateOfFireRP.Value += _iAddableIntValue.ValueToAdd; break;
            }
        }
    }
}