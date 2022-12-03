using System;
using ConsoleView;
using Controller;
using Model;

namespace ConsoleController
{
    /// <summary>
    /// Класс контроллер таблицы рекордов для консоли
    /// </summary>
    public class ControllerRecordsConsole : ControllerRecords
    {
        /// <summary>
        /// Событие закрытия таблицы рекордов
        /// </summary>
        public event ModelGame.dEventHandler Close;
        
        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public ControllerRecordsConsole()
        {
            Model = new Model.ModelRecords();
            View = new ViewRecordsConsole(Model);
        }
        
        /// <summary>
        /// Старт отслеживания нажатия клавиши
        /// </summary>
        public override void Start()
        {
            while (true)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                bool isEnter = false;
                switch (keyInfo.Key)
                {
                    case ConsoleKey.Enter:
                        View.StopView();
                        isEnter = true;
                        Close?.Invoke();
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