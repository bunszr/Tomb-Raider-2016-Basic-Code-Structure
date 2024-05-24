using UniRx;

public class HasBulletInTheMagazineCheck : ICheck
{
    ReactiveProperty<IAmmoData> _ammoDataRP;
    public HasBulletInTheMagazineCheck(ReactiveProperty<IAmmoData> ammoDataRP) => _ammoDataRP = ammoDataRP;
    public bool Check() => _ammoDataRP.Value.BulletCountInMagazineRP.Value > 0;
}