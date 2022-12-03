using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using WindowsFormsView.Objects;
using Model;
using View;

namespace WindowsFormsView
{
    /// <summary>
    /// Представление главного меню для WindowsForms
    /// </summary>
    public class ViewMenuWindows : ViewMenu
    {
        /// <summary>
        /// Время обновления экрана (мс)
        /// </summary>
        private const int MILLISECONDS_TIMEOUT = 10;
        /// <summary>
        /// Начальная координата Y вывода главного меню
        /// </summary>
        private const int Y = 200;
        /// <summary>
        /// Позиция вывода названия игры(у)
        /// </summary>
        private const int X_POSITION_GAME_NAME = 215;
        /// <summary>
        /// Позиция вывода названия игры(х)
        /// </summary>
        private const int Y_POSITION_GAME_NAME = 60;
        /// <summary>
        /// Форма вывода
        /// </summary>
        private Form _form;
        /// <summary>
        /// Объект двойной буферизации
        /// </summary>
        private BufferedGraphics _bufferedGraphics;

        /// <summary>
        /// Событие нажатия клавиши
        /// </summary>
        public event DKeyDown KeyDown;

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="parModelMenu">Модель главного меню</param>
        public ViewMenuWindows(ModelMenu parModelMenu)
        {
            ModelMenu = parModelMenu;
            if (Application.OpenForms.Count == 0)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(true);
                _form = new Form();
            }
            else
            {
                _form = Application.OpenForms[0];
            }
            var size = new Size(ViewGameWindows.WIDTH_WINDOW, ViewGameWindows.HEIGHT_WINDOW);
            _form.MaximumSize = size;
            _form.Size = size;
            _form.FormClosing += _form_FormClosing;
            _form.KeyDown += _form_KeyDown;
            _bufferedGraphics = BufferedGraphicsManager.Current.Allocate(_form.CreateGraphics(), _form.ClientRectangle);
        }

        /// <summary>
        /// Остановка вывода меню
        /// </summary>
        public void StopShowing()
        {
            _form.FormClosing -= _form_FormClosing;
            _form.KeyDown -= _form_KeyDown;
            ThreadView.Abort();
        }

        /// <summary>
        /// Закрытие формы.
        /// </summary>
        public void CloseGame()
        {
            _form.Close();
            Environment.Exit(0);
        }

        /// <summary>
        /// Стартует поток вывода
        /// </summary>
        public override void StartDrawing()
        {
            ThreadView = new Thread(ShowMenu);
            ThreadView.IsBackground = true;
            ThreadView.Start();
            if (Application.OpenForms.Count == 0)
            {
                Application.Run(_form);
            }
        }

        /// <summary>
        /// Обработчик события нажатия на клавишу
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _form_KeyDown(object sender, KeyEventArgs e)
        {
            KeyDown?.Invoke(e);
        }

        /// <summary>
        /// Обработчик события закрытия формы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _form_FormClosing(object sender, FormClosingEventArgs e)
        {
            ThreadView.Abort();
        }

        /// <summary>
        /// Метод потока вывода
        /// </summary>
        public override void ShowMenu()
        {
            var xStart = (_form.Width - ViewMenuItemWindows.WIDTH_ITEM_MENU) / 2 ;
            ViewMenuItemWindows viewMenuItem = new ViewMenuItemWindows(xStart, Y, _bufferedGraphics);
            ViewMenuGameNameWindows viewGameName = new ViewMenuGameNameWindows(X_POSITION_GAME_NAME, Y_POSITION_GAME_NAME, _bufferedGraphics);
            while (true)
            {
                lock (Locker)
                {
                    _bufferedGraphics.Graphics.Clear(Color.DarkBlue);
                    viewMenuItem.DrawAllItems(ModelMenu.ListStates, ModelMenu.ActualState);
                    viewGameName.Draw();
                    _bufferedGraphics.Render();
                }
                Thread.Sleep(MILLISECONDS_TIMEOUT);
            }
        }
    }
}