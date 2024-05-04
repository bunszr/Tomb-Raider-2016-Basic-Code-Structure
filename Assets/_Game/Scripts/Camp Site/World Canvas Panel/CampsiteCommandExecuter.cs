using System.Collections.Generic;
using UnityEngine;

namespace CampSite
{
    public class CampsiteCommandExecuter : MonoBehaviour
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
