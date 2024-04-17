using System.Linq;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CampSite
{
    public class RequirementsState : CSBStateBase
    {
        string description;
        TextMeshProUGUI requirementsText;

        public RequirementsState(MonoBehaviour mono, TextMeshProUGUI requirementsText, bool needsExitTime = false, bool isGhostState = false) : base(mono, needsExitTime, isGhostState)
        {
            this.requirementsText = requirementsText;
        }

        public override void Init()
        {
            var array = csbBase.FeatureTypeScriptable.RequirementsScriptableBases.Select(x => x.Description);
            description = string.Join(", ", array);
            csbBase.GetComponent<CSBFeatureBase>().NoRequirementsImage.gameObject.SetActive(true);
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
            requirementsText.text = description;
        }

        protected override void OnPointerExit(PointerEventData eventData)
        {
            requirementsText.text = "No Requirements";
            requirementsText.transform.DOKill();
            requirementsText.transform.SetLocalPosZ(0);
        }

        void OnClick(PointerEventData pointerEventData)
        {
            requirementsText.transform.DOLocalMoveZ(-.2f, .2f).SetEase(Ease.Flash, 2).From(0);
        }
    }
}