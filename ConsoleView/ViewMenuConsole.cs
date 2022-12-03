using System;
using System.Text;
using System.Threading;
using ConsoleView.Objects;
using View;

namespace ConsoleView
{
    /// <summary>
    /// Консольное представление меню
    /// </summary>
    public class ViewMenuConsole : ViewMenu
    {
        /// <summary>
        /// Координата Y начала вывода
        /// </summary>
        private const int Y = 10;

        /// <summary>
        /// Время обновления
        /// </summary>
        private const int MILLISECONDS_TIMEOUT = 100;

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public ViewMenuConsole() : base()
        {
            Console.SetWindowSize(Console.WindowWidth, Console.LargestWindowHeight);
            Console.SetBufferSize(Console.WindowWidth, Console.LargestWindowHeight);
            X = Console.BufferWidth / 2 - 15;
            Console.CursorVisible = false;
        }

        /// <summary>
        /// Остановка потока вывода в консоль
        /// </summary>
        public void StopShowing()
        {
            ThreadView.Abort();
        }

        /// <summary>
        /// Запуск потокаа вывода
        /// </summary>
        public override void StartDrawing()
        {
            ThreadView = new Thread(ShowMenu);
            ThreadView.Start();
        }

        /// <summary>
        /// Вывод меню на консоль
        /// </summary>
        public override void ShowMenu()
        {
            ViewMenuItemConsole viewItem = new ViewMenuItemConsole(X, Y);
            ViewMenuGameNameConsole viewGameName = new ViewMenuGameNameConsole(40, 3);
            while (true)
            {
                lock (Locker)
                {
                    FastOutput.Clear();
                    viewItem.DrawAllItems(ModelMenu.ListStates, ModelMenu.ActualState);
                    viewGameName.Draw();
                    FastOutput.PrintOnConsole();
                    Console.CursorVisible = false;
                    Thread.Sleep(MILLISECONDS_TIMEOUT);
                }
            }
        }
    }
}