using UnityEngine;

[CreateAssetMenu(fileName = "GameDataScriptable", menuName = "Third-Person-Shooter/GameDataScriptable", order = 0)]
public class GameDataScriptable : SingletonScriptableObject<GameDataScriptable>
{
    [SerializeField] bool loadFeatureScriptableDataFromJSONinEditor = false;

    public bool LoadFeatureScriptableDataFromJSONinEditor { get => loadFeatureScriptableDataFromJSONinEditor; }
}