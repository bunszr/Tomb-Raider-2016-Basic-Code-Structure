using UnityEngine;

public class SingletonDontDestroy<T> : MonoBehaviour where T : MonoBehaviour
{
    public static T Ins { get; private set; }

    protected virtual void Awake()
    {
        if (Ins != null)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        Ins = GetComponent<T>();
    }
}