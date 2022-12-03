using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using Model;
using View;

namespace WindowsFormsView
{
    /// <summary>
    /// Представление таблицы рекордов для WindowsForms
    /// </summary>
    public class ViewRecordsWindows : ViewRecords
    {
        /// <summary>
        /// Время обновления экрана (мс)
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
        /// Событие нажатия клавиши
        /// </summary>
        public event DKeyDown KeyDown;

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="parModelRecords">Модель игры</param>
        public ViewRecordsWindows(ModelRecords parModelRecords) : base(parModelRecords)
        {
            if (Application.OpenForms.Count != 0)
            {
                _form = Application.OpenForms[0];
            }

            Model = parModelRecords;
            var size = new Size(ViewGameWindows.WIDTH_WINDOW, ViewGameWindows.HEIGHT_WINDOW);
            _form.MaximumSize = size;
            _form.Size = size;
            _form.KeyDown += _form_KeyDown;
            _form.FormClosing += _form_FormClosing;
            _bufferedGraphics = BufferedGraphicsManager.Current.Allocate(_form.CreateGraphics(), _form.ClientRectangle);
            ThreadView = new Thread(ShowRecords);
            ThreadView.Start();
        }

        /// <summary>
        /// Обработчик события закрытия формы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _form_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopView();
        }

        /// <summary>
        /// Остановка вывода таблицы рекордов
        /// </summary>
        public override void StopView()
        {
            _form.KeyDown -= _form_KeyDown;
            ThreadView.Abort();
        }

        /// <summary>
        /// Обработчик события нажатия клавиши клавиатуры
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _form_KeyDown(object sender, KeyEventArgs e)
        {
            KeyDown?.Invoke(e);
        }

        /// <summary>
        /// Вывод таблицы рекордов
        /// </summary>
        public override void ShowRecords()
        {
            ViewRecordLineWindows viewHighscore = new ViewRecordLineWindows(50, 50, _bufferedGraphics);
            while (true)
            {
                lock (Locker)
                {
                    _bufferedGraphics.Graphics.Clear(Color.Coral);
                    viewHighscore.DrawAllItems(Model.Records);
                    _bufferedGraphics.Render();
                }
                Thread.Sleep(MILLISECONDS_TIMEOUT);
            }
        }
    }
}