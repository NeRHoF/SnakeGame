using System.Collections.Generic;
using Model;

namespace View
{
    /// <summary>
    /// Представление пункта меню
    /// </summary>
    public abstract class ViewMenuItem
    {
        /// <summary>
        /// Координата X пункта меню
        /// </summary>
        protected int X { get; set; }

        /// <summary>
        /// Координата Y пункта меню
        /// </summary>
        protected int Y { get; set; }

        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="parX">Координата X пункта меню</param>
        /// <param name="parY">Координата Y пункта меню</param>
        protected ViewMenuItem(int parX, int parY)
        {
            X = parX;
            Y = parY;
        }

        /// <summary>
        /// Вывод всех пунктов меню
        /// </summary>
        /// <param name="parListStates">Список всех пунктов меню</param>
        /// <param name="parActualState">Номер выбранного пункта меню</param>
        public abstract void DrawAllItems(List<ModelMenuItem> parListStates, int parActualState);
    }
}