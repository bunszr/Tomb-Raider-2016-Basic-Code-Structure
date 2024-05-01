using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace CampSite
{
    public class CampSiteHolder : MonoBehaviour
    {
        [SerializeField] Transform weaponShowLocation;
        [SerializeField] Transform weaponFeatureIndicator;
        [SerializeField] Transform charaterStandLocation;
        [SerializeField] WeaponDataSliderHolder weaponDataSliderHolder;
        [SerializeField] FeatureInformationPanelHolder featureInformationPanelHolder;
        [SerializeField] CostAndInventoryPanel costAndInventoryPanel;
        [SerializeField] UpgradedPanel upgradedPanel;

        public Transform WeaponShowLocation { get => weaponShowLocation; }
        public Transform WeaponFeatureIndicator { get => weaponFeatureIndicator; }
        public Transform CharaterStandLocation { get => charaterStandLocation; }
        public WeaponDataSliderHolder WeaponDataSliderHolder { get => weaponDataSliderHolder; }
        public WeaponBase weaponBase { get => WeaponShowLocation.GetComponentInChildren<WeaponBase>(); }
        public FeatureInformationPanelHolder FeatureInformationPanelHolder { get => featureInformationPanelHolder; }
        public CostAndInventoryPanel CostAndInventoryPanel { get => costAndInventoryPanel; }
        public UpgradedPanel UpgradedPanel { get => upgradedPanel; }
    }
}