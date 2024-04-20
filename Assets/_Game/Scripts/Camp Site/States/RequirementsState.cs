using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CampSite
{
    public class RequirementsState : CSBStateBase
    {
        string description;
        TextMeshProUGUI requirementsText;
        CompositeDisposable disposablesForOnRequiringFeatureChange = new CompositeDisposable();

        public RequirementsState(MonoBehaviour mono, TextMeshProUGUI requirementsText, bool needsExitTime = false, bool isGhostState = false) : base(mono, needsExitTime, isGhostState)
        {
            this.requirementsText = requirementsText;
        }

        public override void Init()
        {
            var array = csbBase.FeatureTypeScriptable.RequirementsScriptableBases.Select(x => x.Description);
            description = string.Join(", ", array);

            // It might be opened some requirements when upgrade some feature. We must listen our requiring feature
            foreach (var featureType in GetRequringFeatureTypes())
            {
                featureType.IsOpenRP.Subscribe(OnRequiringFeatureChange).AddTo(disposablesForOnRequiringFeatureChange);
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

            disposablesForOnRequiringFeatureChange.Dispose();
        }

        protected override void OnPointerEnter(PointerEventData eventData)
        {
            requirementsText.text = description;
        }

        protected override void OnPointerExit(PointerEventData eventData)
        {
            requirementsText.text = "";
            requirementsText.transform.DOKill();
            requirementsText.transform.SetLocalPosZ(0);
        }

        void OnClick(PointerEventData pointerEventData)
        {
            requirementsText.transform.DOLocalMoveZ(-.2f, .2f).SetEase(Ease.Flash, 2).From(0);
        }

        void OnRequiringFeatureChange(bool isOpen)
        {
            bool areRequirementsDone = csbBase.FeatureTypeScriptable.AreRequirementsDone();
            csbBase.GetComponent<CSBFeatureBase>().requirementsImage.gameObject.SetActive(!areRequirementsDone);
            description = areRequirementsDone ? "" : description;
        }

        IEnumerable<FeatureTypeScriptable> GetRequringFeatureTypes() => csbBase.FeatureTypeScriptable.RequirementsScriptableBases
            .Where(x => x is FeatureRequirements)
            .Select(x => x as FeatureRequirements)
            .SelectMany(x => x.requireFeatureTypeScriptables);
    }
}