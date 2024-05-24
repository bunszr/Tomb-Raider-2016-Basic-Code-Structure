using UnityEngine;
using System.Collections.Generic;
using Sirenix.OdinInspector;

public abstract class WeaponBaseInstaller : MonoBehaviour
{
    [SerializeField] WeaponBase weaponBase;

    [ShowInInspector] protected List<IEquiptable> _EquipableList { get; private set; } = new List<IEquiptable>();
    [ShowInInspector] protected List<IExtraFire> _ExtraFireList { get; private set; } = new List<IExtraFire>();
    [ShowInInspector] protected List<ICheck> _ChecksToFire { get; private set; } = new List<ICheck>();

    public WeaponBase WeaponBase { get => weaponBase; }

    protected void AddEquiptable(IEquiptable _equiptable)
    {
        _EquipableList.Add(_equiptable);
    }

    protected void AddExtraFire(IExtraFire _extraFire)
    {
        _ExtraFireList.Add(_extraFire);
    }

    protected void AddChecksToFire(ICheck _check)
    {
        _ChecksToFire.Add(_check);
    }
}