using UnityEngine;

public class SingletonAndDontDestroyOnLoadZenject<T> : MonoBehaviour where T : Component
{
    private static T instance;
    public static T Ins
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<T>();
                if (instance == null) Debug.LogError("nullllll");
                else DontDestroyOnLoad(instance.gameObject);
            }
            return instance;
        }
    }

    protected virtual void Awake()
    {
        if (instance != null) Destroy(gameObject);
    }
}