using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace CampSite
{
    public class CSBWeaponSelector : CSBFeatureBase
    {
        [Inject] public IWeaponToggler _weaponToggler;

        public GameObject weaponFeatureButtonsHolderGo;
        public Image lockImage;
        public Image highlightImage;
        public GameObject nextPanelTogglerGO;
    }
}