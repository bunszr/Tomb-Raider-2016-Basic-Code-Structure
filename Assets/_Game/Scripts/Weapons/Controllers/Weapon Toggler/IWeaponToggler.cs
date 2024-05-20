using UniRx;

public interface IWeaponToggler
{
    ReactiveProperty<IWeapon> _CurrWeaponRP { get; }
}