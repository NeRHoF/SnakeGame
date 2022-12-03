using System.Collections.Generic;
using Model;

namespace View
{
    /// <summary>
    /// Общее представление строки таблицы рекордов
    /// </summary>
    public abstract class ViewRecordLine
    {
        /// <summary>
        /// Координата X строки
        /// </summary>
        protected int X { get; set; }

        /// <summary>
        /// Координата Y строки
        /// </summary>
        protected int Y { get; set; }

        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="parX">Координата X</param>
        /// <param name="parY">Координата Y</param>
        protected ViewRecordLine(int parX, int parY)
        {
            X = parX;
            Y = parY;
        }

        /// <summary>
        /// Вывод всей таблицы рекордов
        /// </summary>
        /// <param name="parRecords"></param>
        public abstract void DrawAllItems(List<ModelRecordLine> parRecords);

        /// <summary>
        /// Вывод одной строки таблицы рекордов
        /// </summary>
        /// <param name="parFirstColumn">Значение ячейки первого столбца</param>
        /// <param name="parSecondColumn">Значение ячейки второго столбца</param>
        /// <param name="parNum">Номер строки</param>
        public abstract void DrawItem(string parFirstColumn, string parSecondColumn, int parNum);
    }
}