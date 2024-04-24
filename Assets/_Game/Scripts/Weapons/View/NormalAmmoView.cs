using System.Collections;
using Sirenix.OdinInspector;
using TMPro;
using UniRx;
using UnityEngine;

public class NormalAmmoView : MonoBehaviour
{
    public WeaponBase weaponBase;
    public TextMeshProUGUI currAmmoTMPro;
    public TextMeshProUGUI totalAmmoTMPro;

    [ReadOnly, ShowInInspector] INormalAmmo _normalAmmo;
    CompositeDisposable disposables;

    private void Awake()
    {
        weaponBase.onEquip += OnEquip;
        weaponBase.onUnEquip += OnUnEquip;
        disposables = new CompositeDisposable();
    }

    public void OnEquip(IWeapon _weapon)
    {
        _normalAmmo = weaponBase.weaponDataScriptable as INormalAmmo;

        _normalAmmo.NormalAmmo.BulletCountInMagazineRP.Subscribe(OnBulletCountInMagazine).AddTo(disposables);
        _normalAmmo.NormalAmmo.CurrAmmoCapacityRP.Subscribe(OnCurrAmmoChanged).AddTo(disposables);
    }

    public void OnUnEquip(IWeapon _weapon)
    {
        disposables.Clear();
    }

    private void OnDestroy() => disposables?.Dispose();

    void OnBulletCountInMagazine(int ammo)
    {
        currAmmoTMPro.text = ammo.ToString();
    }

    void OnCurrAmmoChanged(int ammo)
    {
        totalAmmoTMPro.text = ammo + "|";
    }
}