using UnityEngine;
using UniRx;
using System.Linq;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using Zenject;

public class WeaponInstantiaterAccordingFeatureOpen : MonoBehaviour
{
    public class Data
    {
        public GameObject prefab;
        public WeaponItSelfFeatureTypeScriptable weaponItSelfFeatureTypeScriptable;

        public Data(GameObject prefab, WeaponItSelfFeatureTypeScriptable weaponItSelfFeatureTypeScriptable)
        {
            this.prefab = prefab;
            this.weaponItSelfFeatureTypeScriptable = weaponItSelfFeatureTypeScriptable;
        }
    }

    CompositeDisposable disposables = new CompositeDisposable();
    IThirdPersonController _thirdPersonController;

    [SerializeField] GameObject[] weaponGOPrefabs;
    [SerializeField] Transform weaponParent;

    List<IWeapon> playerIWeaponBaseList = new List<IWeapon>();

    [SerializeField] GameObject thirdPersonControllerGO;
    [SerializeField] PlayerWeaponBaseInitializer.PlayerWeaponBaseInitializerData playerWeaponBaseInitializerData;

    [SerializeField] bool destroyExistingWeapons = true;

    private void Start()
    {
        if (destroyExistingWeapons) DestroyExistingWeapons();

        _thirdPersonController = thirdPersonControllerGO.GetComponent<IThirdPersonController>();

        Data[] datas = weaponGOPrefabs
            .Where(x => x.GetComponentInChildren<IWeaponThatHasFeatureItself>() != null)
            .Select(x => new Data(x, x.GetComponentInChildren<IWeaponThatHasFeatureItself>().WeaponItSelfFeatureTypeScriptable)).ToArray();

        foreach (var data in datas)
        {
            data.weaponItSelfFeatureTypeScriptable.IsOpenRP.Where(x => x == true).Subscribe(x => OnIsOpenRPIsTrue(data)).AddTo(disposables);
        }
    }

    private void OnDestroy() => disposables.Dispose();

    // Some wepon is opened when we open some chest or etc
    void OnIsOpenRPIsTrue(Data data)
    {
        GameObject weaponGO = Instantiate(data.prefab, weaponParent);
        IWeapon _weapon = weaponGO.GetComponentInChildren<IWeapon>();
        playerIWeaponBaseList.Add(_weapon);
        weaponGO.SetActive(false);

        Create(_weapon);
    }

    public void Create(IWeapon _weapon)
    {
        if (_weapon.Transform.GetComponent<PlayerWeaponBaseInstaller>())
            new PlayerWeaponBaseInitializer(_weapon, _thirdPersonController, playerWeaponBaseInitializerData).Initialize();
    }

    void DestroyExistingWeapons()
    {
        for (int i = 0; i < weaponParent.childCount; i++)
        {
            if (weaponParent.transform.GetChild(i).GetComponentsInChildren<IWeapon>(true) != null)
                Destroy(weaponParent.transform.GetChild(i).gameObject);
        }
    }
}