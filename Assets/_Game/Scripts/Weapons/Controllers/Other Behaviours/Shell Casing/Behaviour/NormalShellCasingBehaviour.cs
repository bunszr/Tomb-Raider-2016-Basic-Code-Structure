using Lean.Pool;
using UnityEngine;

public class NormalShellCasingBehaviour : IShellCasingBehaviour
{
    [System.Serializable]
    public class NormalShellCasingBehaviourData
    {
        public NormalShellCasing shellCasingPrefab;
        public Transform location;
        public ForceMode forceMode = ForceMode.Impulse;
        public float force = .1f;
    }

    public NormalShellCasingBehaviourData data;

    public NormalShellCasingBehaviour(WeaponBase weaponBase, NormalShellCasingBehaviourData data)
    {
        this.data = data;
    }

    public void Fire()
    {
        IShellCasing _shellCasing = LeanPool.Spawn(data.shellCasingPrefab, data.location.position, data.location.rotation);
        _shellCasing.Rb.AddForce(data.location.forward * data.force, data.forceMode);
        LeanPool.Despawn(_shellCasing.Transform, 6);
    }
}