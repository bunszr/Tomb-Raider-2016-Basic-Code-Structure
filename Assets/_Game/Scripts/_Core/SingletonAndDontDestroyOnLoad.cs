using UnityEngine;

public class SingletonAndDontDestroyOnLoad<T> : MonoBehaviour where T : Component
{
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
                    DontDestroyOnLoad(obj);
                }
            }
            return instance;
        }
    }

    protected virtual void Awake()
    {
        if (instance != null) Destroy(gameObject);
    }
}