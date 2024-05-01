using UnityEngine;
using Sirenix.OdinInspector;
using UniRx;

public abstract class WeaponBase : MonoBehaviour
{
    public WeaponDataScriptable weaponDataScriptable;
    [ReadOnly, ShowInInspector] public ReactiveProperty<IAmmoData> _AmmoRP { get; set; }
}