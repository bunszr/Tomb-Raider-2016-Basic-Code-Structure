using UnityEngine;
using Zenject;

namespace CampSite
{
    public class CSBWeapon : CampSiteButtonBase
    {
        [Inject] public IWeaponToggler _weaponToggler;

        public WeaponTypeScriptable weaponTypeScriptable;
        public HighlightState.HighlightStateData highlightStateData;
        public ClickState.ClickStateData clickStateData;
    }
}