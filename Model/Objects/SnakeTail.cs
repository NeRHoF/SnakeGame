namespace Model.Objects
{
    /// <summary>
    /// Модель хвоста змеи
    /// </summary>
    public class SnakeTail : GameObject
    {
        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="parX">Координата X</param>
        /// <param name="parY">Координата Y</param>
        public SnakeTail(int parX, int parY) : base(parX, parY)
        {
        }
    }
}