using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using UnityEngine;

// This class execute from "RuntimeInitializeOnLoadMethodClass" class

public class WeaponSaverAndLoader : MonoBehaviour
{
    [ReadOnly, ShowInInspector] string fileName = "Weapons";
    [ReadOnly, ShowInInspector] WeaponItSelfFeatureTypeScriptable[] weaponItSelfFeatureTypeScriptables;

    void Awake()
    {
        weaponItSelfFeatureTypeScriptables = Resources.LoadAll<WeaponItSelfFeatureTypeScriptable>("");

#if UNITY_EDITOR
        if (!GameDataScriptable.Ins.loadWeaponDataFromJSONinEditor) LoadFromItSelf();
        else LoadFromJSON();
#else
        LoadFromJSON();
#endif
    }

    private void OnDisable() => Save();

    [Button]
    private void Save()
    {
        PersistantDatas pers = new PersistantDatas();
        pers.weaponDataSaveableHolders = weaponItSelfFeatureTypeScriptables
            .Select(x => new WeaponDataSaveableHolder(x.weaponDataScriptable.WeaponName, x.Hash, x.weaponDataScriptable.WeaponData)).ToArray();

        pers.normalAmmoSaveableHolders = weaponItSelfFeatureTypeScriptables
            .Select(x => new NormalAmmoSaveableHolder(x.weaponDataScriptable.WeaponName, x.Hash, x.weaponDataScriptable.NormalAmmo)).ToArray();

        pers.fireAmmoSaveableHolders = weaponItSelfFeatureTypeScriptables
            .Where(x => x.weaponDataScriptable is IFireAmmo)
            .Select(x => new FireAmmoSaveableHolder(x.weaponDataScriptable.WeaponName, x.Hash, (x.weaponDataScriptable as IFireAmmo).FireAmmo)).ToArray();

        FileHandler.SaveToJSON(pers, fileName);
    }

    [Button]
    private void LoadFromItSelf() => weaponItSelfFeatureTypeScriptables.Foreach(x => x.weaponDataScriptable.LoadFromItSelf());

    [Button]
    private void LoadFromJSON()
    {
        PersistantDatas pers = FileHandler.ReadFromJSON<PersistantDatas>(fileName);
        if (pers == null) return;

        Dictionary<int, WeaponDataSaveable> dicWeaponDataSaveable = pers.weaponDataSaveableHolders.ToDictionary(x => x.hash, y => y.weaponDataSaveable);
        Dictionary<int, NormalAmmoSaveable> dicNormalAmmoSaveable = pers.normalAmmoSaveableHolders.ToDictionary(x => x.hash, y => y.normalAmmoSaveable);
        Dictionary<int, FireAmmoSaveable> dicFireAmmoSaveable = pers.fireAmmoSaveableHolders.ToDictionary(x => x.hash, y => y.fireAmmoSaveable);

        foreach (var weaponItSelf in weaponItSelfFeatureTypeScriptables)
        {
            if (dicWeaponDataSaveable.TryGetValue(weaponItSelf.Hash, out WeaponDataSaveable outWeaponDataSaveable))
                weaponItSelf.weaponDataScriptable.WeaponData = new WeaponData(outWeaponDataSaveable);
            if (dicNormalAmmoSaveable.TryGetValue(weaponItSelf.Hash, out NormalAmmoSaveable outNormalAmmoSaveable))
                weaponItSelf.weaponDataScriptable.NormalAmmo = new NormalAmmo(outNormalAmmoSaveable);
            if (dicFireAmmoSaveable.TryGetValue(weaponItSelf.Hash, out FireAmmoSaveable outFireAmmoSaveable))
                (weaponItSelf.weaponDataScriptable as IFireAmmo).FireAmmo = new FireAmmo(outFireAmmoSaveable);
        }
    }

    [System.Serializable]
    public class PersistantDatas
    {
        public WeaponDataSaveableHolder[] weaponDataSaveableHolders;
        public NormalAmmoSaveableHolder[] normalAmmoSaveableHolders;
        public FireAmmoSaveableHolder[] fireAmmoSaveableHolders;
    }

    [System.Serializable]
    public class NameAndHash
    {
        public string name;
        public int hash;

        public NameAndHash(string name, int hash)
        {
            this.name = name;
            this.hash = hash;
        }
    }

    [System.Serializable]
    public class WeaponDataSaveableHolder : NameAndHash
    {
        public WeaponDataSaveable weaponDataSaveable;

        public WeaponDataSaveableHolder(string name, int hash, WeaponDataSaveable weaponDataSaveable) : base(name, hash)
        {
            this.weaponDataSaveable = weaponDataSaveable;
        }
    }

    [System.Serializable]
    public class NormalAmmoSaveableHolder : NameAndHash
    {
        public NormalAmmoSaveable normalAmmoSaveable;

        public NormalAmmoSaveableHolder(string name, int hash, NormalAmmoSaveable normalAmmoSaveable) : base(name, hash)
        {
            this.normalAmmoSaveable = normalAmmoSaveable;
        }
    }

    [System.Serializable]
    public class FireAmmoSaveableHolder : NameAndHash
    {
        public FireAmmoSaveable fireAmmoSaveable;

        public FireAmmoSaveableHolder(string name, int hash, FireAmmoSaveable fireAmmoSaveable) : base(name, hash)
        {
            this.fireAmmoSaveable = fireAmmoSaveable;
        }
    }
}