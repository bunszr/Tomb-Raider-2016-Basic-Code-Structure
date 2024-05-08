using UnityEngine;
using Sirenix.OdinInspector;
using UniRx;

public abstract class WeaponBase : MonoBehaviour
{
    [SerializeField] WeaponDataScriptable weaponDataScriptable;
    IThirdPersonController thirdPersonController;
    [ReadOnly, ShowInInspector] public ReactiveProperty<IAmmoData> _AmmoRP { get; set; }

    public WeaponDataScriptable WeaponDataScriptable { get => weaponDataScriptable; set => weaponDataScriptable = value; }
    public IThirdPersonController _ThirdPersonController { get => thirdPersonController; set => thirdPersonController = value; }
}