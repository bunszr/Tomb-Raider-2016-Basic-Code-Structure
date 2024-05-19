using DG.Tweening;
using TMPro;
using UnityEngine.EventSystems;

namespace CampSite
{
    public class ShowFeatureInfoCommandView : CampsiteButtonCommandBase
    {
        FeatureTypeScriptable featureTypeScriptable;
        TextMeshProUGUI nameText;
        TextMeshProUGUI descriptionText;

        public ShowFeatureInfoCommandView(CSBBase csbBase, TextMeshProUGUI nameText, TextMeshProUGUI descriptionText) : base(csbBase)
        {
            this.nameText = nameText;
            this.descriptionText = descriptionText;
        }

        protected override void OnPointerEnter(PointerEventData eventData)
        {
            nameText.text = csbBase.FeatureTypeScriptable.FeatureName;
            descriptionText.text = csbBase.FeatureTypeScriptable.Description;
        }
    }
}