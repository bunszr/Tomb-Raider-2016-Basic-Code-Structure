using TMPro;
using UnityEngine;

namespace CampSite
{
    public class CSSkillInfoPanel : MonoBehaviour
    {
        public CanvasGroup canvasGroup;
        public SkillInfoPanel skillInfoPanel;
        public SkillCostPanel skillCostPanel;
        public AvailableSkillPanel availableSkillPanel;
        public RequirementSkillPanel requirementSkillPanel;

        [System.Serializable]
        public class SkillInfoPanel
        {
            public TextMeshProUGUI skillNameText;
            public TextMeshProUGUI skillDescriptionText;
        }

        [System.Serializable]
        public class SkillCostPanel
        {
            public CanvasGroup canvasGroup;
            public TextMeshProUGUI numSkillPointText;
        }

        [System.Serializable]
        public class AvailableSkillPanel
        {
            public TextMeshProUGUI numSkillPointText;
        }

        [System.Serializable]
        public class RequirementSkillPanel
        {
            public TextMeshProUGUI requirementText;
        }
    }
}