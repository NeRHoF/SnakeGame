using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using WindowsFormsView;
using WindowsFormsView.Objects;
using WindowsFormsView.Objects.Factories;
using Model;
using View;
using View.Objects;

namespace WindowsFormsView
{
    /// <summary>
    /// Представление игры для WindowsForms
    /// </summary>
    public class ViewGameWindows : ViewGame
    {
        
        /// <summary>
        /// Время обновления(мс)
        /// </summary>
        private const int MILLISECONDS_TIMEOUT = 10;
        /// <summary>
        /// Форма вывода
        /// </summary>
        private Form _form;
        /// <summary>
        /// Объект двойной буферизации
        /// </summary>
        private BufferedGraphics _bufferedGraphics;
        /// <summary>
        /// Ширина окна
        /// </summary>
        public const int WIDTH_WINDOW = 890;
        /// <summary>
        /// Высота окна
        /// </summary>
        public const int HEIGHT_WINDOW = 550;
        /// <summary>
        /// Размер игрового объекта
        /// </summary>
        public const int SIZE_GAME_OBJECT = 28;
        
        /// <summary>
        /// Событие нажатия клавиши
        /// </summary>
        public event DKeyDown KeyDown;
        
        /// <summary>
        /// Отображение игры на форму
        /// </summary>
        protected override void ShowGame()
        {
            int offsetX = 0;
            int offsetY = 0;

            ViewGameObjectWindowsFactory factory = new ViewGameObjectWindowsFactory();

            ViewGameObjectWindows viewWallWindows = (ViewGameObjectWindows)factory.CreateView(ViewType.Wall, offsetX, offsetY, _bufferedGraphics);
            ViewGameObjectWindows viewFoodWindows = (ViewGameObjectWindows)factory.CreateView(ViewType.Food, offsetX, offsetY, _bufferedGraphics);
            ViewGameObjectWindows viewSnakeWindows = (ViewGameObjectWindows)factory.CreateView(ViewType.Snake, offsetX, offsetY, _bufferedGraphics);

            ViewScoresWindows viewScoresWindows = new ViewScoresWindows(_bufferedGraphics, offsetX, offsetY);

            while (true)
            {
                lock (Locker)
                {
                    _bufferedGraphics.Graphics.Clear(Color.White);
                    viewWallWindows.DrawAllObjects(ModelGame.Walls);
                    viewSnakeWindows.DrawAllObjects(ModelGame.Snake.SnakeObjects);
                    viewFoodWindows.Draw(ModelGame.Food);
                    
                    viewScoresWindows.Draw(ModelGame.Scores);
                    _bufferedGraphics.Render();
                    Thread.Sleep(MILLISECONDS_TIMEOUT);
                }
            }
        }

        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="parModelGame">Модель игры</param>
        public ViewGameWindows(ModelGame parModelGame) : base(parModelGame)
        {
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
            var size = new Size(WIDTH_WINDOW, HEIGHT_WINDOW);
            _form.MaximumSize = size;
            _form.Size = size;
            _form.FormClosing += _form_FormClosing;
            _form.KeyDown += _form_KeyDown;
            _bufferedGraphics = BufferedGraphicsManager.Current.Allocate(_form.CreateGraphics(), _form.ClientRectangle);
            ModelGame.ReadyToPlay += _modelGame_ReadyToPlay;
            ModelGame.GameOver += _modelGame_GameOver;
        }
        
        /// <summary>
        /// Остановка игры
        /// </summary>
        public override void StopGame()
        {
            base.StopGame();
            _form.FormClosing -= _form_FormClosing;
            _form.KeyDown -= _form_KeyDown;
        }

        /// <summary>
        /// Обработчик события победы
        /// </summary>
        private void _modelGame_GameOver()
        {
            StopGame();
        }
        
        /// <summary>
        /// Обработчик события закрытия формы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _form_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopGame();
        }

        /// <summary>
        /// Обработчик события готовности модели к выводу
        /// </summary>
        private void _modelGame_ReadyToPlay()
        {
            ThreadView = new Thread(ShowGame);
            ThreadView.Start();
            if (Application.OpenForms.Count == 0)
            {
                Application.Run(_form);
            }
        }
        
        /// <summary>
        /// Обработчик события нажатия на кнопку клавиатуры
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _form_KeyDown(object sender, KeyEventArgs e)
        {
            KeyDown?.Invoke(e);
        }
    }
}