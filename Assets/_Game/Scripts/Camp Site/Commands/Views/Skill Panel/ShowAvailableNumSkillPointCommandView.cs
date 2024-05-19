using UnityEngine;
using DG.Tweening;
using UnityEngine.EventSystems;
using TMPro;
using UniRx;

namespace CampSite
{
    public class ShowAvailableNumSkillPointCommandView : CampsiteButtonCommandBase
    {
        TextMeshProUGUI numText;
        ReactiveProperty<int> numSkillPoint;

        public ShowAvailableNumSkillPointCommandView(CSBBase csbBase, TextMeshProUGUI numText, ReactiveProperty<int> numSkillPoint) : base(csbBase)
        {
            this.numText = numText;
            this.numSkillPoint = numSkillPoint;
        }

        public override void OnActivate()
        {
            base.OnActivate();
            numText.text = numSkillPoint.Value.ToString();
        }
    }
}