using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using TMPro;
using UniRx;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace CampSite
{
    public class ShowAndHighlightRequirementsCommandView : CampsiteButtonCommandBase
    {
        string description;
        Image lockImage;
        TextMeshProUGUI requirementsText;
        FeatureTypeScriptable featureTypeScriptable;

        CompositeDisposable disposablesForOnRequiringFeatureChange = new CompositeDisposable();

        GameDataScriptable.CampSiteScriptableData.RequirementsScriptableData Data => GameDataScriptable.Ins.campSiteScriptableData.requirementsScriptableData;

        public ShowAndHighlightRequirementsCommandView(CSBBase csbBase, TextMeshProUGUI requirementsText, FeatureTypeScriptable featureTypeScriptable, Image lockImage) : base(csbBase)
        {
            this.requirementsText = requirementsText;
            this.featureTypeScriptable = featureTypeScriptable;
            this.lockImage = lockImage;

            var array = featureTypeScriptable.RequirementsScriptableBases.Select(x => x.Description);
            description = string.Join(", ", array);
        }

        public override void OnActivate()
        {
            base.OnActivate();
            lockImage.gameObject.SetActive(true);
            buttonEvents.onPointerClickEvent += OnClick;
        }

        public override void OnDeactivate()
        {
            base.OnDeactivate();
            lockImage.gameObject.SetActive(false);
            buttonEvents.onPointerClickEvent -= OnClick;
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
            requirementsText.transform.DOLocalMoveZ(Data.zPos, Data.duration).SetEase(Ease.Flash, 2).From(0);
        }
    }
}