using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu(fileName = "GameDataScriptable", menuName = "Third-Person-Shooter/GameDataScriptable", order = 0)]
public class GameDataScriptable : SingletonScriptableObject<GameDataScriptable>
{
    public bool loadFeatureFromJSONinEditor = false;
    public bool loadInventoryFromJSONinEditor = false;
    public bool loadWeaponDataFromJSONinEditor = false;

    public CampSiteScriptableData campSiteScriptableData;
    public WeaponScriptableData weaponScriptableData;

    [System.Serializable]
    public class CampSiteScriptableData
    {
        public ShowInformationScriptableData showInformationScriptableData;
        public ShowCostAndInventoryScriptableData showCostAndInventoryScriptableData;
        public WeaponDataSliderScriptableData weaponDataSliderScriptableData;
        public ShowUpgradedFeatureStateScriptableData showUpgradedFeatureStateScriptableData;
        public CampsitePanelScriptableData campsitePanelScriptableData;
        public FirstLevelAnimScriptableData firstLevelAnimScriptableData;

        [System.Serializable]
        public class ShowInformationScriptableData
        {
            public float fadeDuration = .4f;
            public Ease fadeEase = Ease.InOutSine;
            public float yAnimationDuration = .4f;
            public float yAnimationAmount = .3f;
            public Ease yAnimEase = Ease.InOutSine;
        }

        [System.Serializable]
        public class ShowCostAndInventoryScriptableData
        {
            public float fadeDuration = .2f;
            public Ease fadeEase = Ease.InOutSine;
            public float posAnimationDuration = 1f;
            public float posAnimationAmount = .3f;
            public Ease posAnimEase = Ease.OutBack;
        }

        [System.Serializable]
        public class WeaponDataSliderScriptableData
        {
            public float fadeDuration = .4f;
            public Ease fadeEase = Ease.InOutSine;
            public float yAnimationDuration = .4f;
            public float yAnimationAmount = .3f;
            public Ease yAnimEase = Ease.InOutSine;
        }

        [System.Serializable]
        public class ShowUpgradedFeatureStateScriptableData
        {
            public float fadeInDuration = .4f;
            public float fadeOutDuration = .4f;
            public Ease fadeEase = Ease.InOutSine;
            public float stateDuration = 3f;
            public float yAnimationDuration = .4f;
            public float yAnimationAmount = .3f;
            public Ease yAnimEase = Ease.OutElastic;
        }

        [System.Serializable]
        public class CampsitePanelScriptableData
        {
            public float fadeInDuration = .4f;
            public float fadeOutDuration = .4f;
            public Ease fadeEase = Ease.InOutSine;
        }

        [System.Serializable]
        public class FirstLevelAnimScriptableData
        {
            public float zOffset = -1;
            public float duration = .5f;
            public Ease ease = Ease.InOutSine;
        }
    }

    [System.Serializable]
    public class WeaponScriptableData
    {
        public MaxWeaponDataSaveable maxWeaponDataSaveable;
        public AimData aimData;

        [System.Serializable]
        public class MaxWeaponDataSaveable
        {
            public int damage;
            public int recoilStability;
            public int reloadSpeed;
            public int ammoCapacity;
            public int rateOfFire;
        }

        [System.Serializable]
        public class AimData
        {
            public float rayMaxDistance = 9;
            public float depth = 9;
            public float rigWeightDuration = .2f;
            public float mouseSensitive = 350;
            public LayerMask layerMask;
        }
    }
}