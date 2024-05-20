using Zenject;

public class CameraBrainInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<Cinemachine.CinemachineBrain>().FromComponentInHierarchy().AsTransient();
    }
}