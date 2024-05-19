using UnityEngine;
using DG.Tweening;
using UnityEngine.EventSystems;

namespace CampSite
{
    public class ShowOnlyCostDataCommandView : CampsiteButtonCommandBase
    {
        float defaultLocalX;
        CostAndInventoryPanel costAndInventoryPanel;

        public ShowOnlyCostDataCommandView(CSBBase csbBase, CostAndInventoryPanel costAndInventoryPanel) : base(csbBase)
        {
            this.costAndInventoryPanel = costAndInventoryPanel;
            defaultLocalX = costAndInventoryPanel.transform.localPosition.x;
        }

        GameDataScriptable.CampSiteScriptableData.ShowCostAndInventoryScriptableData ScriptableData => GameDataScriptable.Ins.campSiteScriptableData.showCostAndInventoryScriptableData;

        protected override void OnPointerEnter(PointerEventData eventData)
        {
            base.OnPointerEnter(eventData);
            costAndInventoryPanel.canvasGroup.DOFade(1, ScriptableData.fadeDuration).From(0).SetEase(ScriptableData.fadeEase);
            costAndInventoryPanel.canvasGroup.transform.DOLocalMoveX(ScriptableData.posAnimationAmount, ScriptableData.posAnimationDuration).SetEase(ScriptableData.posAnimEase).From(true);
            ChangeActivatetionCostAndInventoryGroups(false);
        }

        protected override void OnPointerExit(PointerEventData eventData)
        {
            base.OnPointerExit(eventData);
            costAndInventoryPanel.canvasGroup.DOKill();
            costAndInventoryPanel.canvasGroup.transform.DOKill();

            costAndInventoryPanel.canvasGroup.alpha = 0;
            costAndInventoryPanel.canvasGroup.transform.SetLocalPosX(defaultLocalX);
            ChangeActivatetionCostAndInventoryGroups(true);
        }

        void ChangeActivatetionCostAndInventoryGroups(bool isActive)
        {
            for (int i = 0; i < costAndInventoryPanel.groups.Length; i++)
            {
                costAndInventoryPanel.groups[i].gameObject.SetActive(isActive);
            }
        }
    }
}