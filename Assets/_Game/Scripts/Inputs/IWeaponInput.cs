public interface IWeaponInput
{
    bool HasPressedReloadKey { get; }
    bool HasPressedFireKey { get; }
    bool HasHoldingFireKey { get; }
}