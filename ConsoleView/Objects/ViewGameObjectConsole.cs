using System;
using Model.Objects;
using View.Objects;

namespace ConsoleView.Objects
{
    /// <summary>
    /// БАзовый класс представления для игрового объекта
    /// </summary>
    public abstract class ViewGameObjectConsole : ViewGameObject
    {
        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="parOffsetX">Смещение по оси X</param>
        /// <param name="parOffsetY">Смещение по оси Y</param>
        protected ViewGameObjectConsole(int parOffsetX, int parOffsetY) : base(parOffsetX, parOffsetY)
        {
        }

        /// <summary>
        /// Вывод объекта в консоль
        /// </summary>
        /// <param name="parObjectPicture">Изображение объекта</param>
        /// <param name="parGameObject">Игровой объект</param>
        /// <param name="parColor">Цвет объекта</param>
        protected void PrintObject(string parObjectPicture, GameObject parGameObject, ConsoleColor parColor)
        {
            int x = parGameObject.X * ViewGameConsole.WIDTH_GAME_OBJECT + OffsetX;
            int y = parGameObject.Y * ViewGameConsole.HEIGHT_GAME_OBJECT + OffsetY;

            FastOutput.Write(parObjectPicture, x, y, parColor);
        }
    }
}