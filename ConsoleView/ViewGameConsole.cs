using System;
using System.Threading;
using ConsoleView.Objects;
using ConsoleView.Objects.Factories;
using Model;
using View;
using View.Objects;

namespace ConsoleView
{
    /// <summary>
    /// Представление игры для консоли
    /// </summary>
    public class ViewGameConsole : ViewGame
    {
        /// <summary>
        /// Ширина консоли
        /// </summary>
        private const int WIDTH_CONSOLE = 80;
        /// <summary>
        /// Высота консоли
        /// </summary>
        private const int HEIGHT_CONSOLE = 40;
        /// <summary>
        /// Таймаут обновления игры
        /// </summary>
        private const int MILLISECONDS_TIMEOUT = 10;
        /// <summary>
        /// Ширина игрового объекта
        /// </summary>
        public const int WIDTH_GAME_OBJECT = 1;
        /// <summary>
        /// Высота игрового объекта
        /// </summary>
        public const int HEIGHT_GAME_OBJECT = 1;
        
        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="parModelGame">Модель игры</param>
        public ViewGameConsole(ModelGame parModelGame) : base(parModelGame)
        {
            Console.CursorVisible = false;
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            Console.SetBufferSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            ModelGame.ReadyToPlay += _model_ReadyToPlay;
        }

        /// <summary>
        /// Обработчик события готовности к игре
        /// </summary>
        private void _model_ReadyToPlay()
        {
            ThreadView = new Thread(ShowGame);
            ThreadView.Start();
            
        }

        /// <summary>
        /// Вывод игры на консоль
        /// </summary>
        protected override void ShowGame()
        {
            Console.SetWindowSize(WIDTH_CONSOLE, HEIGHT_CONSOLE);
            int offsetX = 1;
            int offsetY = 1;
            ViewGameObjectConsoleFactory factory = new ViewGameObjectConsoleFactory();

            ViewFoodConsole viewFoodConsole = (ViewFoodConsole)factory.CreateView(ViewType.Food, offsetX, offsetY);
            ViewSnakeConsole viewSnakeConsole = (ViewSnakeConsole) factory.CreateView(ViewType.Snake, offsetX, offsetY);
            ViewWallConsole viewWallConsole = (ViewWallConsole) factory.CreateView(ViewType.Wall, offsetX, offsetY);

            ViewScoresConsole viewScoresConsole = new ViewScoresConsole(offsetX, offsetY);

            while (true)
            {
                Thread.Sleep(MILLISECONDS_TIMEOUT);
                lock (Locker)
                {
                    FastOutput.Clear();
                    viewWallConsole.DrawAllObjects(ModelGame.Walls);
                    viewSnakeConsole.DrawAllObjects(ModelGame.Snake.SnakeObjects);
                    viewFoodConsole.Draw(ModelGame.Food);
                    
                    viewScoresConsole.Draw(ModelGame.Scores);
                }
                
                FastOutput.PrintOnConsole();
            }
        }
    }
}