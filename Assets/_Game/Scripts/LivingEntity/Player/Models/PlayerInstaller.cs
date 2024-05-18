using Zenject;

public class PlayerInstaller : MonoInstaller<PlayerInstaller>
{
    public override void InstallBindings()
    {
        Container.Bind<Player>().FromComponentInHierarchy().AsSingle();
    }
}