using UnityEngine;

public class SingletonAndDontDestroyOnLoad<T> : MonoBehaviour where T : Component
{
    public static bool IsNotNull => instance != null;

    private static T instance;
    public static T Ins
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<T>();
                if (instance == null)
                {
                    GameObject obj = new GameObject();
                    obj.name = typeof(T).Name;
                    instance = obj.AddComponent<T>();
                }
            }
            return instance;
        }
    }

    protected virtual void Awake()
    {
        if (Ins != null && Ins != this) Destroy(gameObject);
        else DontDestroyOnLoad(gameObject);
    }
}