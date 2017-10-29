using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpDX.XInput;
using System.Drawing;

namespace XboxControllerMouse.Library.Controller
{
    public class XinputController : IXinputController
    {
        private SharpDX.XInput.Controller _controller { get; set; }
        private Gamepad _gamepad { get; set; }

        public bool Connected
        {
            get
            {
                return _controller != null ? _controller.IsConnected : false;
            }
        }

        public Point LeftThumb { get; private set; }
        public Point RightThumb { get; private set; }
        public float LeftTrigger { get; private set; }
        public float RightTrigger { get; private set; }

        public bool IsLeftThumbButton { get; set; }
        public bool IsRightThumbButton { get; set; }
        public bool IsX { get; private set; }
        public bool IsY { get; private set; }
        public bool IsA { get; private set; }
        public bool IsB { get; private set; }
        public bool IsStart { get; private set; }
        public bool IsBack { get; private set; }
        public bool IsRightBumper { get; private set; }
        public bool IsLeftBumper { get; private set; }

        public bool IsDPadUp { get; private set; }
        public bool IsDPadLeft { get; private set; }
        public bool IsDPadRight { get; private set; }
        public bool IsDPadDown { get; private set; }

        public XinputController()
        {
            _controller = new SharpDX.XInput.Controller(UserIndex.One);
        }

        public void Update()
        {
            if(Connected)
            {
                var gamepad = _controller.GetState().Gamepad;

                LeftThumb = new Point(gamepad.LeftThumbX, gamepad.LeftThumbY);
                RightThumb = new Point(gamepad.RightThumbX, gamepad.RightThumbY);

                LeftTrigger = gamepad.LeftTrigger;
                RightTrigger = gamepad.RightTrigger;

                IsLeftBumper = gamepad.Buttons.HasFlag(GamepadButtonFlags.LeftShoulder);
                IsRightBumper = gamepad.Buttons.HasFlag(GamepadButtonFlags.RightShoulder);

                IsA = gamepad.Buttons.HasFlag(GamepadButtonFlags.A);
                IsB = gamepad.Buttons.HasFlag(GamepadButtonFlags.B);
                IsX = gamepad.Buttons.HasFlag(GamepadButtonFlags.X);
                IsY = gamepad.Buttons.HasFlag(GamepadButtonFlags.Y);

                IsDPadDown = gamepad.Buttons.HasFlag(GamepadButtonFlags.DPadDown);
                IsDPadLeft = gamepad.Buttons.HasFlag(GamepadButtonFlags.DPadLeft);
                IsDPadRight = gamepad.Buttons.HasFlag(GamepadButtonFlags.DPadRight);
                IsDPadUp= gamepad.Buttons.HasFlag(GamepadButtonFlags.DPadUp);

                IsBack = gamepad.Buttons.HasFlag(GamepadButtonFlags.Back);
                IsStart = gamepad.Buttons.HasFlag(GamepadButtonFlags.Start);

                IsLeftThumbButton = gamepad.Buttons.HasFlag(GamepadButtonFlags.LeftThumb);
                IsRightThumbButton = gamepad.Buttons.HasFlag(GamepadButtonFlags.RightThumb);
            }
        }
    }
}
