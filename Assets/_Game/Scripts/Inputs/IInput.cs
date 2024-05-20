public interface IInput
{
    IPlayerInput PlayerInput { get; }
    IWeaponToggleInput WeaponToggleInput { get; }
    IWeaponInput WeaponInput { get; }
    IAreaInput AreaInput { get; }
    bool ClosePanelPressKey { get; }
    void ChangePlayerInput(PlayerInputType playerInputType);
}