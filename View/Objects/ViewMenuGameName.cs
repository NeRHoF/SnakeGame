namespace View.Objects
{
    /// <summary>
    /// Представление заголовка игры в меню
    /// </summary>
    public abstract class ViewMenuGameName : ViewObject
    {
        /// <summary>
        /// конструктор с параметрами
        /// </summary>
        /// <param name="parOffsetX">Смещение объекта по оси X</param>
        /// <param name="parOffsetY">Смещение объекта по оси Y</param>
        protected ViewMenuGameName(int parOffsetX, int parOffsetY) : base(parOffsetX, parOffsetY)
        {
        }

        /// <summary>
        /// Метод вывода объекта
        /// </summary>
        public abstract void Draw();
    }
}