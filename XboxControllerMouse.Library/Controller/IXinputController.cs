using System.Drawing;

namespace XboxControllerMouse.Library.Controller
{
    public interface IXinputController
    {
        bool Connected { get; }
        bool IsA { get; }
        bool IsB { get; }
        bool IsDPadDown { get; }
        bool IsDPadLeft { get; }
        bool IsDPadRight { get; }
        bool IsDPadUp { get; }
        bool IsLeftBumper { get; }
        bool IsRightBumper { get; }
        bool IsBack { get; }
        bool IsStart { get; }
        bool IsX { get; }
        bool IsY { get; }
        Point LeftThumb { get; }
        float LeftTrigger { get; }
        Point RightThumb { get; }
        float RightTrigger { get; }

        void Update();
    }
}