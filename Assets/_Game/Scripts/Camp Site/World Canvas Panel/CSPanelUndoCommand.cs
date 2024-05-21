using CampSite;
using System;

public class CSPanelUndoCommand : ICampsitePanelCommad
{
    Action action;
    public CSPanelUndoCommand(Action action) => this.action = action;
    public void Undo() => action?.Invoke();
}