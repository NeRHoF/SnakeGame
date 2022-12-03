namespace Model.Objects
{
    /// <summary>
    /// Модель головы змеи
    /// </summary>
    public class SnakeHead : GameObject
    {
        /// <summary>
        /// Направление головы
        /// </summary>
        public Direction Direction { get; set; }

        /// <summary>
        /// Конструткор с параметрами
        /// </summary>
        /// <param name="parX">Координата X</param>
        /// <param name="parY">Координата Y</param>
        /// <param name="parDirection">Направление головы</param>
        public SnakeHead(int parX, int parY, Direction parDirection) : base(parX, parY)
        {
            Direction = parDirection;
        }
    }
}