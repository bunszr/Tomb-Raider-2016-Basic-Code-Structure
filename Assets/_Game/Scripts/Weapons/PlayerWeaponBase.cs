using Sirenix.OdinInspector;
using UniRx;

public class PlayerWeaponBase : WeaponBase, IAimIsTaken
{
    [ReadOnly, ShowInInspector] public ReactiveProperty<bool> HasAimed { get; set; } = new ReactiveProperty<bool>();
    public WeaponAimData weaponAimData;
    public NormalAimBehavior.NormalAimBehaviorData normalAimBehaviorData;
}