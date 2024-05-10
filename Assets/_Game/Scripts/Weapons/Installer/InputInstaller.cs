using Zenject;

public class InputInstaller : MonoInstaller<InputInstaller>
{
    public override void InstallBindings()
    {
        Container.Bind<IInput>().To<DesktopInput>().AsSingle();
    }
}