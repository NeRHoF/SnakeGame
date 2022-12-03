namespace View.Objects
{
    /// <summary>
    /// Базовое представление всех объектов
    /// </summary>
    public abstract class ViewObject
    {
        /// <summary>
        /// Смещение объекта по оси X
        /// </summary>
        protected int OffsetX { get; set; }

        /// <summary>
        /// Смещение объекта по оси Y
        /// </summary>
        protected int OffsetY { get; set; }

        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="parOffsetX">Смещение объекта по оси X</param>
        /// <param name="parOffsetY">Смещение объекта по оси Y</param>
        protected ViewObject(int parOffsetX, int parOffsetY)
        {
            OffsetX = parOffsetX;
            OffsetY = parOffsetY;
        }
    }
}