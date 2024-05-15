using UnityEngine;

namespace Character
{
    public class LivingEntityCollisionBase : ICollisionEnterExit
    {
        protected CollisionCustom collisionCustom;

        public LivingEntityCollisionBase(CollisionCustom collisionCustom)
        {
            this.collisionCustom = collisionCustom;
        }

        public virtual void Activate()
        {
            collisionCustom.onCollisionEnterEvent += OnCustomCollisionEnter;
            collisionCustom.onCollisionExitEvent += OnCustomCollisionExit;
        }

        public virtual void Deactivate()
        {
            collisionCustom.onCollisionEnterEvent -= OnCustomCollisionEnter;
            collisionCustom.onCollisionExitEvent -= OnCustomCollisionExit;
        }

        public virtual void OnCustomCollisionEnter(Collision other) { }
        public virtual void OnCustomCollisionExit(Collision other) { }
    }
}