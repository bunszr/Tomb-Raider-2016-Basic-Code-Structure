using UnityEngine;

public class IM : SingletonAndDontDestroyOnLoad<IM>
{
    public IInput Input { get; private set; }

    protected override void Awake()
    {
        base.Awake();

#if UNITY_STANDALONE_WIN || UNITY_EDITOR
        Input = new DesktopInput();
#endif
    }
}