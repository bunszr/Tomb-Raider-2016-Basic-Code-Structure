using CampSite;
using UnityEngine;
using Zenject;

public class CampSiteInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<CampSiteHolder>().FromComponentInHierarchy().AsSingle();
    }
}