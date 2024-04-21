using UnityEngine;

public abstract class BaseWeaponInstaller : MonoBehaviour
{
    protected WeaponBase weaponBase;

    protected virtual void Awake()
    {
        weaponBase = transform.parent.GetComponentInChildren<Pistol>();
    }

    protected virtual void Start()
    {
    }
}