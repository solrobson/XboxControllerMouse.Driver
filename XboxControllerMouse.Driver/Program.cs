using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XboxControllerMouse.Library.Controller;
using XboxControllerMouse.Library.Mouse;
using System.Windows.Forms;
using System.Reflection;
using XboxControllerMouse.Library.Actions;
using System.Configuration;

namespace XboxControllerMouse.Driver
{
    class Program
    {
        static void Main(string[] args)
        {
            var xMouse = new XboxControllerMouse.Library.XBoxMouse();
            xMouse.Run();
        }
    }
}
