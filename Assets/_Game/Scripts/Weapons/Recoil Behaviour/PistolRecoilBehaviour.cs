using DG.Tweening;
using Lean.Pool;
using Sirenix.OdinInspector;
using UnityEngine;

public class PistolRecoilBehaviour : RecoilBehaviourBase
{
    [System.Serializable]
    public class PistolRecoilBehaviourData
    {
        public Vector3 targetRotation;
        public float duration = .2f;
        public Ease ease = Ease.InFlash;
    }

    public PistolRecoilBehaviourData data;

    public PistolRecoilBehaviour(IWeapon _weapon, PistolRecoilBehaviourData data) : base(_weapon)
    {
        this.data = data;
    }

    [Button]
    public override void Execute()
    {
        // Transform.DORotateQuaternion(Quaternion.Euler(data.targetRotation), data.duration).SetEase(data.ease, 2).From(Quaternion.identity);
    }

    public override void OnUpdate()
    {

    }
}