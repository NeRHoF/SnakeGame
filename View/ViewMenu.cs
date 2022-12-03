using System.Threading;
using Model;

namespace View
{
    /// <summary>
    /// Базовое представление меню
    /// </summary>
    public abstract class ViewMenu
    {
        /// <summary>
        /// Координата X вывода главного меню
        /// </summary>
        protected int X { get; set; }

        /// <summary>
        /// Координата Y вывода главного меню
        /// </summary>
        protected int Y { get; set; }

        /// <summary>
        /// Ширина пунктов меню
        /// </summary>
        protected int Width { get; set; }

        /// <summary>
        /// Объект, блокирующий поток вывода
        /// </summary>
        protected object Locker { get; set; } = new object();

        /// <summary>
        /// Поток вывода
        /// </summary>
        public Thread ThreadView { get; set; }

        /// <summary>
        /// Модель меню
        /// </summary>
        public ModelMenu ModelMenu { get; set; }

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        protected ViewMenu()
        {
        }

        /// <summary>
        /// Запуск потока вывода
        /// </summary>
        public abstract void StartDrawing();

        /// <summary>
        /// Вывод меню
        /// </summary>
        public abstract void ShowMenu();
    }
}