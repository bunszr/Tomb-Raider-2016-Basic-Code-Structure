using UnityEngine;
using Zenject;

public class EnemyManagerInstaller : MonoInstaller<EnemyManagerInstaller>
{
    [SerializeField] CoverLocationHolder coverLocationHolder;

    public override void InstallBindings()
    {
        Container.BindInstances(coverLocationHolder);
    }
}