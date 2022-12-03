using System.Threading;

namespace View
{
    /// <summary>
    /// Базовое представление нового рекорда
    /// </summary>
    public abstract class ViewNewRecord
    {
        /// <summary>
        /// Заголовок нового рекорда
        /// </summary>
        protected const string STRING_NEW_RECORD = "Новый рекорд! Введите своё имя и нажмите Enter";

        /// <summary>
        /// Поток вывода
        /// </summary>
        public Thread ThreadView { get; set; }

        /// <summary>
        /// Объект блокировщик потока вывода
        /// </summary>
        protected object Locker { get; set; }

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        protected ViewNewRecord()
        {
            Locker = new object();
        }

        /// <summary>
        /// Запуск потока вывода
        /// </summary>
        public void StartDrawing()
        {
            ThreadView = new Thread(Draw);
            ThreadView.Start();
        }

        /// <summary>
        /// Остановка потока вывода
        /// </summary>
        public abstract void StopDrawing();

        /// <summary>
        /// Метод рисования
        /// </summary>
        protected abstract void Draw();
    }
}