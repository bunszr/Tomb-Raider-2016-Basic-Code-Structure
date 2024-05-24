using Sirenix.OdinInspector;
using TMPro;
using UniRx;
using UnityEngine;

public class NormalAmmoView : MonoBehaviour
{
    [SerializeField] WeaponDataScriptable weaponDataScriptable;
    [SerializeField] PlayerWeaponBaseInstaller playerWeaponBaseInstaller;
    [SerializeField] GameObject panelParent;
    [SerializeField] TextMeshProUGUI currAmmoTMPro;
    [SerializeField] TextMeshProUGUI totalAmmoTMPro;

    [ReadOnly, ShowInInspector] INormalAmmo _normalAmmo;
    CompositeDisposable viewDisposables;
    System.IDisposable disposable;

    private void Awake()
    {
        viewDisposables = new CompositeDisposable();
        _normalAmmo = weaponDataScriptable as INormalAmmo;
        disposable = playerWeaponBaseInstaller.GetComponent<IWeapon>().HasEquipRP.Subscribe(OnChangeEquipStatus);
    }

    void OnChangeEquipStatus(bool active)
    {
        if (active) OnEquip();
        else OnUnEquip();
    }

    public void OnEquip()
    {
        panelParent.SetActive(true);

        _normalAmmo.NormalAmmo.BulletCountInMagazineRP.Subscribe(OnBulletCountInMagazine).AddTo(viewDisposables);
        _normalAmmo.NormalAmmo.CurrAmmoCapacityRP.Subscribe(OnCurrAmmoChanged).AddTo(viewDisposables);
    }

    public void OnUnEquip()
    {
        panelParent.SetActive(false);
        viewDisposables.Clear();
    }

    private void OnDestroy() => disposable.Dispose();

    void OnBulletCountInMagazine(int ammo)
    {
        currAmmoTMPro.text = ammo.ToString();
    }

    void OnCurrAmmoChanged(int ammo)
    {
        totalAmmoTMPro.text = ammo + "|";
    }
}