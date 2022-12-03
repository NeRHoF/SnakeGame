using System;
using Model.Objects;

namespace ConsoleView.Objects
{
    /// <summary>
    /// представление еды для консоли
    /// </summary>
    public class ViewFoodConsole : ViewGameObjectConsole
    {
        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="parOffsetX">Координата X</param>
        /// <param name="parOffsetY">Координата Y</param>
        public ViewFoodConsole(int parOffsetX, int parOffsetY) : base(parOffsetX, parOffsetY)
        {
        }

        /// <summary>
        /// Вывод еды на консоль
        /// </summary>
        /// <param name="parGameObject">еда</param>
        public override void Draw(GameObject parGameObject)
        {
            PrintObject("@", parGameObject, ConsoleColor.Red);
        }
    }
}