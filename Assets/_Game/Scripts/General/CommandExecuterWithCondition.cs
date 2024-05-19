using System;
using Sirenix.OdinInspector;

public class CommandExecuterWithCondition
{
    Func<bool> condition;
    IExecute[] _executeableArray;

    public CommandExecuterWithCondition(IExecute[] executeableArray, Func<bool> condition)
    {
        _executeableArray = executeableArray;
        this.condition = condition;
    }

    public void ExecuteAll()
    {
        if (condition()) for (int i = 0; i < _executeableArray.Length; i++) _executeableArray[i].Execute();
    }

#if UNITY_EDITOR
    [Button]
    void ExecuteAllWithNoCondition()
    {
        for (int i = 0; i < _executeableArray.Length; i++) _executeableArray[i].Execute();
    }
#endif
}