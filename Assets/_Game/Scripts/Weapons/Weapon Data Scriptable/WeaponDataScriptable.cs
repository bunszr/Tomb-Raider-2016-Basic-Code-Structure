using Sirenix.OdinInspector;
using UnityEngine;

public abstract class WeaponDataScriptable : ScriptableObject, INormalAmmo
{
    [SerializeField] string weaponName;

    [SerializeField] protected WeaponDataSaveable weaponDataSaveable;
    [SerializeField] protected NormalAmmoSaveable normalAmmoSaveable;

    [ReadOnly, ShowInInspector] public WeaponData WeaponData { get; set; }
    [ReadOnly, ShowInInspector] public NormalAmmo NormalAmmo { get; set; }

    public string WeaponName { get => weaponName; }

    [Button]
    public virtual void LoadFromItSelf()
    {
        WeaponData = new WeaponData(weaponDataSaveable);
        NormalAmmo = new NormalAmmo(normalAmmoSaveable);
    }
}