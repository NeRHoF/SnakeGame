using System;
using ConsoleView;
using Controller;
using Model;

namespace ConsoleController
{
    /// <summary>
    /// Контроллер меню для консоли
    /// </summary>
    public class ControllerMenuConsole : ControllerMenu
    {
        /// <summary>
        /// Сущность контроллера
        /// </summary>
        private static ControllerMenuConsole _instance;

        /// <summary>
        /// Текст пункта рекордов
        /// </summary>
        private const string RECORDS = "Таблица рекордов";

        /// <summary>
        /// Текст пункта игры
        /// </summary>
        private const string PLAY = "Игрыть";

        /// <summary>
        /// Текст пункта инструкции
        /// </summary>
        private const string INSTRUCTION = "Инструкция";

        /// <summary>
        /// Текст пункта выхода
        /// </summary>
        private const string EXIT = "Выход";
        
        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        private ControllerMenuConsole()
        {
            Model = new ModelMenu();
            Model.ListStates.Add(new ModelMenuItem(PLAY, () =>
            {
                ControllerGameConsole controller = new ControllerGameConsole();
                controller.GameWin += new ModelGame.dEventHandler(() =>
                {
                    ControllerNewRecordConsole controllerNewRecord = new ControllerNewRecordConsole(controller.Model.Scores);
                    controllerNewRecord.Close += Start;
                    controllerNewRecord.Start();
                });
                controller.GameClose += Start;
                controller.Start();
            }));
            Model.ListStates.Add(new ModelMenuItem(RECORDS, () =>
            {
                ControllerRecordsConsole highscoreConsole = new ControllerRecordsConsole();
                highscoreConsole.Close += Start;
                highscoreConsole.Start();
            }));
            
            Model.ListStates.Add(new ModelMenuItem(INSTRUCTION, () =>
            {
                ControllerInstructionConsole instructionConsole = new ControllerInstructionConsole();
                instructionConsole.Close += Start;
                instructionConsole.Start();
            }));
            
            Model.ListStates.Add(new ModelMenuItem(EXIT, () =>
            {
                Environment.Exit(0);
            }));

            View = new ViewMenuConsole() {ModelMenu = Model};
        }

        /// <summary>
        /// Получение сущности контроллера
        /// </summary>
        /// <returns>Сущность контроллера</returns>
        public static ControllerMenuConsole GetInstance()
        {
            if (_instance == null)
            {
                _instance = new ControllerMenuConsole();
            }

            return _instance;
        }

        /// <summary>
        /// Запуск меню
        /// </summary>
        public override void Start()
        {
            View.StartDrawing();
            while (true)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                bool isEnter = false;
                switch (keyInfo.Key)
                {
                    case ConsoleKey.Enter:
                        isEnter = true;
                        ((ViewMenuConsole)View).StopShowing();
                        Model.DoActualAction();
                        break;
                    case ConsoleKey.UpArrow:
                        Model.ActualState--;
                        break;
                    case ConsoleKey.DownArrow:
                        Model.ActualState++;
                        break;
                    default:
                        break;
                }

                if (isEnter)
                {
                    break;
                }
            }
        }
    }
}