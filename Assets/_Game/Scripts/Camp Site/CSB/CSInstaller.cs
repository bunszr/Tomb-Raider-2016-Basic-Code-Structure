using System.ComponentModel;
using UnityEngine;
using Zenject;

namespace CampSite
{
    public class CSInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<Cinemachine.CinemachineBrain>().FromComponentInHierarchy().AsTransient();

        }
    }
}