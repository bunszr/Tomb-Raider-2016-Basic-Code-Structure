public interface IPlayerInput
{
    bool HasPressedJumpInput { get; }
    float HorizontalInput { get; }
    float VerticalInput { get; }
}