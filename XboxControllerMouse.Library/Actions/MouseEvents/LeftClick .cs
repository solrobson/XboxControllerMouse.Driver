using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XboxControllerMouse.Library.Actions.MouseEvents
{
    public class LeftClick : IXinputAction
    {
        public void Event()
        {
            Mouse.Mouse.Instance.LeftClick();
        }
    }
}
