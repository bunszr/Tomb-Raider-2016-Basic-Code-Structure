using BehaviorDesigner.Runtime;
using Cinemachine;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class EnemyAimBehavior : AimBehaviourBase, IEquiptable
{
    [System.Serializable]
    public class EnemyAimBehaviorData
    {
        public Rig[] rigs;
        public Transform aimTargetTransform;
        public Transform strafeDirectionTransform;
    }


    float weights;
    float Weights
    {
        get => weights;
        set
        {
            for (int i = 0; i < data.rigs.Length; i++) data.rigs[i].weight = value;
            weights = Mathf.Clamp01(value);
        }
    }

    LivingEntity livingEntity;
    EnemyAimBehaviorData data;

    GameDataScriptable.WeaponScriptableData.AimData ScriptableData => GameDataScriptable.Ins.weaponScriptableData.aimData;

    public EnemyAimBehavior(WeaponBase weaponBase, LivingEntity livingEntity, EnemyAimBehaviorData data) : base(weaponBase)
    {
        this.livingEntity = livingEntity;
        this.data = data;
    }

    public override void Enter()
    {
        base.Enter();
        livingEntity.Animator.SetBool(APs.Aim, true);
        // livingEntity.ThirdPersonController.ToggleStrafe(true);
    }

    public override void Exit()
    {
        base.Exit();
        livingEntity.Animator.SetBool(APs.Aim, false);
        // livingEntity.ThirdPersonController.ToggleStrafe(false);
        Weights = 0;
    }

    public override void OnUpdate()
    {
        Weights += Time.deltaTime / ScriptableData.rigWeightDuration;
    }
}