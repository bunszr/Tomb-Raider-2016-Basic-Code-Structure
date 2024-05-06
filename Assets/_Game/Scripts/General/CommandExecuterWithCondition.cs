using System;

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
}