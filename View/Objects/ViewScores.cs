namespace View.Objects
{
    /// <summary>
    /// Представление количества очков
    /// </summary>
    public abstract class ViewScores : ViewObject
    {
        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="parOffsetX">Координата X</param>
        /// <param name="parOffsetY">Координата Y</param>
        public ViewScores(int parOffsetX, int parOffsetY) : base(parOffsetX, parOffsetY)
        {
        }

        /// <summary>
        /// Вывод количества очков
        /// </summary>
        /// <param name="parScores">Количество очков</param>
        public abstract void Draw(int parScores);
    }
}