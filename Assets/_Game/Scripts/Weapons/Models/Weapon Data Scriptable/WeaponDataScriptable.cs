using Sirenix.OdinInspector;
using UnityEngine;

public class WeaponDataScriptable : ScriptableObject, INormalAmmo
{
    [SerializeField] string weaponName;

    [SerializeField] protected WeaponDataSaveable weaponDataSaveable;
    [SerializeField] protected NormalAmmoSaveable normalAmmoSaveable;

    public string WeaponName { get => weaponName; }

    [ReadOnly, ShowInInspector] public WeaponData WeaponData { get; set; }
    [ReadOnly, ShowInInspector] public NormalAmmo NormalAmmo { get; set; }

    public WeaponDataSaveable WeaponDataSaveable { get => weaponDataSaveable; }
    public NormalAmmoSaveable NormalAmmoSaveable { get => normalAmmoSaveable; }
}