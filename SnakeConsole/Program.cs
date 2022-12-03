using ConsoleController;

namespace SnakeConsole
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            ControllerMenuConsole controller = ControllerMenuConsole.GetInstance();
            controller.Start();
        }
    }
}