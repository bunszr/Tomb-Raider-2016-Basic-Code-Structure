using UnityEngine;
using TMPro;
using UniRx;
using UnityEngine.EventSystems;
using DG.Tweening;

namespace CampSite
{
    public class SkillPointCostCommandView : CampsiteButtonCommandBase
    {
        [System.Serializable]
        public class SkillPointCostCommandViewData
        {
            public float zPos = 30f;
            public float duration = .2f;
        }

        TextMeshProUGUI numText;
        SkillFeatureTypeScriptable skillFeatureTypeScriptable;
        ReactiveProperty<int> numSkillPointRP;
        SkillPointCostCommandViewData data;

        public SkillPointCostCommandView(CSBBase csbBase, TextMeshProUGUI numText, ReactiveProperty<int> numSkillPointRP, SkillPointCostCommandViewData data) : base(csbBase)
        {
            this.numText = numText;
            skillFeatureTypeScriptable = csbBase.FeatureTypeScriptable as SkillFeatureTypeScriptable;
            this.numSkillPointRP = numSkillPointRP;
            this.data = data;
        }

        public override void OnActivate()
        {
            base.OnActivate();
            buttonEvents.onPointerClickEvent += OnClick;
        }

        public override void OnDeactivate()
        {
            base.OnDeactivate();
            buttonEvents.onPointerClickEvent -= OnClick;
        }

        protected override void OnPointerEnter(PointerEventData eventData)
        {
            base.OnPointerEnter(eventData);
            numText.text = skillFeatureTypeScriptable.SkillCostAmount.ToString();
            numText.color = skillFeatureTypeScriptable.SkillCostAmount > numSkillPointRP.Value ? Color.red : numText.color;
        }

        protected override void OnPointerExit(PointerEventData eventData)
        {
            base.OnPointerExit(eventData);
            numText.transform.transform.SetLocalPosZ(0);
        }

        void OnClick(PointerEventData pointerEventData)
        {
            if (skillFeatureTypeScriptable.SkillCostAmount > numSkillPointRP.Value)
                numText.transform.DOLocalMoveZ(data.zPos, data.duration).SetEase(Ease.Flash, 2).From(0);
        }
    }
}