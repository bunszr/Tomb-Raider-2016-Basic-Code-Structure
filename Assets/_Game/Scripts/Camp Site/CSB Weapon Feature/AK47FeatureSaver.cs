using Sirenix.OdinInspector;

namespace CampSite
{
    public class AK47FeatureSaver : WeaponFeatureSaver
    {
        public FeatureTypeScriptable suppressorFeatureScriptable;
        public FeatureTypeScriptable flashLightFeatureScriptable;

        [Button]
        void Save()
        {
            Data data = new Data()
            {
                weaponDataSaveable = campSiteHolder._Weapon.WeaponData,
                hasSuppressor = suppressorFeatureScriptable.IsOpen,
                hasFlashLight = flashLightFeatureScriptable.IsOpen,
            };
            FileHandler.SaveToJSON(data, weaponTypeScriptable.WeaponName);
        }

        private void OnDisable()
        {
            Save();
        }

        [System.Serializable]
        public class Data
        {
            public WeaponDataSaveable weaponDataSaveable;
            public bool hasSuppressor;
            public bool hasFlashLight;
        }
    }
}