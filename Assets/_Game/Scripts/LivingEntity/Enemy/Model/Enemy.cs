using UniRx;
using UnityEngine;

public class Enemy : LivingEntity
{
    [SerializeField] float initialHealth = 8;
    public ReactiveProperty<float> HealthRP { get; private set; }

    private void Awake()
    {
        HealthRP = new ReactiveProperty<float>(initialHealth);
    }
}
