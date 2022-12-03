using System.Collections.Generic;
using Model.Objects;

namespace View.Objects
{
    /// <summary>
    ///  Базовый класс представления игрового объекта
    /// </summary>
    public abstract class ViewGameObject : ViewObject
    {
        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="parOffsetX">Смещение объекта по оси X</param>
        /// <param name="parOffsetY">Смещение объекта по оси Y</param>
        public ViewGameObject(int parOffsetX, int parOffsetY) : base(parOffsetX, parOffsetY)
        {
        }
        
        /// <summary>
        /// Метод вывода одного объекта
        /// </summary>
        /// <param name="parGameObject">Объект для вывода</param>
        public abstract void Draw(GameObject parGameObject);

        /// <summary>
        /// Метод вывода списка объектов
        /// </summary>
        /// <param name="parGameObjects">Список объектов для вывода</param>
        public void DrawAllObjects(List<GameObject> parGameObjects)
        {
            for (int i = 0; i < parGameObjects.Count; i++)
            {
                Draw(parGameObjects[i]);
            }
        }
    }
}