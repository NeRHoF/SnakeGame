namespace Model.Objects
{
    /// <summary>
    /// Модель еды
    /// </summary>
    public class Food : GameObject
    {
        /// <summary>
        /// Очки за еду
        /// </summary>
        public int Score { get; } = 10;

        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="parX">Координата X</param>
        /// <param name="parY">Координата Y</param>
        public Food(int parX, int parY) : base(parX, parY)
        {
        }
    }
}