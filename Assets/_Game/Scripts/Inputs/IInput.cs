public interface IInput
{
    IWeaponToggleInput WeaponToggleInput { get; }
    IWeaponInput WeaponInput { get; }
    IAreaInput AreaInput { get; }
    bool ClosePanelPressKey { get; }
}