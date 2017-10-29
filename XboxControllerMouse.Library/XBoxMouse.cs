using XboxControllerMouse.Library.Controller;
using System.Windows.Forms;
using System.Configuration;
using System;
using XboxControllerMouse.Library.Configuration;

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

            var turnOffReadRate = Convert.ToInt32(ConfigurationManager.AppSettings["TurnOffReadRate"]);
            var updateReadRate = Convert.ToInt32(ConfigurationManager.AppSettings["UpdateReadRate"]);
            var triggerSensitivity = Convert.ToInt32(ConfigurationManager.AppSettings["TriggerSensitivity"]);
            var mouseSensitivity = Convert.ToInt32(ConfigurationManager.AppSettings["MouseSensitivity"]);

            var XInputControllerManager = new XInputControllerConfigManager();

            while (controller.Connected)
            {
                controller.Update();

                if (controller.IsBack && controller.IsStart)
                {
                    mouseMode = !mouseMode;
                }

                if (!mouseMode)
                {
                    System.Threading.Thread.Sleep(turnOffReadRate);
                    continue;
                }

                p.x = controller.LeftThumb.X / mouseSensitivity;
                p.y = controller.LeftThumb.Y / mouseSensitivity;


                Cursor c = new Cursor(Cursor.Current.Handle);
                var currentPosition = Cursor.Position;

                currentPosition.X += p.x;
                currentPosition.Y -= p.y;

                if (controller.RightTrigger == triggerSensitivity)
                {
                    XInputControllerManager.ExecuteAction(InputNamesConstants.RightTrigger);
                }

                if (controller.LeftTrigger == triggerSensitivity)
                {
                    XInputControllerManager.ExecuteAction(InputNamesConstants.LeftTrigger);
                }

                if(controller.IsA)
                {
                    XInputControllerManager.ExecuteAction(InputNamesConstants.AButton);
                }

                if(controller.IsB)
                {
                    XInputControllerManager.ExecuteAction(InputNamesConstants.BButton);
                }

                if(controller.IsDPadDown)
                {
                    XInputControllerManager.ExecuteAction(InputNamesConstants.DPadDown);
                }

                if(controller.IsDPadLeft)
                {
                    XInputControllerManager.ExecuteAction(InputNamesConstants.DPadLeft);
                }

                if(controller.IsDPadRight)
                {
                    XInputControllerManager.ExecuteAction(InputNamesConstants.DPadRight);
                }

                if(controller.IsDPadUp)
                {
                    XInputControllerManager.ExecuteAction(InputNamesConstants.DPadUp);
                }

                if(controller.IsLeftBumper)
                {
                    XInputControllerManager.ExecuteAction(InputNamesConstants.LeftBumper);
                }

                if(controller.IsRightBumper)
                {
                    XInputControllerManager.ExecuteAction(InputNamesConstants.RightBumper);
                }

                if(controller.IsBack)
                {
                    XInputControllerManager.ExecuteAction(InputNamesConstants.BackButton);
                }

                if(controller.IsStart)
                {
                    XInputControllerManager.ExecuteAction(InputNamesConstants.StartButton);
                }

                if(controller.IsX)
                {
                    XInputControllerManager.ExecuteAction(InputNamesConstants.XButton);
                }

                if(controller.IsY)
                {
                    XInputControllerManager.ExecuteAction(InputNamesConstants.YButton);
                }

                if(controller.IsLeftThumbButton)
                {
                    XInputControllerManager.ExecuteAction(InputNamesConstants.LeftStickClick);
                }

                if(controller.IsRightThumbButton)
                {
                    XInputControllerManager.ExecuteAction(InputNamesConstants.RightStickClick);
                }

                Mouse.Mouse.SetCursorPos(currentPosition.X, currentPosition.Y);
                System.Threading.Thread.Sleep(updateReadRate);
            }
        }
    }
}
