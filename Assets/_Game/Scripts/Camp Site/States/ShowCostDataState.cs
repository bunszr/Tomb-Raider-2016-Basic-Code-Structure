using System.Linq;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UniRx;

namespace CampSite
{
    public class ShowCostDataState : CSBStateBase
    {
        float defaultLocalX;
        Color defaultColor;
        WeaponFeatureTypeScriptable weaponFeatureTypeScriptable;
        CostAndInventoryPanel costAndInventoryPanel;

        CompositeDisposable disposablesForInventoryCostItemChanged = new CompositeDisposable();

        GameDataScriptable.CampSiteScriptableData.ShowCostAndInventoryScriptableData ScriptableData => GameDataScriptable.Ins.campSiteScriptableData.showCostAndInventoryScriptableData;


        public ShowCostDataState(MonoBehaviour mono, bool needsExitTime = false, bool isGhostState = false) : base(mono, needsExitTime, isGhostState) { }

        public override void Init()
        {
            costAndInventoryPanel = campSiteHolder.CostAndInventoryPanel;
            weaponFeatureTypeScriptable = csbBase.FeatureTypeScriptable as WeaponFeatureTypeScriptable;
            defaultLocalX = costAndInventoryPanel.transform.localPosition.x;
            defaultColor = costAndInventoryPanel.groups[0].costText.color;
            costAndInventoryPanel.canvasGroup.alpha = 0;

            foreach (var item in weaponFeatureTypeScriptable.costDatas.Select(x => x.inventoryItem))
            {
                item.QuantityRP.Subscribe(OnInventoryCostItemChanged).AddTo(disposablesForInventoryCostItemChanged);
            }
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
            SetDefault();

            disposablesForInventoryCostItemChanged.Dispose();
        }

        protected override void OnPointerEnter(PointerEventData eventData)
        {
            int count = Mathf.Min(weaponFeatureTypeScriptable.costDatas.Length, costAndInventoryPanel.groups.Length);
            for (int i = 0; i < count; i++)
            {
                CostAndInventoryGroup costAndInventoryGroup = costAndInventoryPanel.groups[i];
                costAndInventoryGroup.image.sprite = weaponFeatureTypeScriptable.costDatas[i].inventoryItem.Icon;
                costAndInventoryGroup.costText.text = weaponFeatureTypeScriptable.costDatas[i].costQuantity + "";
                costAndInventoryGroup.inventoryQuantityText.text = weaponFeatureTypeScriptable.costDatas[i].inventoryItem.QuantityRP.Value + "";

                if (weaponFeatureTypeScriptable.costDatas[i].costQuantity > weaponFeatureTypeScriptable.costDatas[i].inventoryItem.QuantityRP.Value)
                {
                    costAndInventoryGroup.costText.color = Color.red;
                }
                costAndInventoryGroup.gameObject.SetActive(true);
            }

            // Disable third costAndInventoryGroups
            for (int i = count; i < costAndInventoryPanel.groups.Length; i++)
            {
                costAndInventoryPanel.groups[i].gameObject.SetActive(false);
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

            SetDefault();
        }

        void SetDefault()
        {
            for (int i = 0; i < costAndInventoryPanel.groups.Length; i++)
            {
                costAndInventoryPanel.groups[i].costText.color = defaultColor;
                costAndInventoryPanel.groups[i].transform.SetLocalPosZ(0);
                costAndInventoryPanel.groups[i].gameObject.SetActive(false);
            }
        }

        void OnClick(PointerEventData pointerEventData)
        {
            HighlightIfCostNotEnough();
        }

        void HighlightIfCostNotEnough()
        {
            for (int i = 0; i < costAndInventoryPanel.groups.Length; i++)
            {
                if (costAndInventoryPanel.groups[i].costText.color == Color.red)
                {
                    costAndInventoryPanel.groups[i].transform.DOLocalMoveZ(-.2f, .2f).SetEase(Ease.Flash, 2).From(0);
                }
            }
        }

        void OnInventoryCostItemChanged(int count)
        {
            if (!weaponFeatureTypeScriptable.HasEnoughQuantityToBuy()) csbBase.featureNameText.color = Color.red;
        }
    }
}