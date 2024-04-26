using UnityEngine;
using UniRx;
using System;
using Zenject;
using System.Collections;

public class WeaponToggle : MonoBehaviour, IWeaponToggler
{
    IDisposable disposable;
    LivingEntity livingEntity;
    public Transform weaponHolder;

    ReactiveProperty<IWeapon> _OldWeaponRP = new ReactiveProperty<IWeapon>();
    public ReactiveProperty<IWeapon> _CurrWeaponRP { get; private set; }

    [Inject] IInput _input;

    int weaponIndex = -1;
    // int oldSlot = -1;

    IEquipBehaviour _handEquipBehaviourRP;
    IEquipBehaviour _weaponEquipBehaviourRP;

    public IWeapon[] GetWeapons() => GetComponentsInChildren<IWeapon>(true);

    private void Awake()
    {
        _CurrWeaponRP = new ReactiveProperty<IWeapon>();

        livingEntity = GetComponentInParent<LivingEntity>();
        AnimationEventMono animationEventMono = livingEntity.gameObject.AddComponent<AnimationEventMono>();
        animationEventMono.onAnimationEvent += OnDrawAnim;

        _handEquipBehaviourRP = new HandEquipBehaviour(weaponHolder, animationEventMono, _input.WeaponToggleInput);
        _weaponEquipBehaviourRP = new WeaponEquipBehaviour(weaponHolder, animationEventMono);
    }

    private void OnEnable()
    {
        _handEquipBehaviourRP.Enter();
        _weaponEquipBehaviourRP.Enter();
    }

    private void OnDisable()
    {
        _handEquipBehaviourRP.Exit();
        _weaponEquipBehaviourRP.Exit();
    }

    private void Update()
    {
        int pressedGunIndex = -1;

        if (_input.WeaponToggleInput.HasEquipGun1) pressedGunIndex = 0;
        else if (_input.WeaponToggleInput.HasEquipGun2) pressedGunIndex = 1;
        else if (_input.WeaponToggleInput.HasEquipGun3) pressedGunIndex = 2;
        else if (_input.WeaponToggleInput.HasEquipGun4) pressedGunIndex = 3;

        if (pressedGunIndex != -1)
        {
            weaponIndex = pressedGunIndex;

            if (!weaponHolder.GetChild(weaponIndex).gameObject.activeSelf)
            {
                livingEntity.Animator.SetInteger(APs.DrawWeaponInt, weaponIndex);
                livingEntity.Animator.SetTrigger(APs.DrawWeaponTrigger);
            }
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
        CheckMistake();

        for (int i = 0; i < weaponHolder.childCount; i++)
        {
            if (weaponHolder.GetChild(i).gameObject.activeSelf)
            {
                weaponHolder.GetChild(i).GetComponentInChildren<IWeapon>().Unequip();
            }
        }

        _CurrWeaponRP.Value = weaponHolder.GetChild(weaponIndex).GetComponentInChildren<IWeapon>(true);
        _CurrWeaponRP.Value.Equip();
    }

}