using UnityEngine;

public abstract class WeaponDataScriptable : ScriptableObject
{
    [SerializeField] string weaponName;

    public WeaponData weaponData;

    public string WeaponName { get => weaponName; }
}
