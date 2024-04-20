using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu(fileName = "AK47WeaponDataScriptable", menuName = "Third-Person-Shooter/Weapon Type/AK47WeaponDataScriptable", order = 0)]
public class AK47WeaponDataScriptable : WeaponDataScriptable, INormalAmmo
{
    [ReadOnly, ShowInInspector] public NormalAmmo normalAmmo;
    public FireAmmo fireAmmo;

    public NormalAmmo NormalAmmo => normalAmmo;

    [SerializeField] SavedData defaultData;

    [System.Serializable]
    public class SavedData
    {
        public WeaponDataSaveable weaponDataSaveable;
        public NormalAmmoSaveable normalAmmoSaveable;
        public FireAmmoSaveable fireAmmoSaveable;
    }

    [Button]
    public void SaveFromScriptable() => FileHandler.SaveToJSON<SavedData>(defaultData, WeaponName);

    [Button]
    public void Save()
    {
        SavedData savedData = new SavedData();
        savedData.weaponDataSaveable = weaponData;
        savedData.normalAmmoSaveable = normalAmmo;
        savedData.fireAmmoSaveable = fireAmmo;
        FileHandler.SaveToJSON<SavedData>(savedData, WeaponName);
    }

    [Button]
    public void LoadFromItSelf()
    {
        weaponData = new WeaponData(defaultData.weaponDataSaveable);
        normalAmmo = new NormalAmmo(defaultData.normalAmmoSaveable);
        fireAmmo = new FireAmmo(defaultData.fireAmmoSaveable);
    }

    [Button]
    public void LoadFromJSON()
    {
        SavedData savedData = FileHandler.ReadFromJSON<SavedData>(WeaponName);
        weaponData = new WeaponData(savedData.weaponDataSaveable);
        normalAmmo = new NormalAmmo(savedData.normalAmmoSaveable);
        fireAmmo = new FireAmmo(savedData.fireAmmoSaveable);
    }
}

public interface INormalAmmo
{
    NormalAmmo NormalAmmo { get; }
}

// public class WeaponDataGeneric<T> where T : ISaveableWeapon, new()
// {
//     string name;
//     public T data;

//     public void Save()
//     {
//         FileHandler.SaveToJSON<T>(data, name);
//     }

//     public void Load()
//     {
//         data = FileHandler.ReadFromJSON<T>(name);
//     }
// }