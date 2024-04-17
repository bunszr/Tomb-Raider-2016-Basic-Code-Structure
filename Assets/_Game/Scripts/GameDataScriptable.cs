using DG.Tweening;
using UnityEngine;

[CreateAssetMenu(fileName = "GameDataScriptable", menuName = "Third-Person-Shooter/GameDataScriptable", order = 0)]
public class GameDataScriptable : SingletonScriptableObject<GameDataScriptable>
{
    [SerializeField] bool loadFeatureScriptableDataFromJSONinEditor = false;

    public bool LoadFeatureScriptableDataFromJSONinEditor { get => loadFeatureScriptableDataFromJSONinEditor; }

    public CampSiteScriptableData campSiteScriptableData;

    [System.Serializable]
    public class CampSiteScriptableData
    {
        public ShowInformationScriptableData showInformationScriptableData;

        [System.Serializable]
        public class ShowInformationScriptableData
        {
            public float fadeDuration = .4f;
            public Ease fadeEase = Ease.InOutSine;
            public float yAnimationDuration = .4f;
            public float yAnimationAmount = .3f;
            public Ease yAnimEase = Ease.InOutSine;
        }
    }
}