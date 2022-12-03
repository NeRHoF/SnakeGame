using System;
using System.Collections.Generic;
using Model;
using View;

namespace ConsoleView
{
    /// <summary>
    /// Представление пункта меню для консоли
    /// </summary>
    public class ViewMenuItemConsole : ViewMenuItem
    {
        /// <summary>
        /// Ширина пункта меню
        /// </summary>
        private const int WIDTH = 30;

        /// <summary>
        /// Расстояние между пунктами меню
        /// </summary>
        private const int OFFSET_ITEM = 4;
        
        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="parX">Координтата X</param>
        /// <param name="parY">Координата Y</param>
        public ViewMenuItemConsole(int parX, int parY) : base(parX, parY)
        {
        }

        /// <summary>
        /// Метод вывода всех пунктов меню в консоль
        /// </summary>
        /// <param name="parListStates">Список пунктов меню</param>
        /// <param name="parActualState">Выбранный пункт меню</param>
        public override void DrawAllItems(List<ModelMenuItem> parListStates, int parActualState)
        {
            var yDraw = Y;
            for (int i = 0; i < parListStates.Count; i++)
            {
                ConsoleColor color;
                if (i == parActualState)
                {
                    color = ConsoleColor.Red;
                }
                else
                {
                    color = ConsoleColor.Green;
                }
                Print(parListStates[i].Text, yDraw, color);
                yDraw += OFFSET_ITEM;
            }
        }

        /// <summary>
        /// вывод пункта меню в консоль
        /// </summary>
        /// <param name="parText">Текст пункта меню</param>
        /// <param name="parY">Позиция Y</param>
        /// <param name="parColor">Цвет</param>
        private void Print(string parText, int parY, ConsoleColor parColor)
        {
            string top = "╔" + "".PadRight(WIDTH, '═') + "╗";
            string bottom = "╚" + "".PadRight(WIDTH, '═') + "╝";
            parText = "║" + parText.PadLeft(parText.Length + (WIDTH - parText.Length) / 2, ' ').PadRight((WIDTH), ' ') + "║";
            FastOutput.Write(top, X, parY, parColor);
            FastOutput.Write(parText, X, parY + 1, parColor);
            FastOutput.Write(bottom, X, parY + 2, parColor);
        }
    }
}