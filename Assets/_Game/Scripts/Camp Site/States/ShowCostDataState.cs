using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CampSite
{
    public class ShowCostDataState : CSBStateBase
    {
        float defaultLocalX;
        Color defaultColor;
        WeaponFeatureTypeScriptable weaponFeatureTypeScriptable;
        CostAndInventoryPanel costAndInventoryPanel;

        GameDataScriptable.CampSiteScriptableData.ShowCostAndInventoryScriptableData ScriptableData => GameDataScriptable.Ins.campSiteScriptableData.showCostAndInventoryScriptableData;


        public ShowCostDataState(MonoBehaviour mono, bool needsExitTime = false, bool isGhostState = false) : base(mono, needsExitTime, isGhostState) { }

        public override void Init()
        {
            costAndInventoryPanel = campSiteHolder.CostAndInventoryPanel;
            weaponFeatureTypeScriptable = csbBase.FeatureTypeScriptable as WeaponFeatureTypeScriptable;
            csbBase.GetComponent<CSBFeatureBase>().NoRequirementsImage.gameObject.SetActive(true);
            defaultLocalX = costAndInventoryPanel.transform.localPosition.x;
            defaultColor = costAndInventoryPanel.costAndInventoryGroups[0].costText.color;
            costAndInventoryPanel.canvasGroup.alpha = 0;
        }

        public override void OnEnter()
        {
            SubcribeButtonEvents();
            buttonEvents.onPointerClickEvent += OnClick;
        }

        public override void OnExit()
        {
            UnSubcribeButtonEvents();
            buttonEvents.onPointerClickEvent += OnClick;
        }

        protected override void OnPointerEnter(PointerEventData eventData)
        {
            int count = Mathf.Min(weaponFeatureTypeScriptable.costDatas.Length, costAndInventoryPanel.costAndInventoryGroups.Length);
            for (int i = 0; i < count; i++)
            {
                CostAndInventoryGroup costAndInventoryGroup = costAndInventoryPanel.costAndInventoryGroups[i];
                costAndInventoryGroup.image.sprite = weaponFeatureTypeScriptable.costDatas[i].inventoryItem.Icon;
                costAndInventoryGroup.costText.text = weaponFeatureTypeScriptable.costDatas[i].costQuantity + "";
                costAndInventoryGroup.inventoryQuantityText.text = weaponFeatureTypeScriptable.costDatas[i].inventoryItem.Quantity + "";

                if (weaponFeatureTypeScriptable.costDatas[i].costQuantity < weaponFeatureTypeScriptable.costDatas[i].inventoryItem.Quantity)
                {
                    costAndInventoryGroup.costText.color = Color.red;
                }
            }

            // Disable third costAndInventoryGroups
            for (int i = count; i < costAndInventoryPanel.costAndInventoryGroups.Length; i++)
            {
                costAndInventoryPanel.costAndInventoryGroups[i].gameObject.SetActive(false);
            }

            costAndInventoryPanel.canvasGroup.DOFade(1, ScriptableData.fadeDuration).From(0).SetEase(ScriptableData.fadeEase);
            costAndInventoryPanel.canvasGroup.transform.DOLocalMoveX(ScriptableData.posAnimationAmount, ScriptableData.posAnimationDuration).SetEase(ScriptableData.posAnimEase).From(true);
        }

        protected override void OnPointerExit(PointerEventData eventData)
        {
            costAndInventoryPanel.canvasGroup.DOKill();
            costAndInventoryPanel.canvasGroup.transform.DOKill();

            costAndInventoryPanel.canvasGroup.alpha = 0;
            costAndInventoryPanel.canvasGroup.transform.SetLocalPosX(defaultLocalX);

            for (int i = 0; i < costAndInventoryPanel.costAndInventoryGroups.Length; i++)
            {
                costAndInventoryPanel.costAndInventoryGroups[i].costText.color = defaultColor;
                costAndInventoryPanel.costAndInventoryGroups[i].transform.SetLocalPosZ(0);
            }
        }

        void OnClick(PointerEventData pointerEventData)
        {
            HighlightIfCostNotEnough();
        }

        void HighlightIfCostNotEnough()
        {
            for (int i = 0; i < costAndInventoryPanel.costAndInventoryGroups.Length; i++)
            {
                if (costAndInventoryPanel.costAndInventoryGroups[i].costText.color == Color.red)
                {
                    costAndInventoryPanel.costAndInventoryGroups[i].transform.DOLocalMoveZ(-.2f, .2f).SetEase(Ease.Flash, 2).From(0);
                }
            }
        }
    }
}