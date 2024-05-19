using System.Linq;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UniRx;
using TMPro;

namespace CampSite
{
    public class ShowCostDataCommandView : CampsiteButtonCommandBase
    {
        float defaultLocalX;
        Color defaultColor;
        CostAndInventoryPanel costAndInventoryPanel;
        WeaponFeatureTypeScriptable weaponFeatureTypeScriptable;
        TextMeshProUGUI featureNameText;

        CompositeDisposable disposablesForInventoryCostItemChanged = new CompositeDisposable();

        GameDataScriptable.CampSiteScriptableData.ShowCostAndInventoryScriptableData ScriptableData => GameDataScriptable.Ins.campSiteScriptableData.showCostAndInventoryScriptableData;

        public ShowCostDataCommandView(CSBBase csbBase, CostAndInventoryPanel costAndInventoryPanel, WeaponFeatureTypeScriptable weaponFeatureTypeScriptable, TextMeshProUGUI featureNameText) : base(csbBase)
        {
            this.costAndInventoryPanel = costAndInventoryPanel;
            this.weaponFeatureTypeScriptable = weaponFeatureTypeScriptable;

            defaultLocalX = costAndInventoryPanel.transform.localPosition.x;
            defaultColor = costAndInventoryPanel.groups[0].costText.color;
            costAndInventoryPanel.canvasGroup.alpha = 0;
            this.featureNameText = featureNameText;

        }

        public override void OnActivate()
        {
            base.OnActivate();
            buttonEvents.onPointerClickEvent += OnClick;
            foreach (var item in weaponFeatureTypeScriptable.costDatas.Select(x => x.inventoryItem))
            {
                item.QuantityRP.Subscribe(OnInventoryCostItemChanged).AddTo(disposablesForInventoryCostItemChanged);
            }
        }

        public override void OnDeactivate()
        {
            base.OnDeactivate();
            buttonEvents.onPointerClickEvent -= OnClick;
            SetDefault();

            disposablesForInventoryCostItemChanged.Clear();
        }

        protected override void OnPointerEnter(PointerEventData eventData)
        {
            base.OnPointerEnter(eventData);
            int count = Mathf.Min(weaponFeatureTypeScriptable.costDatas.Length, costAndInventoryPanel.groups.Length);
            for (int i = 0; i < count; i++)
            {
                CostAndInventoryGroup group = costAndInventoryPanel.groups[i];
                group.image.sprite = weaponFeatureTypeScriptable.costDatas[i].inventoryItem.Icon;
                group.costText.text = weaponFeatureTypeScriptable.costDatas[i].costQuantity + "";
                group.inventoryQuantityText.text = weaponFeatureTypeScriptable.costDatas[i].inventoryItem.QuantityRP.Value + "";

                if (weaponFeatureTypeScriptable.costDatas[i].costQuantity > weaponFeatureTypeScriptable.costDatas[i].inventoryItem.QuantityRP.Value)
                {
                    group.costText.color = Color.red;
                }
                group.gameObject.SetActive(true);
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
            base.OnPointerExit(eventData);
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
            if (!weaponFeatureTypeScriptable.HasEnoughQuantityToBuy()) featureNameText.color = Color.red;
        }
    }
}