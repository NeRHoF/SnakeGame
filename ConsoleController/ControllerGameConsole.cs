using System;
using System.Resources;
using System.Threading;
using ConsoleView;
using Model;
using Model.Objects;

namespace ConsoleController
{
    /// <summary>
    /// Контроллер игры для консоли
    /// </summary>
    public class ControllerGameConsole : Controller.ControllerGame
    {

        /// <summary>
        /// Событие возникающее при победе
        /// </summary>
        public event ModelGame.dEventHandler GameWin;

        /// <summary>
        /// Событие возникающее при выходе в меню
        /// </summary>
        public event ModelGame.dEventHandler GameClose;

        /// <summary>
        /// Идет ли игра сейчас
        /// </summary>
        private bool _isPlaying;

        private Thread _threadKeys;

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public ControllerGameConsole()
        {
            Model = new ModelGame();
            View = new ViewGameConsole(Model);
            Model.GameOver += _model_GameOver;
            Model.ReadyToPlay += _model_ReadyToPlay;
        }

        /// <summary>
        /// Обработчик готовности к игре
        /// </summary>
        private void _model_ReadyToPlay()
        {
            _isPlaying = true;
            Model.ReadyToPlay -= _model_ReadyToPlay;
            _threadKeys = new Thread(KeyListener);
            _threadKeys.Start();
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

        private void KeyListener()
        {
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                    switch (keyInfo.Key)
                    {
                        case ConsoleKey.LeftArrow:
                            Model.Snake.Rotation(Direction.Left);
                            break;
                        case ConsoleKey.RightArrow:
                            Model.Snake.Rotation(Direction.Right);
                            break;
                        case ConsoleKey.UpArrow:
                            Model.Snake.Rotation(Direction.Up);
                            break;
                        case ConsoleKey.DownArrow:
                            Model.Snake.Rotation(Direction.Down);
                            break;
                        case ConsoleKey.Escape:
                            View.StopGame();
                            _isPlaying = false;
                            GameClose?.Invoke();
                            return;
                    }
                }
            }
        }

        /// <summary>
        /// Обработчик победы
        /// </summary>
        private void _model_GameOver()
        {
            Model.GameOver -= _model_GameOver;
            Model.ReadyToPlay -= _model_ReadyToPlay;
            _isPlaying = false;
            GameWin?.Invoke();
        }

    }
}