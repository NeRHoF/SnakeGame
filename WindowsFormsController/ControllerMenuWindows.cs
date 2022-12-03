using WindowsFormsView;
using Controller;
using Model;

namespace WindowsFormsController
{
    /// <summary>
    /// Контроллер меню для WindowsForms
    /// </summary>
    public class ControllerMenuWindows : ControllerMenu
    {
        /// <summary>
        /// Instance класса
        /// </summary>
        private static ControllerMenuWindows _instance;
        /// <summary>
        /// Строка Таблицы рекордов
        /// </summary>
        private const string RECORDS = "Таблица рекордов";
        /// <summary>
        /// Строка Играть
        /// </summary>
        private const string PLAY = "Играть";
        /// <summary>
        /// Строка Инструкции
        /// </summary>
        private const string INSTRUCTIONS = "Инструкции";
        /// <summary>
        /// Строка Выход
        /// </summary>
        private const string EXIT = "Выход";

        /// <summary>
        /// Конструктор класса
        /// </summary>
        private ControllerMenuWindows()
        {
        }

        /// <summary>
        /// Старт контроллера
        /// </summary>
        public override void Start()
        {
            Model = new ModelMenu();
            Model.ListStates.Add(new ModelMenuItem(PLAY, new ModelMenuItem.dDoAction(() =>
            {
                ControllerGameWindows controllerGame = new ControllerGameWindows();
                controllerGame.GameWin += new ModelGame.dEventHandler(()=> {
                    ControllerNewRecordWindows controllerNewRecord = new ControllerNewRecordWindows(controllerGame.Model.Scores);
                    controllerNewRecord.Close += Start;
                    controllerNewRecord.Start();
                });
                controllerGame.GameClose += Start;
                controllerGame.Start();
            })));
            Model.ListStates.Add(new ModelMenuItem(RECORDS, new ModelMenuItem.dDoAction(() =>
            {
                ControllerRecordsWindows controllerRecords = new ControllerRecordsWindows();
                controllerRecords.Close += Start;
                controllerRecords.Start();
            })));
            Model.ListStates.Add(new ModelMenuItem(INSTRUCTIONS, new ModelMenuItem.dDoAction(() =>
            {
                ControllerInstructionWindows controllerInstruction = new ControllerInstructionWindows();
                controllerInstruction.Close += Start;
                controllerInstruction.Start();
            })));
            Model.ListStates.Add(new ModelMenuItem(EXIT, CloseGame));
            View = new ViewMenuWindows(Model);
            ((ViewMenuWindows)View).KeyDown += ControllerMenuWindows_KeyDown;
            View.ModelMenu = Model;
            ((ViewMenuWindows)View).StartDrawing();
        }

        /// <summary>
        /// Обработчик события нажатия кнопки клавиатуры
        /// </summary>
        /// <param name="parE"></param>
        private void ControllerMenuWindows_KeyDown(System.Windows.Forms.KeyEventArgs parE)
        {
            switch (parE.KeyCode)
            {
                case System.Windows.Forms.Keys.Up:
                    Model.ActualState--;
                    break;
                case System.Windows.Forms.Keys.Down:
                    Model.ActualState++;
                    break;
                case System.Windows.Forms.Keys.Enter:
                    ((ViewMenuWindows)View).KeyDown -= (DKeyDown)ControllerMenuWindows_KeyDown;
                    ((ViewMenuWindows)View).StopShowing();
                    Model.DoActualAction();
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Закрытие главного меню
        /// </summary>
        public void CloseGame()
        {
            ((ViewMenuWindows)View).CloseGame();
        }

        /// <summary>
        /// Создание и возврат Instance
        /// </summary>
        /// <returns>Instance</returns>
        public static ControllerMenuWindows GetInstance()
        {
            if (_instance==null)
            {
                _instance = new ControllerMenuWindows();
            }
            return _instance;
        }
    }
}