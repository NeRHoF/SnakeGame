using Model;
using View;

namespace Controller
{
    /// <summary>
    /// Общий контроллер таблицы рекордов
    /// </summary>
    public abstract class ControllerRecords
    {
        /// <summary>
        /// Иодель таблицы рекордов
        /// </summary>
        public ModelRecords Model { get; set; }

        /// <summary>
        /// Представление таблиц рекордов
        /// </summary>
        public ViewRecords View { get; set; }

        /// <summary>
        /// Запуск отслеживания нажатия кнопки
        /// </summary>
        public abstract void Start();
    }
}