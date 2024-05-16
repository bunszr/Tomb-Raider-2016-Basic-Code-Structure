using UnityEngine;
using UniRx;
using System;
using System.Linq;

public class WeaponToggle : MonoBehaviour, IWeaponToggler
{
    public class WeaponDrawData
    {
        public Transform weaponParent;
        public IWeaponForModel _weaponForModel;
        public IWeapon _weapon;

        public WeaponDrawData(Transform weaponParent, IWeaponForModel weaponForModel, IWeapon weapon)
        {
            this.weaponParent = weaponParent;
            _weaponForModel = weaponForModel;
            _weapon = weapon;
        }
    }

    IDisposable disposable;
    AnimationEventMono animationEventMono;

    WeaponDrawData oldWeaponDrawData;
    WeaponDrawData requestedWeaponDrawData;
    WeaponDrawData[] weaponDrawDatas;

    [SerializeField] LivingEntity livingEntity;
    [SerializeField] Transform weaponHolder;

    public ReactiveProperty<IWeapon> _CurrWeaponRP { get; private set; }

    private void Awake()
    {
        _CurrWeaponRP = new ReactiveProperty<IWeapon>();

        animationEventMono = livingEntity.gameObject.GetOrAddComponent<AnimationEventMono>();
        animationEventMono.onAnimationEvent += OnDrawAnim;
    }

    private void Start()
    {
        disposable = this.ObserveEveryValueChanged(x => x.transform.childCount).Subscribe(OnNewWeaponAdded);
    }

    void OnNewWeaponAdded(int count)
    {
        weaponDrawDatas = Enumerable.Range(0, weaponHolder.transform.childCount).Select(i => new WeaponDrawData(weaponHolder.transform.GetChild(i), weaponHolder.transform.GetChild(i).GetComponentInChildren<IWeaponForModel>(), weaponHolder.transform.GetChild(i).GetComponentInChildren<IWeapon>())).ToArray();
    }

    private void OnDestroy()
    {
        animationEventMono.onAnimationEvent -= OnDrawAnim;
        disposable.Dispose();
    }

    WeaponDrawData GetGunDataFromInputIndex(int gunIndex)
    {
        for (int i = 0; i < weaponDrawDatas.Length; i++)
        {
            if (weaponDrawDatas[i]._weaponForModel.DrawWeaponInputInt == gunIndex) return weaponDrawDatas[i];
        }
        return null;
    }

    private void Update()
    {
        int pressedGunIndex = -1;

        if (IM.Ins.Input.WeaponToggleInput.HasEquipGun1) pressedGunIndex = 0;
        else if (IM.Ins.Input.WeaponToggleInput.HasEquipGun2) pressedGunIndex = 1;
        else if (IM.Ins.Input.WeaponToggleInput.HasEquipGun3) pressedGunIndex = 2;
        else if (IM.Ins.Input.WeaponToggleInput.HasEquipGun4) pressedGunIndex = 3;

        if (pressedGunIndex != -1 && GetGunDataFromInputIndex(pressedGunIndex) != null && GetGunDataFromInputIndex(pressedGunIndex) != requestedWeaponDrawData)
        {
            requestedWeaponDrawData = GetGunDataFromInputIndex(pressedGunIndex);
            livingEntity.Animator.SetInteger(APs.DrawWeaponInt, requestedWeaponDrawData._weaponForModel.DrawWeaponInputInt);
            livingEntity.Animator.SetTrigger(APs.DrawWeaponTrigger);
        }
    }

    public void CheckMistake()
    {
        int checkCount = 0;
        for (int i = 0; i < weaponHolder.childCount; i++) if (weaponHolder.GetChild(i).gameObject.activeSelf) checkCount++;
        if (checkCount > 1) Debug.LogError("There is multiple equipped weapon more than one");
    }

    public void OnDrawAnim(string name)
    {
        if (name != "DrawWeapon") return;

        CheckMistake();

        if (oldWeaponDrawData != null)
        {
            oldWeaponDrawData._weapon.Unequip();
            oldWeaponDrawData._weapon.Transform.parent.gameObject.SetActive(false);
        }

        oldWeaponDrawData = requestedWeaponDrawData;

        requestedWeaponDrawData.weaponParent.gameObject.SetActive(true);
        requestedWeaponDrawData._weapon.Equip();
        _CurrWeaponRP.Value = requestedWeaponDrawData._weapon;
    }
}