using UnityEngine;
using UniRx;
using Invector.vCharacterController;

public abstract class LivingEntity : MonoBehaviour, IThirdPersonController
{
    [SerializeField] Rigidbody rb;
    [SerializeField] Collider colider;
    [SerializeField] Animator animator;
    [SerializeField] vThirdPersonController thirdPersonController;
    [SerializeField] vThirdPersonInput thirdPersonInput;
    public ReactiveProperty<int> Health { get; private set; } = new ReactiveProperty<int>(10);

    public Rigidbody Rb { get => rb; }
    public Collider Colider { get => colider; }
    public Animator Animator { get => animator; }
    public vThirdPersonController ThirdPersonController { get => thirdPersonController; }
    public vThirdPersonInput ThirdPersonInput { get => thirdPersonInput; }

    public Transform Transform => transform;
    public float MoveSpeed => ThirdPersonController.moveSpeed;

    public bool IsStrafe
    {
        get => ThirdPersonController.isStrafing;
        set => ThirdPersonController.ToggleStrafe(value);
    }

    public Vector3 Input
    {
        get => ThirdPersonController.input;
        set => ThirdPersonController.input = value;
    }

    public Transform StrafeDirectionTransform => thirdPersonInput.strafeDirectionT;
}