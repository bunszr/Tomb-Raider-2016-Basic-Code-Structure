using UnityEngine;
using Sirenix.OdinInspector;
using UniRx;

public abstract class WeaponBase : MonoBehaviour, IWeaponForModel
{
    [SerializeField] WeaponDataScriptable weaponDataScriptable;
    [ReadOnly, ShowInInspector] public ReactiveProperty<IAmmoData> _AmmoRP { get; set; }

    public WeaponDataScriptable WeaponDataScriptable { get => weaponDataScriptable; set => weaponDataScriptable = value; }
    public IAnimator _Animator { get; set; }

    public int DrawWeaponInputInt => weaponDataScriptable.weaponAnimationData.drawWeaponInputInt;
    public Transform Transform => transform;
}