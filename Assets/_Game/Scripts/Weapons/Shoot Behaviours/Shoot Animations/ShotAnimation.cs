using UnityEngine;

public class ShotAnimation : IShotAnim
{
    IWeaponInput _weaponInput;
    Animator animator;

    public ShotAnimation(IWeaponInput weaponInput, Animator animator)
    {
        this._weaponInput = weaponInput;
        this.animator = animator;
    }

    public void Fire()
    {
        if (_weaponInput.HasHoldingAimKey)
        {
            animator.SetTrigger(APs.Shot);
        }
    }
}