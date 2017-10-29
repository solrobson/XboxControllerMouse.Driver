using System.Windows.Forms;

namespace XboxControllerMouse.Library.Actions
{
    public class RightArrow : IXinputAction
    {
        public void Event()
        {
            SendKeys.SendWait("{Right}");
            System.Threading.Thread.Sleep(500);
        }
    }
}