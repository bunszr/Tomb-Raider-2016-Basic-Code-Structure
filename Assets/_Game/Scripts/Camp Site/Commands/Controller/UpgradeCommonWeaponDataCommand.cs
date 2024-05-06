namespace CampSite
{
    public class UpgradeCommonWeaponDataCommand : ICSBExecute
    {
        WeaponDataScriptable weaponDataScriptable;
        WeaponFeatureTypeScriptable weaponFeatureTypeScriptable;

        public UpgradeCommonWeaponDataCommand(WeaponDataScriptable weaponDataScriptable, WeaponFeatureTypeScriptable weaponFeatureTypeScriptable)
        {
            this.weaponDataScriptable = weaponDataScriptable;
            this.weaponFeatureTypeScriptable = weaponFeatureTypeScriptable;
        }

        public void Execute()
        {
            IAddableIntValue _iAddableIntValue = weaponFeatureTypeScriptable as IAddableIntValue;

            switch (weaponFeatureTypeScriptable)
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