using System.Windows.Forms;
using WindowsFormsView;
using Controller;
using Model;

namespace WindowsFormsController
{
    /// <summary>
    /// Контроллер инструкций для WindowsForms
    /// </summary>
    public class ControllerInstructionWindows : ControllerInstruction
    {
        /// <summary>
        /// Событие, вызывающееся при закрытии инструкции
        /// </summary>
        public event ModelGame.dEventHandler Close;

        /// <summary>
        /// Старт формы инструкции
        /// </summary>
        public override void Start()
        {
            Model = new ModelInstruction();
            View = new ViewInstructionWindows(Model);
            ((ViewInstructionWindows)View).KeyDown += ControllerInstructionWindow_KeyDown;
        }

        /// <summary>
        /// Обработчик события нажатия кнопки клавиатуры
        /// </summary>
        /// <param name="parE"></param>
        private void ControllerInstructionWindow_KeyDown(KeyEventArgs parE)
        {
            switch (parE.KeyData)
            {
                case Keys.Enter:
                    ((ViewInstructionWindows)View).StopDrawing();
                    Close?.Invoke();
                    break;
            }
        }
    }
}