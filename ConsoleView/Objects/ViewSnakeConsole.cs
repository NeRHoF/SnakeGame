using System;
using Model.Objects;

namespace ConsoleView.Objects
{
    /// <summary>
    /// Представление змеи для консоли
    /// </summary>
    public class ViewSnakeConsole : ViewGameObjectConsole
    {
        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="parOffsetX">Координата X</param>
        /// <param name="parOffsetY">Координата Y</param>
        public ViewSnakeConsole(int parOffsetX, int parOffsetY) : base(parOffsetX, parOffsetY)
        {
        }

        /// <summary>
        /// Метод вывода части змеи на консоль
        /// </summary>
        /// <param name="parGameObject">чассть змеи</param>
        public override void Draw(GameObject parGameObject)
        {
            if (parGameObject is SnakeHead)
            {
                PrintObject("+", parGameObject, ConsoleColor.DarkGreen);
            }
            else if (parGameObject is SnakeTail)
            {
                PrintObject("*", parGameObject, ConsoleColor.Green);
            }
        }
    }
}