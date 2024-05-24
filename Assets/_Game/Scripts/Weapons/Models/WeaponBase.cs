using UnityEngine;
using Sirenix.OdinInspector;
using UniRx;

public abstract class WeaponBase : MonoBehaviour, IWeaponForModel
{
    [SerializeField] WeaponAnimationData weaponAnimationData;

    [ReadOnly, ShowInInspector] public ReactiveProperty<IAmmoData> _AmmoDataRP { get; set; }

    public Transform Transform => transform;
    public IAnimator _Animator { get; set; }

    public int DrawWeaponInputInt => WeaponAnimationData.drawWeaponInputInt;
    public WeaponAnimationData WeaponAnimationData { get => weaponAnimationData; }
}