using System.Collections.Generic;

namespace CampSite
{
    public class CSUndoCommandExecuter
    {
        Stack<ICampsitePanelCommad> stack = new Stack<ICampsitePanelCommad>();

        public void AddCommand(ICampsitePanelCommad _campsitePanelCommad)
        {
            stack.Push(_campsitePanelCommad);
        }

        public void Undo()
        {
            if (stack.Count != 0) stack.Pop().Undo();
        }
    }
}