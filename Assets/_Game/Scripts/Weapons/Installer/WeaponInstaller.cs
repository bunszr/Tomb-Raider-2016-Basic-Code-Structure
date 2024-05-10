using Zenject;

public class WeaponInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<IWeaponToggler>().FromComponentInHierarchy().AsSingle();
    }
}