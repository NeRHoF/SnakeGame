using System.Collections.Generic;
using System.Drawing;
using Model;
using View;

namespace WindowsFormsView
{
    /// <summary>
    /// Представление пункта меню для WindowsForms
    /// </summary>
    public class ViewMenuItemWindows : ViewMenuItem
    {
        /// <summary>
        /// Объект двойной буферизации
        /// </summary>
        private BufferedGraphics _bufferedGraphics;
        /// <summary>
        /// Высота пункта меню
        /// </summary>
        private const int HEIGHT_ITEM_MENU = 35;
        /// <summary>
        /// Расстояние между пунктами меню
        /// </summary>
        private const int OFFSET_ITEM = 25;
        /// <summary>
        /// Размер шрифта
        /// </summary>
        private const int FONT_SIZE = 16;
        /// <summary>
        /// Шрифт
        /// </summary>
        private const string FONT_FAMILY = "Arial";
        /// <summary>
        /// Ширина пункта меню
        /// </summary>
        public const int WIDTH_ITEM_MENU = 200;

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="parX">Позиция x</param>
        /// <param name="parY">Позиция у</param>
        /// <param name="parBufferedGraphics">Объект вывода для двойной буфферизации</param>
        public ViewMenuItemWindows(int parX, int parY, BufferedGraphics parBufferedGraphics) : base(parX, parY)
        {
            _bufferedGraphics = parBufferedGraphics;
        }

        /// <summary>
        /// Выводит все пункты на форму
        /// </summary>
        /// <param name="parListStates">Список пунктов меню</param>
        /// <param name="parActualState">Номер выбранного пункта меню</param>
        public override void DrawAllItems(List<ModelMenuItem> parListStates, int parActualState)
        {
            var yDraw = Y;
            for (int i = 0; i < parListStates.Count; i++)
            {
                if (i == parActualState)
                {
                    Draw(X, yDraw, parListStates[i].Text, true);
                }
                else
                {
                    Draw(X, yDraw, parListStates[i].Text, false);
                }
                yDraw += HEIGHT_ITEM_MENU + OFFSET_ITEM;
            }
        }


        /// <summary>
        /// Метод вывода на форму меню
        /// </summary>
        /// <param name="parX">Координата Х</param>
        /// <param name="parY">Координата у</param>
        /// <param name="parText">Текст вывода</param>
        /// <param name="isActive">Активен ли пункт меню</param>
        private void Draw(int parX, int parY, string parText, bool isActive)
        {
            Brush brushMenuItemBackgroung;
            Brush brushMenuItemText;
            if (isActive)
            {
                brushMenuItemBackgroung = new SolidBrush(Color.White);
                brushMenuItemText = new SolidBrush(Color.Green);
            }
            else
            {
                brushMenuItemBackgroung = new SolidBrush(Color.Green);
                brushMenuItemText = new SolidBrush(Color.White);
            }
            Font drawFont = new Font(FONT_FAMILY, FONT_SIZE);
            _bufferedGraphics.Graphics.FillRectangle(brushMenuItemBackgroung, new Rectangle(parX, parY, WIDTH_ITEM_MENU, HEIGHT_ITEM_MENU));
            var format = StringFormat.GenericDefault;
            format.Alignment = StringAlignment.Center;
            format.LineAlignment = StringAlignment.Center;

            _bufferedGraphics.Graphics.DrawString(parText, drawFont, brushMenuItemText, new Point(parX + (WIDTH_ITEM_MENU) / 2, parY + (HEIGHT_ITEM_MENU) / 2), format);
        }
    }
}