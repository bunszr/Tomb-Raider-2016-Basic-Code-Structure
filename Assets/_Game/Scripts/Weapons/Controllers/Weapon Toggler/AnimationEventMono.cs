using UniRx;
using UnityEngine;

public class AnimationEventMono : MonoBehaviour
{
    public event System.Action<string> onAnimationEvent;

    public void RaiseAnimationEvent(string name)
    {
        onAnimationEvent?.Invoke(name);
    }
}

// public class AnimationEventMono : ObservableTriggerBase
// {
//     Subject<Unit> onEventRaise;
//     public event System.Action<string> onAnimationEvent;

//     public void RaiseAnimationEvent(string name)
//     {
//         if (onEventRaise != null) onEventRaise.OnNext(Unit.Default);
//     }

//     public IObservable<Unit> AsObservable()
//     {
//         return onEventRaise ?? (onEventRaise = new Subject<Unit>());
//     }

//     protected override void RaiseOnCompletedOnDestroy()
//     {
//         if (onEventRaise != null)
//         {
//             onEventRaise.OnCompleted();
//         }
//     }
// }

// public class GiantAttackEventMono : MonoBehaviour
// {
//     [SerializeField] Transform gunT;
//     public static event System.Action<Vector3> onHit;

//     public void Attack()
//     {
//         onHit?.Invoke(gunT.position + transform.forward);
//     }
// }