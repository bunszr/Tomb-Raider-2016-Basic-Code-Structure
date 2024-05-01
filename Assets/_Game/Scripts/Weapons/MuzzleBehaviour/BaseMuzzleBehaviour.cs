public abstract class BaseMuzzleBehaviour : IMuzzleBehaviour, IExtraFire
{
    protected WeaponBase weaponBase;
    protected BaseMuzzleBehaviour(WeaponBase weapon) => weaponBase = weapon;
    public virtual void Fire() { }
}