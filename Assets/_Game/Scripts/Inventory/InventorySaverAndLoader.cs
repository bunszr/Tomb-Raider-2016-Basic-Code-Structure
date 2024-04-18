using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using UnityEngine;

// This class execute from "RuntimeInitializeOnLoadMethodClass" class

namespace Inventory
{
    public class InventorySaverAndLoader : MonoBehaviour
    {
        [ReadOnly, ShowInInspector] string fileName = "Inventory";
        [ReadOnly, ShowInInspector] InventoryItemScriptableBase[] inventoryItemScriptableBasees;

        void Awake()
        {
            inventoryItemScriptableBasees = Resources.LoadAll<InventoryItemScriptableBase>("");
#if UNITY_EDITOR
            if (!GameDataScriptable.Ins.LoadInventoryFromJSONinEditor) LoadFromScriptable();
            else LoadFromJSON();
#else
            LoadFromJSON();
#endif
        }

        private void OnDisable() => Save();

        private void Save()
        {
            List<Wrap> wraps = inventoryItemScriptableBasees.Select(x => new Wrap(x.ItemName, x.Hash, x.Quantity)).ToList();
            FileHandler.SaveToJSON<Wrap>(wraps, fileName);
        }

        private void LoadFromScriptable() => inventoryItemScriptableBasees.Foreach(x => x.Load(x.Quantity));

        private void LoadFromJSON()
        {
            List<Wrap> wraps = FileHandler.ReadListFromJSON<Wrap>(fileName);
            if (wraps.Count == 0)
            {
                wraps = new List<Wrap>(inventoryItemScriptableBasees.Select(x => new Wrap(x.ItemName, x.Hash, x.Quantity)));
                FileHandler.SaveToJSON<Wrap>(wraps, fileName);
            }

            Dictionary<int, int> dic = wraps.ToDictionary(x => x.hash, y => y.quantity);

            foreach (var feature in inventoryItemScriptableBasees)
            {
                if (dic.TryGetValue(feature.Hash, out int outQuantity)) feature.Load(outQuantity);
                else feature.Load(feature.Quantity);
            }
        }

        [System.Serializable]
        public class Wrap
        {
            public string name;
            public int hash;
            public int quantity;

            public Wrap(string name, int hash, int quantity)
            {
                this.name = name;
                this.hash = hash;
                this.quantity = quantity;
            }
        }
    }
}