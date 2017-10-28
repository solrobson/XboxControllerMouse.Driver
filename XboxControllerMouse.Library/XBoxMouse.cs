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
using System;

namespace XboxControllerMouse.Library
{
    public class XBoxMouse
    {
        public void Run()
        {
           
            var controller = new XinputController();
            Mouse.Mouse.POINT p = new Mouse.Mouse.POINT();
            Mouse.Mouse mouse = Mouse.Mouse.Instance;
            bool mouseMode = true;

            while (controller.Connected)
            {
                controller.Update();

                if (controller.IsSelect && controller.IsStart)
                {
                    mouseMode = !mouseMode;
                    //Console.WriteLine("Status {0}", mouseMode);
                }

                if (!mouseMode)
                {
                    System.Threading.Thread.Sleep(500);
                    continue;
                }

                p.x = controller.LeftThumb.X / 2000;
                p.y = controller.LeftThumb.Y / 2000;


                Cursor c = new Cursor(Cursor.Current.Handle);
                var currentPosition = Cursor.Position;

                currentPosition.X += p.x;
                currentPosition.Y -= p.y;

                if (controller.RightTrigger == 255)
                {
                    var key = "righttrigger";
                    var assemblyName = ConfigurationManager.AppSettings[key];
                    var ass = assemblyName.Split(',');
                    var action = Assembly.GetExecutingAssembly().CreateInstance(assemblyName) as IXinputAction;
                    
                    action.Event();

                }

                if (controller.LeftTrigger == 255)
                {
                    mouse.LeftClick();
                }

                Mouse.Mouse.SetCursorPos(currentPosition.X, currentPosition.Y);
                System.Threading.Thread.Sleep(20);

            }
        }
    }
}
