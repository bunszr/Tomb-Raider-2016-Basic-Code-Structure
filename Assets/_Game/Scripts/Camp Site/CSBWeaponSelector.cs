using UnityEngine;
using Zenject;

namespace CampSite
{
    public class CSBWeaponSelector : CampSiteButtonBase
    {
        [Inject] public IWeaponToggler _weaponToggler;

        public WeaponDataScriptable weaponDataScriptable;
        public HighlightState.HighlightStateData highlightStateData;
        public ClickState.ClickStateData clickStateData;
    }
}