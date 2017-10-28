using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XboxControllerMouse.Library.Actions;
using XboxControllerMouse.Library.Mouse;

namespace XboxControllerMouse.Library.Actions.MouseEvents
{
    public class RightClick : IXinputAction 
    {
        public void Event()
        {
           Mouse.Mouse.Instance.RightClick();
        }
    }
}
