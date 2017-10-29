using System.Windows.Forms;

namespace XboxControllerMouse.Library.Actions
{
    public class DownArrow : IXinputAction
    {
        public void Event()
        {
            SendKeys.SendWait("{Down}");
            System.Threading.Thread.Sleep(500);
        }
    }
}