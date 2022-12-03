namespace Model.Objects
{
    /// <summary>
    /// Модель игрового объекта
    /// </summary>
    public abstract class GameObject
    {
        /// <summary>
        /// Координата X игрового объекта
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// Координата Y игрового объекта
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="parX">Координата X</param>
        /// <param name="parY">Координата Y</param>
        public GameObject(int parX, int parY)
        {
            X = parX;
            Y = parY;
        }

        /// <summary>
        /// Метод сравнения игровых объектов
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            return this.X == ((GameObject) obj).X &&
                   this.Y == ((GameObject) obj).Y;
        }
    }
}