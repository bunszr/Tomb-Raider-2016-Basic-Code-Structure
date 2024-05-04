using CampSite;
using System;

public class CampsitePanelTogglerCommand : ICampsitePanelCommad
{
    Action action;
    public CampsitePanelTogglerCommand(Action action) => this.action = action;
    public void Undo() => action?.Invoke();
}