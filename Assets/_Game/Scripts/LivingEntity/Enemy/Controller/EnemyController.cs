using UnityEngine;
using UniRx;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine.Animations.Rigging;
using BehaviorDesigner.Runtime;

namespace Character
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] Enemy enemy;
        [SerializeField] BehaviorTree[] behaviorTrees;

        List<ICollisionEnterExit> collisionEnterExitList = new List<ICollisionEnterExit>();

        protected void Start()
        {
            CollisionCustom collisionCustom = enemy.gameObject.GetOrAddComponent<CollisionCustom>();

            enemy.Animator.GetBehaviours<OnAnimationStateEnterSMB>().Foreach(x => x.SetMessageBroker(enemy.AnimatorMessageBroker));
            enemy.Animator.GetBehaviours<OnAnimationStateExitSMB>().Foreach(x => x.SetMessageBroker(enemy.AnimatorMessageBroker));

            collisionEnterExitList = new List<ICollisionEnterExit>()
            {
                new CrossFadeAnimWhenHitIGiveDamage(collisionCustom, enemy.Animator), // Its order in the list is improtant therefore IsHitTo bool
                new EnemyHealthController(collisionCustom, enemy.HealthRP),
            };

            collisionEnterExitList.ForEach(x => x.Activate());

            enemy.HealthRP.Where(x => x <= 0).Subscribe(x => OnDeath());
        }

        public void Deactivate()
        {
            collisionEnterExitList.ForEach(x => x.Deactivate());
        }

        void OnDeath()
        {
            Deactivate();
            enemy.Rb.isKinematic = true;
            enemy.Colider.enabled = false;
            enemy.Animator.CrossFade("Death", .15f);
            behaviorTrees.Foreach(x => x.enabled = false);
            // enemy.WeaponHolder.GetComponentInChildren<IWeapon>().Unequip(); // BHT is called. Therefore you can not call twice
            enemy.GetComponent<RigBuilder>().enabled = false;
        }


#if UNITY_EDITOR
        [Button] void SetHealth(int value = 0) => enemy.HealthRP.Value = value;
#endif
    }
}