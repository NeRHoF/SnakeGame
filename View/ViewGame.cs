using System.Threading;
using Model;

namespace View
{
    /// <summary>
    /// Базовое представаление игры
    /// </summary>
    public abstract class ViewGame
    {
        /// <summary>
        /// Модель игры
        /// </summary>
        private ModelGame _modelGame;
        
        /// <summary>
        /// Поток отрисовки
        /// </summary>
        protected Thread ThreadView { get; set; }

        /// <summary>
        /// Блокировочный объект для потоков
        /// </summary>
        protected static object Locker { get; set; } = new object();
        

        /// <summary>
        /// Модель игры
        /// </summary>
        protected ModelGame ModelGame
        {
            get => _modelGame;
            set
            {
                _modelGame = value;
                _modelGame.GameOver += _modelGame_GameOver;
            }
        }
        
        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="parModelGame">Модель игры</param>
        /// <param name="parForm">Форма для вывода игры</param>
        public ViewGame(ModelGame parModelGame)
        {
            ModelGame = parModelGame;
        }
        
        /// <summary>
        /// Обработчик события победы в игре
        /// </summary>
        private void _modelGame_GameOver()
        {
            StopGame();
        }

        /// <summary>
        /// Останавливает поток вывода на форму.
        /// </summary>
        public virtual void StopGame()
        {
            ThreadView.Abort();
        }
        
        /// <summary>
        /// Основной метод отображения игры
        /// </summary>
        protected abstract void ShowGame();
    }
}