using UnityEngine;
using AdditiveSceneHelper;

[CreateAssetMenu(fileName = "GameEventHolder", menuName = "Third Person Shooter/GameEventHolder", order = 0)]
public class SOHolder : SingletonScriptableObject<SOHolder>
{
    public LevelManager levelManager;

    public CommonData commonData;

    [System.Serializable]
    public class CommonData
    {
        public float hexOffsetUpLocation = .1f;
        public float hexScaleAmount = .1f;
    }
}