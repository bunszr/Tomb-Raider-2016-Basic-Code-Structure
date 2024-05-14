using Sirenix.OdinInspector;
using UnityEngine;

public class WeaponDataScriptable : ScriptableObject, INormalAmmo
{
    [SerializeField] string weaponName;

    [SerializeField] protected WeaponDataSaveable weaponDataSaveable;
    [SerializeField] protected NormalAmmoSaveable normalAmmoSaveable;
    public WeaponAnimationData weaponAnimationData;

    [ReadOnly, ShowInInspector] public WeaponData WeaponData { get; set; }
    [ReadOnly, ShowInInspector] public NormalAmmo NormalAmmo { get; set; }

    public string WeaponName { get => weaponName; }

    [Button]
    public virtual void LoadFromItSelf()
    {
        WeaponData = new WeaponData(weaponDataSaveable);
        NormalAmmo = new NormalAmmo(normalAmmoSaveable);
    }

    public WeaponDataScriptable CreateInstance()
    {
        WeaponDataScriptable instance = ScriptableObject.CreateInstance<WeaponDataScriptable>();
        instance.WeaponData = new WeaponData(weaponDataSaveable);
        instance.NormalAmmo = new NormalAmmo(normalAmmoSaveable);
        instance.weaponAnimationData = weaponAnimationData;
        instance.weaponName += "Enemy";
        return instance;
    }
}
[System.Serializable]
public class WeaponAnimationData
{
    public string fireAnimName;
    public string reloadMagazineName;
    public string reloadMagazineTriggerName;
}