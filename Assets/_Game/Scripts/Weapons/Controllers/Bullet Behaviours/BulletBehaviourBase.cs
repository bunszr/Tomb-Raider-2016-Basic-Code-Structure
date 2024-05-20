using UnityEngine;

public class BulletBehaviourBase
{
    static Transform bulletHolder;
    public static Transform BulletHolder
    {
        get
        {
            if (bulletHolder == null) bulletHolder = new GameObject("BulletHolder").transform;
            return bulletHolder;
        }
    }

    protected WeaponBase weaponBase;

    public BulletBehaviourBase(WeaponBase weapon)
    {
        weaponBase = weapon;
    }
}
