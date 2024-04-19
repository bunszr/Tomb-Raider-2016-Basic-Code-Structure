using Cinemachine;
using DG.Tweening;
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

        public override void Init()
        {
        }

        public override void OnEnter()
        {
            IAddableIntValue _iAddableIntValue = weaponDataScriptable as IAddableIntValue;

            switch (csbBase.FeatureTypeScriptable)
            {
                case DamageFeatureScriptable:
                    weaponDataScriptable.weaponData.DamageRP.Value += _iAddableIntValue.ValueToAdd; break;
                case RecoilStabilityFeatureScriptable:
                    weaponDataScriptable.weaponData.RecoilStabilityRP.Value += _iAddableIntValue.ValueToAdd; break;
                case ReloadSpeedFeatureScriptable:
                    weaponDataScriptable.weaponData.ReloadSpeedRP.Value += _iAddableIntValue.ValueToAdd; break;
                case AmmoCapacityFeatureScriptable:
                    weaponDataScriptable.weaponData.AmmoCapacityRP.Value += _iAddableIntValue.ValueToAdd; break;
                case RateOfFireFeatureScriptable:
                    weaponDataScriptable.weaponData.RateOfFireRP.Value += _iAddableIntValue.ValueToAdd; break;
            }
        }
    }
}