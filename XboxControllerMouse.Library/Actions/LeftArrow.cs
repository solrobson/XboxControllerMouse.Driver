using System.Windows.Forms;

namespace XboxControllerMouse.Library.Actions
{
    public class LeftArrow : IXinputAction
    {
        public void Event()
        {
            SendKeys.SendWait("{LEFT}");
            System.Threading.Thread.Sleep(500);
        }
    }
}