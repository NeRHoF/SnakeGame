using System.Threading;
using Model;

namespace View
{
    /// <summary>
    /// Базовое представление таблицы рекордов
    /// </summary>
    public abstract class ViewRecords
    {
        /// <summary>
        /// Модель таблицы рекордов
        /// </summary>
        protected ModelRecords Model { get; set; }

        /// <summary>
        /// Поток вывода таблицы рекордов
        /// </summary>
        protected Thread ThreadView { get; set; }

        /// <summary>
        /// Объект блокировщик потока вывода
        /// </summary>
        protected object Locker { get; set; }
        
        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="parModel">Модель таблицы рекордов</param>
        public ViewRecords(ModelRecords parModel)
        {
            Locker = new object();
            parModel = Model;
        }

        /// <summary>
        /// Остановка потока вывода
        /// </summary>
        public abstract void StopView();

        /// <summary>
        /// Вывод таблицы рекордов
        /// </summary>
        public abstract void ShowRecords();
    }
}