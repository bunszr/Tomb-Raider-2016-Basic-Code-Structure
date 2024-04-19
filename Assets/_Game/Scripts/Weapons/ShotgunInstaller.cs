using UniRx;
using UnityEngine;
using Zenject;

public class ShotgunInstaller : MonoBehaviour
{
    private void Awake()
    {
        Shotgun shotgun = transform.parent.GetComponentInChildren<Shotgun>();

        shotgun._bulletBehaviour = new ScatterBulletBehaviour(shotgun, shotgun.scatterBulletBehaviourData);
        shotgun._fireMode = new SingleShot(shotgun, shotgun.singleShotData);

        shotgun.Equip();
    }
}