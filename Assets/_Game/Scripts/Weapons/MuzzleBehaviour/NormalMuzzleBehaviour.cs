using DG.Tweening;
using UnityEngine;

public class NormalMuzzleBehaviour : IMuzzleBehaviour
{
    [System.Serializable]
    public class NormalMuzzleBehaviourData
    {
        public SpriteRenderer muzzleSpriteRenderer;
        public float lifeTimeDuration = .1f;
    }

    Tween tween;
    NormalMuzzleBehaviourData data;

    public NormalMuzzleBehaviour(NormalMuzzleBehaviourData data) => this.data = data;

    public void Fire()
    {
        data.muzzleSpriteRenderer.gameObject.SetActive(true);

        tween.KillMine();
        tween = DOVirtual.DelayedCall(data.lifeTimeDuration, () => data.muzzleSpriteRenderer.gameObject.SetActive(false));
    }
}