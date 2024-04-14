using UnityEngine;
using UniRx;
using Invector.vCharacterController;

public abstract class LivingEntity : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] Collider colider;
    [SerializeField] Animator animator;
    [SerializeField] vThirdPersonController thirdPersonController;
    public ReactiveProperty<int> Health { get; private set; } = new ReactiveProperty<int>(10);

    public Rigidbody Rb { get => rb; }
    public Collider Colider { get => colider; }
    public Animator Animator { get => animator; }
    public vThirdPersonController ThirdPersonController { get => thirdPersonController; }
}