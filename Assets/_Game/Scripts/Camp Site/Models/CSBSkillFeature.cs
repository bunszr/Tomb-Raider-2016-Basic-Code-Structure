using TMPro;
using UnityEngine.UI;

namespace CampSite
{
    public class CSBSkillFeature : CSBBase
    {
        public TextMeshProUGUI featureNameText;
        public Image lockImage;
        public Image tickImage;
        public Image highlightImage;

        public SkillPointCostCommandView.SkillPointCostCommandViewData skillPointCostCommandViewData;
    }
}