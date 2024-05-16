public class Enemy : LivingEntity
{
    private void Awake()
    {
        HealthRP = new UniRx.ReactiveProperty<float>(8);
    }
}
