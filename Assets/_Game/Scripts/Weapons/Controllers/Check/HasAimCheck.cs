
public class HasAimCheck : ICheck
{
    IAimIsTaken _aimIsTaken;
    public HasAimCheck(IAimIsTaken aimIsTaken) => _aimIsTaken = aimIsTaken;
    public bool Check() => _aimIsTaken.HasAimed.Value;
}