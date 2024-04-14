using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CampSite
{
    public class FeatureInformationPanelHolder : MonoBehaviour
    {
        public Tween tweenForActivate;
        public CanvasGroup canvasGroup;
        public TextMeshProUGUI nameText;
        public TextMeshProUGUI descriptionText;
        public TextMeshProUGUI requirementsText;
    }
}