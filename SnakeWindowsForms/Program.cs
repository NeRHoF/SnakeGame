using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsController;

namespace SnakeWindowsForms
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ControllerMenuWindows controller = ControllerMenuWindows.GetInstance();
            controller.Start();
        }
    }
}