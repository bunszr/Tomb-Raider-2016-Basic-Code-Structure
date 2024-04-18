using DG.Tweening;
using UnityEngine;

[CreateAssetMenu(fileName = "GameDataScriptable", menuName = "Third-Person-Shooter/GameDataScriptable", order = 0)]
public class GameDataScriptable : SingletonScriptableObject<GameDataScriptable>
{
    [SerializeField] bool loadFeatureFromJSONinEditor = false;
    [SerializeField] bool loadInventoryFromJSONinEditor = false;

    public bool LoadFeatureFromJSONinEditor { get => loadFeatureFromJSONinEditor; }
    public bool LoadInventoryFromJSONinEditor { get => loadInventoryFromJSONinEditor; }

    public CampSiteScriptableData campSiteScriptableData;

    [System.Serializable]
    public class CampSiteScriptableData
    {
        public ShowInformationScriptableData showInformationScriptableData;
        public ShowCostAndInventoryScriptableData showCostAndInventoryScriptableData;

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
    }
}