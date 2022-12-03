using Model;
using View;

namespace Controller
{
    /// <summary>
    /// Базовый контроллер игры
    /// </summary>
    public abstract class ControllerGame
    {
        /// <summary>
        /// Модель игры
        /// </summary>
        public ModelGame Model{ get; set; }

        /// <summary>
        /// Представление игры
        /// </summary>
        public ViewGame View { get; set; }

        /// <summary>
        /// Старт игры
        /// </summary>
        public virtual void Start()
        {
            Model.InitGame();
        }
    }
}