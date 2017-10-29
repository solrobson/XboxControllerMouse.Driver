
namespace XboxControllerMouse.Driver
{
    class Program
    {
        static void Main(string[] args)
        {
            var xMouse = new Library.XBoxMouse();
            xMouse.Run();
        }
    }
}
