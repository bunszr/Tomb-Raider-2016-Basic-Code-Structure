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
        public GameObject popUpGo;
        public GameObject notAllowedGo;

        public CanvasGroup takenItemCanvasGroup;
        public TextMeshProUGUI takenItemCountText;

        public Image[] itemImages;

        public int ItemCountToTake { get => itemCountToTake; }

        public GameObject PopUpGo => popUpGo;
        public GameObject NotAllowedGo => notAllowedGo;
    }
}