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
