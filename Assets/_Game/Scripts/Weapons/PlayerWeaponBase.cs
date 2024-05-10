using Sirenix.OdinInspector;
using UniRx;
using UnityEngine;

public class PlayerWeaponBase : WeaponBase, IAimIsTaken, IWeaponThatHasFeatureItself
{
    public IWeaponInput _WeaponInput { get; set; }

    [SerializeField] WeaponItSelfFeatureTypeScriptable weaponItSelfFeatureTypeScriptable;
    [ReadOnly, ShowInInspector] public ReactiveProperty<bool> HasAimed { get; private set; } = new ReactiveProperty<bool>();

    [SerializeField, ReadOnly] WeaponAimData weaponAimData;
    [SerializeField, ReadOnly] NormalAimBehavior.NormalAimBehaviorData normalAimBehaviorData;

    public WeaponItSelfFeatureTypeScriptable WeaponItSelfFeatureTypeScriptable { get => weaponItSelfFeatureTypeScriptable; }
    public WeaponAimData WeaponAimData { get => weaponAimData; set => weaponAimData = value; }
    public NormalAimBehavior.NormalAimBehaviorData NormalAimBehaviorData { get => normalAimBehaviorData; set => normalAimBehaviorData = value; }
}