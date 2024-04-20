using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CampSite
{
    public class ShowOnlyCostDataState : CSBStateBase
    {
        float defaultLocalX;
        GameDataScriptable.CampSiteScriptableData.ShowCostAndInventoryScriptableData ScriptableData => GameDataScriptable.Ins.campSiteScriptableData.showCostAndInventoryScriptableData;

        public ShowOnlyCostDataState(MonoBehaviour mono, bool needsExitTime = false, bool isGhostState = false) : base(mono, needsExitTime, isGhostState) { }

        public override void Init()
        {
            defaultLocalX = campSiteHolder.CostAndInventoryPanel.transform.localPosition.x;
        }

        public override void OnEnter()
        {
            SubcribeButtonEvents();
        }


        public override void OnExit() => UnSubcribeButtonEvents();

        protected override void OnPointerEnter(PointerEventData eventData)
        {
            campSiteHolder.CostAndInventoryPanel.canvasGroup.DOFade(1, ScriptableData.fadeDuration).From(0).SetEase(ScriptableData.fadeEase);
            campSiteHolder.CostAndInventoryPanel.canvasGroup.transform.DOLocalMoveX(ScriptableData.posAnimationAmount, ScriptableData.posAnimationDuration).SetEase(ScriptableData.posAnimEase).From(true);
            ChangeActivatetionCostAndInventoryGroups(false);
        }

        protected override void OnPointerExit(PointerEventData eventData)
        {
            campSiteHolder.CostAndInventoryPanel.canvasGroup.DOKill();
            campSiteHolder.CostAndInventoryPanel.canvasGroup.transform.DOKill();

            campSiteHolder.CostAndInventoryPanel.canvasGroup.alpha = 0;
            campSiteHolder.CostAndInventoryPanel.canvasGroup.transform.SetLocalPosX(defaultLocalX);
            ChangeActivatetionCostAndInventoryGroups(true);
        }

        void ChangeActivatetionCostAndInventoryGroups(bool isActive)
        {
            for (int i = 0; i < campSiteHolder.CostAndInventoryPanel.groups.Length; i++)
            {
                campSiteHolder.CostAndInventoryPanel.groups[i].gameObject.SetActive(isActive);
            }
        }
    }
}