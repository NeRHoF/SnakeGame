using WindowsFormsView;
using Controller;
using Model;

namespace WindowsFormsController
{
    /// <summary>
    /// Контроллер нового рекорда для WindowsForms
    /// </summary>
    public class ControllerNewRecordWindows : ControllerNewRecord
    {
        /// <summary>
        /// Событие, вызывающееся при закрытии ввода нового рекорда
        /// </summary>
        public event ModelGame.dEventHandler Close;

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="parScore"></param>
        public ControllerNewRecordWindows(int parScore) : base(parScore)
        {
            IsNewRecord = ModelRecords.Records.Count < 10;
            if (!IsNewRecord)
            {
                foreach (var item in ModelRecords.Records)
                {
                    if (item.Score >= Model.Score)
                    {
                        IsNewRecord = true;
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Старт вывода нового рекорда
        /// </summary>
        public override void Start()
        {
            if (IsNewRecord)
            {
                View = new ViewNewRecordWindows();
                ((ViewNewRecordWindows)View).PressedEnter += ControllerNewRecordWindows_PressedEnter;
                View.StartDrawing();
            }
            else
            {
                Close?.Invoke();
            }
        }

        /// <summary>
        /// Нажата кнопка enter.
        /// </summary>
        /// <param name="parEnter"></param>
        private void ControllerNewRecordWindows_PressedEnter(string parEnter)
        {
            Model.Name = parEnter;
            View.StopDrawing();
            ModelRecords.Records.Add(Model);
            ModelRecords.WriteRecordsToFile();
            Close?.Invoke();
        }
    }
}