namespace Character
{
    public abstract class HealthAndArmorChainBase
    {
        protected HealthAndArmorChainBase next;
        public abstract void Execute(float damageValue);
        public void SetNext(HealthAndArmorChainBase healthChainBase) => next = healthChainBase;
    }
}