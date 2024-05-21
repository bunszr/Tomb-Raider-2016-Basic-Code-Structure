using TMPro;
using UnityEngine.EventSystems;

namespace CampSite
{
    public class ShowFeatureInfoCommandView : CampsiteButtonCommandBase
    {
        TextMeshProUGUI nameText;
        TextMeshProUGUI descriptionText;

        public ShowFeatureInfoCommandView(CSBBase csbBase, TextMeshProUGUI nameText, TextMeshProUGUI descriptionText) : base(csbBase)
        {
            this.nameText = nameText;
            this.descriptionText = descriptionText;
        }

        protected override void OnPointerEnter(PointerEventData eventData)
        {
            base.OnPointerEnter(eventData);
            nameText.text = csbBase.FeatureTypeScriptable.FeatureName;
            descriptionText.text = csbBase.FeatureTypeScriptable.Description;
        }
    }
}