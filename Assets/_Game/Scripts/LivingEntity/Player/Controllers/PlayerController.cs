using UnityEngine;
using UniRx;
using System.Collections.Generic;

namespace Character
{
    public class PlayerController : MonoBehaviour
    {
        CompositeDisposable disposables = new CompositeDisposable();

        [SerializeField] Player player;

        List<ICollisionEnterExit> collisionEnterExitList = new List<ICollisionEnterExit>();

        protected void Start()
        {
            player.FastHealingFeatureScriptable.IsOpenRP.Subscribe(OnFastHealing).AddTo(disposables);

            player.Animator.GetBehaviours<OnAnimationStateEnterSMB>().Foreach(x => x.SetMessageBroker(player.AnimatorMessageBroker));
            player.Animator.GetBehaviours<OnAnimationStateExitSMB>().Foreach(x => x.SetMessageBroker(player.AnimatorMessageBroker));

            CollisionCustom collisionCustom = player.gameObject.GetOrAddComponent<CollisionCustom>();

            collisionEnterExitList = new List<ICollisionEnterExit>()
            {
                new CrossFadeAnimWhenHitIGiveDamage(collisionCustom, player.Animator), // Its order in the list is improtant therefore IsHitTo bool
                new HealthAndArmorController(collisionCustom, player.PlayerDataScriptable.HealthRP, player.PlayerDataScriptable.ArmorRP, player.ArmorFeatureScriptable),
            };

            collisionEnterExitList.ForEach(x => x.Activate());
        }

        public void OnFastHealing(bool isOpen)
        {
        }

        public void Deactivate()
        {
            disposables.Clear();
            collisionEnterExitList.ForEach(x => x.Deactivate());
        }

        private void OnDestroy()
        {
        }
    }
}