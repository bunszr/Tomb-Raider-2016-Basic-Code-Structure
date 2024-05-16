using UnityEngine;

public class EnemyEquipBehaviour : IEquiptable
{
    Animator animator;
    int drawWeaponIntAnimParameter;

    public EnemyEquipBehaviour(Animator animator, int drawWeaponIntAnimParameter)
    {
        this.animator = animator;
        this.drawWeaponIntAnimParameter = drawWeaponIntAnimParameter;
    }

    public void Enter()
    {
        animator.SetInteger(APs.DrawWeaponInt, drawWeaponIntAnimParameter);
        animator.SetTrigger(APs.DrawWeaponTrigger);
    }

    public void Exit()
    {
        animator.CrossFade("New State", .1f, animator.GetLayerIndexMine(APLayer.DrawAndAimLayer));
    }
}