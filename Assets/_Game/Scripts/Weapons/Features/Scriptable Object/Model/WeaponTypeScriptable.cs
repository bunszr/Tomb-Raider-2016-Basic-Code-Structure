using UnityEngine;

public abstract class WeaponTypeScriptable : ScriptableObject
{
    [SerializeField] string weaponName;

    public string WeaponName { get => weaponName; }
}
