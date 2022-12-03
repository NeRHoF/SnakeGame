using System;
using System.Collections.Generic;
using System.Drawing;
using Model;
using View;

namespace WindowsFormsView
{
    public class ViewRecordLineWindows : ViewRecordLine
    {
        /// <summary>
        /// Объект двойной буферизации
        /// </summary>
        private readonly BufferedGraphics _bufferedGraphics;
        /// <summary>
        /// Координата Х вывода имени
        /// </summary>
        private const int X_ITEM_NAME = 300;
        /// <summary>
        /// Координата Х вывода рекорда
        /// </summary>
        private const int X_ITEM_SCORE = 500;
        /// <summary>
        /// Координата Y начала вывода таблицы
        /// </summary>
        private const int Y_START = 70;
        /// <summary>
        /// Высота строки
        /// </summary>
        private const int HEIGHT_ITEM = 30;
        /// <summary>
        /// Размер шрифта
        /// </summary>
        private const int FONT_SIZE = 18;
        /// <summary>
        /// Имя шрифта
        /// </summary>
        private const string FONT_FAMILY = "Arial";
        /// <summary>
        /// Формат строки вывода
        /// </summary>
        private readonly StringFormat _stringFormat;

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="parX">Позиция X стартовая</param>
        /// <param name="parY">Позиция Y стартовая</param>
        /// <param name="parBufferedGraphics">Объект вывода для двойной буфферизации</param>
        public ViewRecordLineWindows(int parX, int parY, BufferedGraphics parBufferedGraphics) : base(parX, parY)
        {
            _bufferedGraphics = parBufferedGraphics;
            _stringFormat = StringFormat.GenericDefault;
            _stringFormat.Alignment = StringAlignment.Center;
            _stringFormat.LineAlignment = StringAlignment.Near;
        }

        /// <summary>
        /// Вывод всех строк таблицы рекордов
        /// </summary>
        /// <param name="parRecords">Список таблицы рекордов</param>
        public override void DrawAllItems(List<ModelRecordLine> parRecords)
        {
            int num = 0;
            DrawItem("Игрок", "Очки", num++);
            foreach (var item in parRecords)
            {
                DrawItem(item.Name, item.Score.ToString(), num++);
            }
        }

        /// <summary>
        /// Вывод одной строки таблицы рекордов
        /// </summary>
        /// <param name="parFirstColumn">Значение ячейки первого столбца</param>
        /// <param name="parSecondColumn">Значение ячейки второго столбца</param>
        /// <param name="parNum">Номер строки</param>
        public override void DrawItem(String parFirstColumn, String parSecondColumn, int parNum)
        {
            Pen pen = new Pen(Color.Indigo);
            int y = Y_START + parNum * HEIGHT_ITEM;
            int centerPoint = (X_ITEM_SCORE - X_ITEM_NAME) / 2;
            _bufferedGraphics.Graphics.DrawRectangle(pen, X_ITEM_NAME, y, X_ITEM_SCORE - X_ITEM_NAME, HEIGHT_ITEM);
            _bufferedGraphics.Graphics.DrawRectangle(pen, X_ITEM_SCORE, y, centerPoint, HEIGHT_ITEM);
            _bufferedGraphics.Graphics.DrawString(parFirstColumn, new Font(FONT_FAMILY, FONT_SIZE), new SolidBrush(Color.Red), X_ITEM_NAME + centerPoint, Y_START + parNum * HEIGHT_ITEM, _stringFormat);
            _bufferedGraphics.Graphics.DrawString(parSecondColumn, new Font(FONT_FAMILY, FONT_SIZE), new SolidBrush(Color.Red), X_ITEM_SCORE + centerPoint / 2, Y_START + parNum * HEIGHT_ITEM, _stringFormat);
        }
    }
}