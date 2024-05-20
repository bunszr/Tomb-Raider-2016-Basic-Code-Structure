public interface IWeaponInput
{
    bool HasPressedReloadKey { get; }
    bool HasPressedFireKey { get; }
    bool HasPressedAimKey { get; }
    bool HasHoldingAimKey { get; }
    bool HasReleasedAimKey { get; }
    bool HasHoldingFireKey { get; }
    bool HasPressFlashLightKey { get; }
    float HorizontalMouseAxis { get; }
    float VerticalMouseAxis { get; }
}