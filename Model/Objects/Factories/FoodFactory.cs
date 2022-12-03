using System;

namespace Model.Objects.Factories
{
    /// <summary>
    /// Фабрика еды
    /// </summary>
    public class FoodFactory
    {
        /// <summary>
        /// Координата X
        /// </summary>
        private int _x;

        /// <summary>
        /// Координата Y
        /// </summary>
        private int _y;

        /// <summary>
        /// Генератор случайных чисел
        /// </summary>
        private Random _random;

        /// <summary>
        /// Конструктор с парметрами
        /// </summary>
        /// <param name="parX">Координата X</param>
        /// <param name="parY">Координата Y</param>
        public FoodFactory(int parX, int parY)
        {
            _x = parX;
            _y = parY;
            _random = new Random();
        }

        /// <summary>
        /// Создание еды
        /// </summary>
        /// <returns>Объект еды</returns>
        public Food CreateFood()
        {
            return new Food(_random.Next(2, _x - 2), _random.Next(2, _y - 2));
        }
    }
}