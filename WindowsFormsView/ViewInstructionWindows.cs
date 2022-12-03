using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using WindowsFormsView.Objects;
using Model;
using View;

namespace WindowsFormsView
{
    /// <summary>
    /// Представление инструкций для WindowsForms
    /// </summary>
    public class ViewInstructionWindows : ViewInstruction
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
        /// Конструктор формы
        /// </summary>
        /// <param name="parModel"></param>
        public ViewInstructionWindows(ModelInstruction parModel) : base(parModel)
        {
            if (Application.OpenForms.Count != 0)
            {
                _form = Application.OpenForms[0];
            }
            var size = new Size(ViewGameWindows.WIDTH_WINDOW, ViewGameWindows.HEIGHT_WINDOW);
            _form.MaximumSize = size;
            _form.Size = size;
            _form.KeyDown += _form_KeyDown;
            _form.FormClosing += _form_FormClosing;
            _bufferedGraphics = BufferedGraphicsManager.Current.Allocate(_form.CreateGraphics(), _form.ClientRectangle);
            StartDrawing();
        }


        /// <summary>
        /// Остановка вывода инструкции
        /// </summary>
        public override void StopDrawing()
        {
            ThreadView.Abort();
            _form.KeyDown -= _form_KeyDown;
        }

        /// <summary>
        /// Метод обработки события закрытия формы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _form_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopDrawing();
        }

        /// <summary>
        /// Метод обработки события нажатия клавиши
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _form_KeyDown(object sender, KeyEventArgs e)
        {
            KeyDown?.Invoke(e);
        }

        /// <summary>
        /// Метод вывода инструкции на форму
        /// </summary>
        public override void ShowInstruction()
        {
            ViewStringWindows viewString = new ViewStringWindows(50, 50, _bufferedGraphics);
            while (true)
            {
                lock (Locker)
                {
                    _bufferedGraphics.Graphics.Clear(Color.Coral);
                    viewString.Draw(Model.TextInstruction);
                    _bufferedGraphics.Render();
                }
                Thread.Sleep(MILLISECONDS_TIMEOUT);
            }
        }
    }
}