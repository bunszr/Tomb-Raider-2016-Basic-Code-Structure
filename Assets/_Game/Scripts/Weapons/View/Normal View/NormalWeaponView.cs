using Lean.Pool;
using TMPro;
using UnityEngine;
using UniRx;

public class NormalWeaponView : WeaponViewBase, IView
{
    [System.Serializable]
    public class NormalWeaponViewData
    {
        public NormalAmmoCanvasViewData normalAmmoCanvasViewDataPrefab;
    }

    public NormalWeaponViewData data;
    NormalAmmoCanvasViewData normalAmmoCanvasViewData;
    CompositeDisposable disposables;

    public NormalWeaponView(IWeapon _weapon, Transform viewTransform, NormalWeaponViewData data) : base(_weapon)
    {
        this.data = data;
        normalAmmoCanvasViewData = GameObject.Instantiate(data.normalAmmoCanvasViewDataPrefab, viewTransform);
    }

    public void Enter()
    {
        disposables = new CompositeDisposable();
        IAmmoData _ammoData = _weapon.GetAmmoData();
        _ammoData.CurrAmmoRP.Subscribe(OnCurrAmmoChanged).AddTo(disposables);
        _ammoData.TotalAmmoRP.Subscribe(OnTotalAmmoChanged).AddTo(disposables);
    }

    public void Exit()
    {
        disposables.Dispose();
    }

    void OnCurrAmmoChanged(int ammo)
    {
        normalAmmoCanvasViewData.currAmmoTMPro.text = ammo.ToString();
    }

    void OnTotalAmmoChanged(int ammo)
    {
        normalAmmoCanvasViewData.totalAmmoTMPro.text = ammo + "|";
    }
}