using UnityEngine;

namespace TriggerableAreaNamespace
{
    public class AreaInventoryItemViewer : MonoBehaviour
    {
        [SerializeField] AreaInventoryItem areaInventoryItem;

        private void Start()
        {
            areaInventoryItem.areaNameText.text = areaInventoryItem.inventoryItemScriptableBase.ItemName;
            areaInventoryItem.itemImages.Foreach(x => x.sprite = areaInventoryItem.inventoryItemScriptableBase.Icon);
        }
    }
}