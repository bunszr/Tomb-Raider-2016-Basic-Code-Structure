using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace CampSite
{
    public class CSBFeatureSaver : MonoBehaviour
    {
        string fileName = "Camp Site";

        [Inject] CampSiteHolder campSiteHolder;
        CSBSaveable[] cSBSaveables;

        private void Awake()
        {
            cSBSaveables = GetComponentsInChildren<CSBSaveable>();
            Check();
            Load();
        }

        private void OnDisable()
        {
            Save();
        }

        public void Check()
        {
            if (cSBSaveables.Any(x => x.featureDataSaveable.Guid == string.Empty))
            {
                Debug.LogError("Assing new guid to weapon");
                return;
            }
        }

        [Button]
        private void Save()
        {
            List<Wrap> wraps = new List<Wrap>(cSBSaveables.Select(x => new Wrap(x.GetComponent<ICSBSaveable>().CSBName, x.featureDataSaveable.Guid, x.featureDataSaveable.IsOpen)));
            FileHandler.SaveToJSON<Wrap>(wraps, fileName);
        }

        [Button]
        private void Load()
        {
            List<Wrap> wraps = FileHandler.ReadListFromJSON<Wrap>(fileName);
            if (wraps.Count == 0)
            {
                wraps = new List<Wrap>(cSBSaveables.Select(x => new Wrap(x.GetComponent<ICSBSaveable>().CSBName, x.featureDataSaveable.Guid, x.featureDataSaveable.IsOpen)));
                FileHandler.SaveToJSON<Wrap>(wraps, fileName);
                Debug.Log("wrap is null");
            }

            campSiteHolder.DictionaryFeatureData = wraps.Select(x => new FeatureDataSaveable(x.guid, x.isOpen)).ToDictionary(x => x.Guid, y => y);

            foreach (var csbSaveable in cSBSaveables)
            {
                if (campSiteHolder.DictionaryFeatureData.TryGetValue(csbSaveable.featureDataSaveable.Guid, out FeatureDataSaveable featureDataSaveable))
                {
                    csbSaveable.featureDataSaveable = featureDataSaveable;
                }
            }
        }

        [System.Serializable]
        public class Wrap
        {
            public string name;
            public string guid;
            public bool isOpen;

            public Wrap(string name, string guid, bool isOpen)
            {
                this.name = name;
                this.guid = guid;
                this.isOpen = isOpen;
            }
        }

#if UNITY_EDITOR
        [Button]
        private void CreateGuidIfNotExist()
        {
            foreach (var csbSaveable in GetComponentsInChildren<CSBSaveable>())
            {
                bool hasCreated = csbSaveable.featureDataSaveable.CreateGuidIfNotExist();
                if (hasCreated) UnityEditor.EditorUtility.SetDirty(csbSaveable);
            }
        }

        [Button]
        private void CreateNewGuid()
        {
            foreach (var csbSaveable in GetComponentsInChildren<CSBSaveable>())
            {
                csbSaveable.featureDataSaveable.CreateNewGuid();
                UnityEditor.EditorUtility.SetDirty(csbSaveable);
            }
        }
#endif
    }
}