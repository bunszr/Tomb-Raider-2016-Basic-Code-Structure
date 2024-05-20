using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu(fileName = "AK47WeaponDataScriptable", menuName = "Third-Person-Shooter/Weapon Type/AK47WeaponDataScriptable", order = 0)]
public class AK47WeaponDataScriptable : WeaponDataScriptable, IFireAmmo
{
    public FireAmmoSaveable fireAmmoSaveable;

    [ReadOnly, ShowInInspector] public FireAmmo FireAmmo { get; set; }

    [Button]
    public override void LoadFromItSelf()
    {
        base.LoadFromItSelf();
        FireAmmo = new FireAmmo(fireAmmoSaveable);
    }
}