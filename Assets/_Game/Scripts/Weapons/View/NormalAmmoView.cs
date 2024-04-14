using System.Collections;
using UnityEngine;

public class NormalAmmoView : MonoBehaviour
{
    IView _view;

    public NormalWeaponView.NormalWeaponViewData normalWeaponViewData;

    private void Awake()
    {
        IWeapon _weapon = transform.parent.GetComponentInChildren<IWeapon>();
        _view = new NormalWeaponView(_weapon, transform, normalWeaponViewData);
    }

    private void OnEnable()
    {
        StartCoroutine(EnterIE());
    }

    private void OnDisable()
    {
        _view.Exit();
    }

    IEnumerator EnterIE()
    {
        yield return null;
        _view.Enter();
    }
}