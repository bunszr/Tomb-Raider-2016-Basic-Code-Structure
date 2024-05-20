using Sirenix.OdinInspector;
using UniRx;
using UnityEngine;
using WeaponNamescape.Enemy;
using Zenject;

public class Player : LivingEntity, IEnemyTarget
{
    [SerializeField] PlayerDataScriptable playerDataScriptable;
    [SerializeField] FastHealingFeatureScriptable fastHealingFeatureScriptable;
    [SerializeField] ArmorFeatureScriptable armorFeatureScriptable;

    public Transform EnemyTargetTransform => transform;
    public Vector3 BulletTargetLocation => transform.position + Vector3.up * 1.3f;

    public FastHealingFeatureScriptable FastHealingFeatureScriptable { get => fastHealingFeatureScriptable; }
    public ArmorFeatureScriptable ArmorFeatureScriptable { get => armorFeatureScriptable; }

    public PlayerDataScriptable PlayerDataScriptable { get => playerDataScriptable; }
}