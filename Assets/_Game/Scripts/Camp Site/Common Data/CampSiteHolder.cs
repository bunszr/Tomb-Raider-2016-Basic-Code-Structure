using System.Collections.Generic;
using Sirenix.OdinInspector;
using TMPro;
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
        [SerializeField] CSUpgradedPanel upgradedPanel;
        [SerializeField] CampsiteCommandExecuter campsiteCommandExecuter;

        [SerializeField] CSSkillInfoPanel cSSkillInfoPanel;
        [SerializeField] TextMeshProUGUI skillPointCostText;

        public Transform WeaponShowLocation { get => weaponShowLocation; }
        public Transform WeaponFeatureIndicator { get => weaponFeatureIndicator; }
        public Transform CharaterStandLocation { get => charaterStandLocation; }
        public WeaponDataSliderHolder WeaponDataSliderHolder { get => weaponDataSliderHolder; }
        public WeaponBase weaponBase { get => WeaponShowLocation.GetComponentInChildren<WeaponBase>(); }
        public FeatureInformationPanelHolder FeatureInformationPanelHolder { get => featureInformationPanelHolder; }
        public CostAndInventoryPanel CostAndInventoryPanel { get => costAndInventoryPanel; }
        public CSUpgradedPanel UpgradedPanel { get => upgradedPanel; }
        public CampsiteCommandExecuter CampsiteCommandExecuter { get => campsiteCommandExecuter; }

        public TextMeshProUGUI SkillPointCostText { get => skillPointCostText; }
        public CSSkillInfoPanel skillInfoPanel { get => cSSkillInfoPanel; }
    }
}