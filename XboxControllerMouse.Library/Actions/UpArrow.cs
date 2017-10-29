using System.Windows.Forms;

namespace XboxControllerMouse.Library.Actions
{
    public class UpArrow : IXinputAction
    {
        public void Event()
        {
            SendKeys.SendWait("{UP}");
            System.Threading.Thread.Sleep(500);
        }
    }
}
