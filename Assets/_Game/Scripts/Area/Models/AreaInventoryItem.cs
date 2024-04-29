using Inventory;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TriggerableAreaNamespace
{
    public class AreaInventoryItem : AreaBase, ITriggerablePopUp, INotAllowedTriggerable
    {
        public InventoryItemScriptableBase inventoryItemScriptableBase;
        [SerializeField] int itemCountToTake = 1;
        public TextMeshProUGUI areaNameText;
        public GameObject pressKeyGo;
        public GameObject fullInventoryShowerGo;

        public CanvasGroup takenItemCanvasGroup;
        public TextMeshProUGUI takenItemCountText;

        public Image[] itemImages;

        public int ItemCountToTake { get => itemCountToTake; }

        public GameObject PopUpGo => pressKeyGo;
        public bool HasPopUp => inventoryItemScriptableBase.QuantityRP.Value < inventoryItemScriptableBase.MaxQuantity;

        public GameObject NotAllowedGo => fullInventoryShowerGo;
        public bool NotAllowedCondition => inventoryItemScriptableBase.QuantityRP.Value >= inventoryItemScriptableBase.MaxQuantity;
    }
}