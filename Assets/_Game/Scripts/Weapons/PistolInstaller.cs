using UniRx;
using UnityEngine;
using Zenject;

public class PistolInstaller : MonoBehaviour
{
    private void Awake()
    {
        Pistol pistol = transform.parent.GetComponentInChildren<Pistol>();

        pistol._bulletBehaviour = new NormalBulletBehaviour(pistol, pistol.normalBulletModeData);
        pistol._fireMode = new SingleShot(pistol, pistol.singleShotData);
        pistol._shellCasingBehaviour = new NormalShellCasingBehaviour(pistol, pistol.normalShellCasingData);
        pistol._recoilBehaviour = new PistolRecoilBehaviour(pistol, pistol.pistolRecoilBehaviourData);

        pistol.normalAmmo = new NormalAmmo();
        pistol._ammoDataRP = new ReactiveProperty<IAmmoData>(pistol.normalAmmo);

        pistol.Equip();
    }
}