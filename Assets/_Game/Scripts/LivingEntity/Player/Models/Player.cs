using Sirenix.OdinInspector;
using UniRx;
using UnityEngine;
using WeaponNamescape.Enemy;
using Zenject;

public class Player : LivingEntity, IEnemyTarget
{
    [SerializeField] PlayerDataScriptable playerDataScriptable;
    [SerializeField] float maxArmor = 100;
    [SerializeField] FastHealingFeatureScriptable fastHealingFeatureScriptable;
    [SerializeField] ArmorFeatureScriptable armorFeatureScriptable;

    public ReactiveProperty<float> ArmorRP { get; private set; } = new ReactiveProperty<float>(50);

    public Transform EnemyTargetTransform => transform;
    public Vector3 BulletTargetLocation => transform.position + Vector3.up * 1.3f;

    public FastHealingFeatureScriptable FastHealingFeatureScriptable { get => fastHealingFeatureScriptable; }
    public ArmorFeatureScriptable ArmorFeatureScriptable { get => armorFeatureScriptable; }

    public float MaxArmor { get => maxArmor; }

    private void Awake()
    {
        StaticColliderManager.PlayerDictionary.Add(transform.GetInstanceID(), this);
        StaticColliderManager.AddIEnemyTarget(transform.GetInstanceID(), this);
    }

    private void OnDestroy()
    {
        StaticColliderManager.PlayerDictionary.Remove(transform.GetInstanceID());
        StaticColliderManager.RemoveIEnemyTarget(transform.GetInstanceID(), this);
    }

    public void ToggleStrafe()
    {

    }
}