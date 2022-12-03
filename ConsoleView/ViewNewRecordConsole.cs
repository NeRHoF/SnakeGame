using System;
using View;

namespace ConsoleView
{
    /// <summary>
    /// Представление нового рекорда для консоли
    /// </summary>
    public class ViewNewRecordConsole : ViewNewRecord
    {
        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public ViewNewRecordConsole() : base()
        {
        }

        /// <summary>
        /// Окончание вывода
        /// </summary>
        public override void StopDrawing()
        {
            
        }

        /// <summary>
        /// Отрисовка нового рекорда
        /// </summary>
        protected override void Draw()
        {
            FastOutput.Clear();
            FastOutput.Write(STRING_NEW_RECORD, 10, 4, ConsoleColor.Blue);
            FastOutput.PrintOnConsole();
            Console.SetCursorPosition(15, 15);
        }
    }
}