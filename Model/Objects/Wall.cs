namespace Model.Objects
{
    /// <summary>
    /// Модель стены
    /// </summary>
    public class Wall : GameObject
    {
        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="parX">Координата X</param>
        /// <param name="parY">Координата Y</param>
        public Wall(int parX, int parY) : base(parX, parY)
        {
        }

        /// <summary>
        /// Проверка на столкновение со стеной
        /// </summary>
        /// <param name="parGameObject"></param>
        /// <returns></returns>
        public bool IsHit(GameObject parGameObject)
        {
            return this.Equals(parGameObject);
        }
    }
}