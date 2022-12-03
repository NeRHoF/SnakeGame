using System;
using Model.Objects;

namespace ConsoleView.Objects
{
    /// <summary>
    /// представление стены для консоли
    /// </summary>
    public class ViewWallConsole : ViewGameObjectConsole
    {
        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="parOffsetX">Координата X</param>
        /// <param name="parOffsetY">Координата Y</param>
        public ViewWallConsole(int parOffsetX, int parOffsetY) : base(parOffsetX, parOffsetY)
        {
        }

        /// <summary>
        /// Вывод стены на консоль
        /// </summary>
        /// <param name="parGameObject">Стена</param>
        public override void Draw(GameObject parGameObject)
        {
            PrintObject("#", parGameObject, ConsoleColor.White);
        }
    }
}