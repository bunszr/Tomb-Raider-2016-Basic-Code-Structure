using UnityEngine;
using UniRx;
using Invector.vCharacterController;

public abstract class LivingEntity : MonoBehaviour, IThirdPersonController
{
    [SerializeField] float maxHealth = 100;
    [SerializeField] Rigidbody rb;
    [SerializeField] Collider colider;
    [SerializeField] Animator animator;
    [SerializeField] vThirdPersonController thirdPersonController;
    [SerializeField] vThirdPersonInputBase thirdPersonInput;
    public ReactiveProperty<float> HealthRP { get; private set; } = new ReactiveProperty<float>(80);

    public float MaxHealth { get => maxHealth; }

    public Rigidbody Rb { get => rb; }
    public Collider Colider { get => colider; }
    public Animator Animator { get => animator; }

    public Transform Transform => transform;
    public float MoveSpeed => thirdPersonController.moveSpeed;

    public bool IsStrafe
    {
        get => thirdPersonController.isStrafing;
        set => thirdPersonController.ToggleStrafe(value);
    }

    public Vector3 Input
    {
        get => thirdPersonController.input;
        set => thirdPersonController.input = value;
    }

    public Transform StrafeDirectionTransform => thirdPersonInput.strafeDirectionT;

    public bool IsWalking { get => thirdPersonController.freeSpeed.walkByDefault; set => thirdPersonController.freeSpeed.walkByDefault = value; }

    public MonoBehaviour ThirdPersonInputMonobehaviour => thirdPersonInput;
}