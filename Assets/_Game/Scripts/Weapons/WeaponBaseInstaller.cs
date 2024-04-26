using UniRx;
using UnityEngine;
using Zenject;

public abstract class WeaponBaseInstaller : MonoBehaviour
{
    protected LivingEntity livingEntity;
    protected WeaponBase weaponBase;
    protected WeaponAimData weaponAimData;
    [Inject] protected IInput _input;

    protected virtual void Awake()
    {
        weaponBase = transform.parent.GetComponentInChildren<WeaponBase>();
        weaponBase._AmmoRP = new ReactiveProperty<IAmmoData>(weaponBase.weaponDataScriptable.NormalAmmo);
        livingEntity = GetComponentInParent<LivingEntity>();
        weaponAimData = GetComponentInParent<WeaponAimData>();

        weaponBase._aimBehaviour = new NormalAimBehavior(weaponBase, _input.WeaponInput, livingEntity, weaponBase.normalAimBehaviorData, weaponAimData);
        weaponBase._shotAnim = new ShotAnimation(_input.WeaponInput, livingEntity.Animator);
    }

    protected virtual void Start()
    {
    }
}