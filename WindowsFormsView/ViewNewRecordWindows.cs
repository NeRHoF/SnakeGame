using System;
using System.Drawing;
using System.Windows.Forms;
using View;

namespace WindowsFormsView
{
    /// <summary>
    /// Представление нового рекорда для WindowsForms
    /// </summary>
    public class ViewNewRecordWindows : ViewNewRecord
    {
        /// <summary>
        /// Делегат нажатия клавиши Enter
        /// </summary>
        /// <param name="parEnter">Имя введенное в поле</param>
        public delegate void DPressedEnter(string parEnter);
        /// <summary>
        /// Время обновления (мс)
        /// </summary>
        private const int MILLISECONDS_TIMEOUT = 10;
        /// <summary>
        /// Ширина textBox'а
        /// </summary>
        private const int TEXTBOX_WIDTH = 200;
        /// <summary>
        /// Высота textBox'а
        /// </summary>
        private const int TEXTBOX_HEIGHT = 30;
        /// <summary>
        /// Форма игры
        /// </summary>
        private readonly Form _form;
        /// <summary>
        /// Объект двойной буферизации
        /// </summary>
        private BufferedGraphics _bufferedGraphics;
        /// <summary>
        /// Поле для ввода имени игрока
        /// </summary>
        private TextBox _textBox;
        /// <summary>
        /// Событие нажатия кнопки enter
        /// </summary>
        public event DPressedEnter PressedEnter;

        /// <summary>
        /// Конструктор класса
        /// </summary>
        public ViewNewRecordWindows()
        {
            _form = Application.OpenForms[0];
            _textBox = new TextBox();
            _textBox.Size = new Size(TEXTBOX_WIDTH, TEXTBOX_HEIGHT);
            _textBox.Location = new Point((_form.Size.Width - TEXTBOX_WIDTH) / 2, (_form.Size.Height - TEXTBOX_HEIGHT) / 2);
            _textBox.Font = new Font("Arial", 15);
            _textBox.KeyDown += TextBox_KeyDown;
            _form.FormClosing += _form_FormClosing;
            var action = new Action(() =>
            {
                _form.Controls.Add(_textBox);
                _form.ActiveControl = _textBox;
            });
            if (_form.InvokeRequired)
            {
                _form.Invoke(action);
            }
            else
            {
                action();
            }
            
            _bufferedGraphics = BufferedGraphicsManager.Current.Allocate(_form.CreateGraphics(), _form.ClientRectangle);
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
        /// Обработчик события нажатия кнопки клавиатуры
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                PressedEnter?.Invoke(_textBox.Text);
            }
        }

        /// <summary>
        /// Метод отрисовки
        /// </summary>
        protected override void Draw()
        {
            Font font = new Font("Arial", 15);
            Brush brushFont = new SolidBrush(Color.DarkOrange);
            while (true)
            {
                lock (Locker)
                {
                    _bufferedGraphics.Graphics.Clear(Color.LightGray);
                    _bufferedGraphics.Graphics.DrawString(STRING_NEW_RECORD, font, brushFont, 200, 50);
                    _bufferedGraphics.Render();
                }
            }
        }
        
        /// <summary>
        /// Метод остановки рисования
        /// </summary>
        public override void StopDrawing()
        {
            ThreadView.Abort();
            _form.Controls.Clear();
        }
    }
}