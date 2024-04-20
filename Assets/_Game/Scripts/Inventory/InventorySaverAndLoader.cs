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
            if (!GameDataScriptable.Ins.loadInventoryFromJSONinEditor) LoadFromScriptable();
            else LoadFromJSON();
#else
            LoadFromJSON();
#endif
        }

        private void OnDisable() => Save();

        private void Save()
        {
            List<Wrap> wraps = inventoryItemScriptableBasees.Select(x => new Wrap(x.ItemName, x.Hash, x.QuantityRP.Value)).ToList();
            FileHandler.SaveToJSON<Wrap>(wraps, fileName);
        }

        private void LoadFromScriptable() => inventoryItemScriptableBasees.Foreach(x => x.LoadFromItSelf());

        private void LoadFromJSON()
        {
            List<Wrap> wraps = FileHandler.ReadListFromJSON<Wrap>(fileName);
            if (wraps.Count == 0) return;

            Dictionary<int, int> dic = wraps.ToDictionary(x => x.hash, y => y.quantity);

            foreach (var item in inventoryItemScriptableBasees)
            {
                if (dic.TryGetValue(item.Hash, out int outQuantity)) item.Load(outQuantity);
                else item.LoadFromItSelf();
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