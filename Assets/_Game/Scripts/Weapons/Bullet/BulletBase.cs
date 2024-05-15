using CharacterPlayer;
using Lean.Pool;
using UniRx;
using UnityEngine;

public class BulletBase : MonoBehaviour, IBullet, IGiveDamage, IPoolable
{
    [SerializeField] float damage = 2;
    [SerializeField] Rigidbody rb;

    public Transform Transform => transform;
    public Rigidbody Rb => rb;

    public float DamageValue => damage;

    public ReactiveProperty<bool> IsHitTo { get; private set; } = new ReactiveProperty<bool>();

    private void Awake()
    {
        StaticColliderManager.IGiveDamageDictionary.Add(transform.GetInstanceID(), this);
    }

    private void OnDestroy()
    {
        StaticColliderManager.IGiveDamageDictionary.Remove(transform.GetInstanceID());
    }

    public void OnSpawn() { }

    public void OnDespawn()
    {
        Rb.velocity = Vector3.zero;
        Rb.angularVelocity = Vector3.zero;
        IsHitTo.Value = false;
    }
}