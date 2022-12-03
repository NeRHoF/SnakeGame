using Model;
using View;

namespace Controller
{
    /// <summary>
    /// Базовый контроллер меню
    /// </summary>
    public abstract class ControllerMenu
    {
        /// <summary>
        /// Модель меню
        /// </summary>
        protected ModelMenu Model { get; set; }

        /// <summary>
        /// Представление меню
        /// </summary>
        protected ViewMenu View { get; set; }

        /// <summary>
        /// Делегат события выбора пункта меню
        /// </summary>
        /// <param name="parItem">Номер выбранного пункта меню</param>
        /// <param name="parController">Текущий объект</param>
        public delegate void dChoosedMenuItem(int parItem, ControllerMenu parController);

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        protected ControllerMenu()
        {
        }

        /// <summary>
        /// Запуск контролера
        /// </summary>
        public abstract void Start();
    }
}