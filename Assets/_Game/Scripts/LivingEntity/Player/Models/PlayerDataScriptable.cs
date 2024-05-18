using UnityEngine;
using UniRx;
using Sirenix.OdinInspector;

[CreateAssetMenu(fileName = "PlayerDataScriptable", menuName = "Third-Person-Shooter/PlayerDataScriptable", order = 0)]
public class PlayerDataScriptable : ScriptableObject
{
    [SerializeField] string playerName = "Player";
    [SerializeField] PlayerData playerData;

    public ReactiveProperty<float> HealthRP { get; private set; }
    public ReactiveProperty<float> ArmorRP { get; private set; }
    public ReactiveProperty<int> NumSkillPointRP { get; private set; }

    public float MaxHealth { get => playerData.maxHealth; }
    public float MaxArmor { get => playerData.maxArmor; }

    string FileName => playerName;

    public void Save() => FileHandler.SaveToJSON(playerData, FileName);

    [Button]
    public void LoadFromItSelf()
    {
        HealthRP = new ReactiveProperty<float>(playerData.initialHealth);
        ArmorRP = new ReactiveProperty<float>(playerData.initialArmor);
        NumSkillPointRP = new ReactiveProperty<int>(playerData.initialNumSkillPoint);
    }

    [Button]
    public void LoadFromJson()
    {
        playerData = FileHandler.ReadFromJSON<PlayerData>(FileName);
        HealthRP = new ReactiveProperty<float>(playerData.currHealth);
        ArmorRP = new ReactiveProperty<float>(playerData.currArmor);
        NumSkillPointRP = new ReactiveProperty<int>(playerData.currNumSkillPoint);
    }

    [System.Serializable]
    public class PlayerData
    {
        [Title("Health & Armor")]
        [SerializeField] public float initialHealth = 50;
        [SerializeField] public float currHealth = 50;
        [SerializeField] public float maxHealth = 100;
        [SerializeField] public float initialArmor = 50;
        [SerializeField] public float currArmor = 50;
        [SerializeField] public float maxArmor = 100;

        [Title("Other")]
        [SerializeField] public int characterLevel;
        [SerializeField] public int howManyEnemyKill;
        [SerializeField] public int currNumSkillPoint;
        [SerializeField] public int initialNumSkillPoint;
    }
}