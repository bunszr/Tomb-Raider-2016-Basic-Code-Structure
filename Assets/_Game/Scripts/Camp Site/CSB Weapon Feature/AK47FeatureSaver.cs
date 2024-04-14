using Sirenix.OdinInspector;

namespace CampSite
{
    public class AK47FeatureSaver : WeaponFeatureSaver
    {
        public CSBSaveable suppressorCSBSaveable;
        public CSBSaveable flashLightCSBSaveable;

        [Button]
        void Save()
        {
            Data data = new Data()
            {
                weaponDataSaveable = campSiteHolder._Weapon.WeaponData,
                hasSuppressor = campSiteHolder.DictionaryFeatureData[suppressorCSBSaveable.featureDataSaveable.Guid].IsOpen,
                hasFlashLight = campSiteHolder.DictionaryFeatureData[flashLightCSBSaveable.featureDataSaveable.Guid].IsOpen,
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