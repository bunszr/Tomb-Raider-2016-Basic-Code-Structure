using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace CampSite
{
    public class CSBWeaponSelector : CSBBase
    {
        [Inject] public IWeaponToggler _weaponToggler;

        public GameObject weaponFeatureButtonsHolderGo;
        public Image lockImage;
        public Image highlightImage;
        public GameObject nextPanelTogglerGO;
    }
}