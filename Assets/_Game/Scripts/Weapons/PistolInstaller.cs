using System.Collections.Generic;
using UnityEngine;

public class PistolInstaller : PlayerWeaponBaseInstaller
{
    [SerializeField] LivingEntity livingEntity;
    [SerializeField] Pistol pistol;
    [SerializeField] Animator animator;

    protected override void Awake()
    {
        base.Awake();

        _extraFireList = new List<IExtraFire>()
        {
            new FireAnimationBehaviour(animator),
            new NormalBulletBehaviour(pistol, pistol.normalBulletModeData),
            new NormalShellCasingBehaviour(pistol, pistol.normalShellCasingData)
        };

        _equipableList = new List<IEquiptable>()
        {
            new SingleFireBehavior(weaponBase, _extraFireList, _input.WeaponInput),
            new NormalAimBehavior(weaponBase, _input.WeaponInput, livingEntity, pistol.normalAimBehaviorData, pistol.weaponAimData),
        };
    }
}