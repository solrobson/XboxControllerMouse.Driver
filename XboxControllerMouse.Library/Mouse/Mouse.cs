using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace XboxControllerMouse.Library.Mouse
{
    public class Mouse
    {
        private static Mouse _mouse;

        private Mouse()
        {

        }


        public static Mouse Instance
        {
            get
            {
                if (_mouse == null)
                {
                    _mouse = new Mouse();
                }

                return _mouse;
            }
        }
        [DllImport("User32.Dll")]
        public static extern long SetCursorPos(int x, int y);

        [DllImport("User32.Dll")]
        public static extern bool ClientToScreen(IntPtr hWnd, ref POINT point);

        [DllImport("user32.dll")]
        private static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);

        public void RightClick()
        {
            CallMouseEvent(MouseEventFlags.RightUp);
        }

        public void LeftClick()
        {
            CallMouseEvent(MouseEventFlags.LeftDown);
            CallMouseEvent(MouseEventFlags.LeftUp);
        }

        public void CallMouseEvent(MouseEventFlags flag)
        {
            mouse_event((int)flag, Cursor.Position.X, Cursor.Position.Y, 0, 0);
        }

        [Flags]
        public enum MouseEventFlags
        {
            LeftDown = 0x00000002,
            LeftUp = 0x00000004,
            MiddleDown = 0x00000020,
            MiddleUp = 0x00000040,
            Move = 0x00000001,
            Absolute = 0x00008000,
            RightDown = 0x00000008,
            RightUp = 0x00000010
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            public int x;
            public int y;
        }
    }
}
