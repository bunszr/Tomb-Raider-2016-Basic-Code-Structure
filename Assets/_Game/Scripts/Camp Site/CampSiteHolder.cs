using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace CampSite
{
    public class CampSiteHolder : MonoBehaviour
    {
        [SerializeField] Transform weaponShowLocation;
        [SerializeField] Transform charaterStandLocation;
        [SerializeField] WeaponDataSliderHolder weaponDataSliderHolder;
        [SerializeField] FeatureInformationPanelHolder featureInformationPanelHolder;

        [ReadOnly, ShowInInspector] public Dictionary<string, FeatureDataSaveable> DictionaryFeatureData { get; set; }

        public Transform WeaponShowLocation { get => weaponShowLocation; }
        public Transform CharaterStandLocation { get => charaterStandLocation; }
        public WeaponDataSliderHolder WeaponDataSliderHolder { get => weaponDataSliderHolder; }
        public IWeapon _Weapon { get => WeaponShowLocation.GetComponentInChildren<IWeapon>(); }
        public FeatureInformationPanelHolder FeatureInformationPanelHolder { get => featureInformationPanelHolder; }
    }
}