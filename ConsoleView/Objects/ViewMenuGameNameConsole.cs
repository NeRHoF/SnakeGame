using System;
using View.Objects;

namespace ConsoleView.Objects
{
    public class ViewMenuGameNameConsole : ViewMenuGameName
    {
        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="parOffsetX">Начальная координата X</param>
        /// <param name="parOffsetY">Начальная координата Y</param>
        public ViewMenuGameNameConsole(int parOffsetX, int parOffsetY) : base(parOffsetX, parOffsetY)
        {
        }

        /// <summary>
        /// Вывод на консоль
        /// </summary>
        public override void Draw()
        {
            int i = OffsetY;
            FastOutput.Write(" ////  //   //    ////    //  //  //////", OffsetX, i++, ConsoleColor.DarkGreen);
            FastOutput.Write("//     ///  //   //  //   // //   //    ", OffsetX, i++, ConsoleColor.DarkGreen);
            FastOutput.Write(" //    // / //  //    //  ////    //////", OffsetX, i++, ConsoleColor.DarkGreen);
            FastOutput.Write("  //   //  ///  ////////  ////    //////", OffsetX, i++, ConsoleColor.DarkGreen);
            FastOutput.Write("   //  //   //  //    //  // //   //    ", OffsetX, i++, ConsoleColor.DarkGreen);
            FastOutput.Write("////   //   //  //    //  //  //  //////", OffsetX, i++, ConsoleColor.DarkGreen);
        }
    }
}