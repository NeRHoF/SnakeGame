using System;
using System.Threading;
using System.Windows.Forms;
using WindowsFormsView;
using Controller;
using Model;
using Model.Objects;

namespace WindowsFormsController
{
    /// <summary>
    /// Контроллер игры для WindowsForms
    /// </summary>
    public class ControllerGameWindows : ControllerGame
    {
        /// <summary>
        /// Идет ли игра
        /// </summary>
        private bool _isPlaying;

        private Thread _gameThread;
        
        /// <summary>
        /// Событие, вызывающееся при выигрыше игры
        /// </summary>
        public event ModelGame.dEventHandler GameWin;

        /// <summary>
        /// Событие, вызывающееся при выходе в меню
        /// </summary>
        public event ModelGame.dEventHandler GameClose;

        /// <summary>
        /// Конструктор контроллера игры
        /// </summary>
        /// <param name="parGameForm">Форма вывода игры</param>
        public ControllerGameWindows()
        {
            Model = new Model.ModelGame();
            Model.GameOver += _model_GameOver;
            Model.ReadyToPlay += StartGame;
            View = new ViewGameWindows(Model);
            ((ViewGameWindows) View).KeyDown += ControllerGameWindows_KeyDown;
        }

        /// <summary>
        /// Запуск игры
        /// </summary>
        private void StartGame()
        {
            _isPlaying = true;
            _gameThread = new Thread(GameControll);
            _gameThread.Start();
        }

        /// <summary>
        /// Изменение состояния модели
        /// </summary>
        private void GameControll()
        {
            while (_isPlaying)
            {
                if (!Model.CheckGameOver())
                {
                    if (Model.Snake.Eat(Model.Food))
                    {
                        Model.Scores += Model.Food.Score;
                        Model.Food = Model.FoodFactory.CreateFood();
                    }
                    else
                    {
                        Model.Snake.Move();
                    }
                }
                Thread.Sleep(200);
            }
        }

        /// <summary>
        /// Обработчик события нажатия на кнопку клавиатуры
        /// </summary>
        /// <param name="parE"></param>
        private void ControllerGameWindows_KeyDown(KeyEventArgs parE) ////Замени на строку
        {
            switch (parE.KeyData)
            {
                case Keys.Left:
                    Model.Snake.Rotation(Direction.Left);
                    break;
                case Keys.Right:
                    Model.Snake.Rotation(Direction.Right);
                    break;
                case Keys.Up:
                    Model.Snake.Rotation(Direction.Up);
                    break;
                case Keys.Down:
                    Model.Snake.Rotation(Direction.Down);
                    break;
                case Keys.Escape:
                    View.StopGame();
                    _isPlaying = false;
                    GameClose?.Invoke();
                    return;
            }
        }
        
        /// <summary>
        /// Обработчик победы
        /// </summary>
        private void _model_GameOver()
        {
            Model.GameOver -= _model_GameOver;
            Model.ReadyToPlay -= StartGame;
            _isPlaying = false;
            GameWin?.Invoke();
        }

    }
}