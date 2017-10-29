using System.Windows.Forms;

namespace XboxControllerMouse.Library.Actions
{
    public class NextApplication : IXinputAction
    {
        public void Event()
        {
            SendKeys.SendWait("%{TAB}");
            System.Threading.Thread.Sleep(500);
        }
    }
}
