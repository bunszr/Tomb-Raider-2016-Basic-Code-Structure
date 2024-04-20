using Sirenix.OdinInspector;
using UniRx;
using UnityEngine;

namespace Inventory
{
    [InlineEditor]
    public abstract class InventoryItemScriptableBase : ScriptableObject
    {
        [ReadOnly] int hash;
        [VerticalGroup("row1/left"), SerializeField] string itemName;
        [VerticalGroup("row1/left"), SerializeField] string description = "Description";
        [VerticalGroup("row1/left"), SerializeField] int quantity;
        [SerializeField, HorizontalGroup("row1", 30), VerticalGroup("row1/right"), PreviewField(60), HideLabel] Sprite icon;

        public int Hash { get => hash; }
        public string ItemName { get => itemName; }
        public string Description { get => description; }
        public Sprite Icon { get => icon; }

        [ReadOnly, ShowInInspector] public ReactiveProperty<int> QuantityRP { get; private set; }

        public void Load(int quantityPram) => QuantityRP = new ReactiveProperty<int>(quantityPram);
        public void LoadFromItSelf() => QuantityRP = new ReactiveProperty<int>(quantity);

#if UNITY_EDITOR
        private void Awake() => hash = GetInstanceID();
#endif
    }
}