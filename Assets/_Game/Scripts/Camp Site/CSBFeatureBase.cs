using UnityEngine;
using UnityEngine.UI;

namespace CampSite
{
    public class CSBFeatureBase : CampSiteButtonBase
    {
        [SerializeField] Image noRequirementsImage;

        public Image NoRequirementsImage { get => noRequirementsImage; }
    }
}