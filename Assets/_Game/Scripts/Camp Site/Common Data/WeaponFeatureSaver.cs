using UnityEngine;
using Zenject;

namespace CampSite
{
    public class WeaponFeatureSaver : MonoBehaviour
    {
        [Inject] protected CampSiteHolder campSiteHolder;
        public WeaponTypeScriptable weaponTypeScriptable;
    }
}