using DG.Tweening;
using UnityEngine;

namespace TriggerableAreaNamespace
{
    public class TakenInventoryItemViewCommand : IAreaCommad
    {
        AreaInventoryItem areaInventoryItem;
        Vector3 defaulLocalPos;

        public TakenInventoryItemViewCommand(AreaInventoryItem areaInventoryItem)
        {
            this.areaInventoryItem = areaInventoryItem;
            defaulLocalPos = areaInventoryItem.takenItemCanvasGroup.transform.localPosition;
        }

        public void Enter()
        {
            int maxTakeableItemCount = areaInventoryItem.inventoryItemScriptableBase.MaxQuantity - areaInventoryItem.inventoryItemScriptableBase.QuantityRP.Value;
            areaInventoryItem.takenItemCountText.text = "+" + Mathf.Min(maxTakeableItemCount, areaInventoryItem.ItemCountToTake);
            areaInventoryItem.takenItemCanvasGroup.gameObject.SetActive(true);
            areaInventoryItem.takenItemCanvasGroup.DOFade(1, .4f).From(0);
            areaInventoryItem.takenItemCanvasGroup.transform.DOLocalMoveY(100, .5f).SetRelative(true).From(defaulLocalPos).OnComplete(() =>
            {
                areaInventoryItem.takenItemCanvasGroup.gameObject.SetActive(false);
            });
        }
        public void Exit() { }

        public TaskStatusEnum OnUpdate() => TaskStatusEnum.Success;
    }
}