using Model;
using View;

namespace Controller
{
    /// <summary>
    /// Базовый контроллер для нового рекорда
    /// </summary>
    public abstract class ControllerNewRecord
    {
        /// <summary>
        /// Представление нового рекорда
        /// </summary>
        protected ViewNewRecord View { get; set; }

        /// <summary>
        /// Модель строки рекордов
        /// </summary>
        protected ModelRecordLine Model { get; set; }

        /// <summary>
        /// Модель таблицы рекордов
        /// </summary>
        protected ModelRecords ModelRecords { get; set; }

        /// <summary>
        /// Является ли новым рекордом
        /// </summary>
        protected bool IsNewRecord { get; set; }

        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="parScore">Набранные очки</param>
        protected ControllerNewRecord(int parScore)
        {
            ModelRecords = new ModelRecords();
            Model = new ModelRecordLine() {Score = parScore};
        }

        /// <summary>
        /// Запуск контроллера
        /// </summary>
        public abstract void Start();
    }
}