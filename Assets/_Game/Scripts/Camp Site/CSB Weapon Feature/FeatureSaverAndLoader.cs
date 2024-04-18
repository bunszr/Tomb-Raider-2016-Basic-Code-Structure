using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using UnityEngine;

// This class execute from "RuntimeInitializeOnLoadMethodClass" class

namespace CampSite
{
    public class FeatureSaverAndLoader : MonoBehaviour
    {
        [ReadOnly, ShowInInspector] string fileName = "Camp Site";
        [ReadOnly, ShowInInspector] FeatureTypeScriptable[] featureTypeScriptables;

        void Awake()
        {
            featureTypeScriptables = Resources.LoadAll<FeatureTypeScriptable>("");
#if UNITY_EDITOR
            if (!GameDataScriptable.Ins.LoadFeatureFromJSONinEditor)
                LoadFromScriptable();
            else
                LoadFromJSON();
#else
            LoadFromJSON();
#endif
        }

        private void OnDisable()
        {
            Save();
        }

        // [Button]
        private void Save()
        {
            List<Wrap> wraps = featureTypeScriptables.Select(x => new Wrap(x.name, x.Hash, x.IsOpen)).ToList();
            FileHandler.SaveToJSON<Wrap>(wraps, fileName);
        }

        // [Button]
        private void LoadFromScriptable()
        {
            featureTypeScriptables.Foreach(x => x.Load(x.IsOpen));
        }

        // [Button]
        private void LoadFromJSON()
        {
            List<Wrap> wraps = FileHandler.ReadListFromJSON<Wrap>(fileName);
            if (wraps.Count == 0)
            {
                wraps = new List<Wrap>(featureTypeScriptables.Select(x => new Wrap(x.name, x.Hash, x.IsOpen)));
                FileHandler.SaveToJSON<Wrap>(wraps, fileName);
            }

            Dictionary<int, bool> dic = wraps.ToDictionary(x => x.hash, y => y.isOpen);

            foreach (var feature in featureTypeScriptables)
            {
                if (dic.TryGetValue(feature.Hash, out bool outIsOpen))
                {
                    feature.Load(outIsOpen);
                }
                else
                {
                    feature.Load(feature.IsOpen);
                }
            }
        }

        [System.Serializable]
        public class Wrap
        {
            public string name;
            public int hash;
            public bool isOpen;

            public Wrap(string name, int hash, bool isOpen)
            {
                this.name = name;
                this.hash = hash;
                this.isOpen = isOpen;
            }
        }
    }
}