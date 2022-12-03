using System;
using System.Collections.Generic;
using Model;
using View;

namespace ConsoleView
{
    /// <summary>
    /// Представление строки рекордов для консоли
    /// </summary>
    public class ViewRecordLineConsole : ViewRecordLine
    {
        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="parX">Начальная позиция X</param>
        /// <param name="parY">Начальная позиция Y</param>
        public ViewRecordLineConsole(int parX, int parY) : base(parX, parY)
        {
        }

        /// <summary>
        /// Вывод всех строк рекордов на консоль
        /// </summary>
        /// <param name="parRecords">Строки таблицы рекордов</param>
        public override void DrawAllItems(List<ModelRecordLine> parRecords)
        {
            int num = 0;
            DrawItem("Игрок", "Очки", num++);
            foreach (var elLine in parRecords)
            {
                DrawItem(elLine.Name, elLine.Score.ToString(), num++);
            }
        }

        /// <summary>
        /// Вывод одной строки на консоль
        /// </summary>
        /// <param name="parFirstColumn">Значение первой колонки</param>
        /// <param name="parSecondColumn">Значение второй колонки</param>
        /// <param name="parNum">Номер строки</param>
        public override void DrawItem(string parFirstColumn, string parSecondColumn, int parNum)
        {
            FastOutput.Write(parFirstColumn, X, Y + parNum * 2, ConsoleColor.White);
            FastOutput.Write(parSecondColumn, X + 20, Y + parNum * 2, ConsoleColor.White);
        }
    }
}