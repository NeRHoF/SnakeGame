using WindowsFormsView;
using Controller;
using Model;

namespace WindowsFormsController
{
    /// <summary>
    /// Контроллер таблицы рекордов для WindowsForms
    /// </summary>
    public class ControllerRecordsWindows : ControllerRecords
    {
        /// <summary>
        /// Событие, вызывающееся при закрытии таблицы рекордов
        /// </summary>
        public event ModelGame.dEventHandler Close;

        /// <summary>
        /// Старт таблицы рекордов
        /// </summary>
        public override void Start()
        {
            Model = new ModelRecords();
            View = new ViewRecordsWindows(Model);
            ((ViewRecordsWindows)View).KeyDown += ControllerRecordsWindows_KeyDown;
        }

        /// <summary>
        /// Обработчик события нажатия кнопки клавиатуры
        /// </summary>
        /// <param name="parE"></param>
        private void ControllerRecordsWindows_KeyDown(System.Windows.Forms.KeyEventArgs parE)
        {
            switch (parE.KeyData)
            {
                case System.Windows.Forms.Keys.Enter:
                    View.StopView();
                    Close?.Invoke();
                    break;
            }
        }
    }
}