using System;
using ConsoleView;
using Controller;
using Model;

namespace ConsoleController
{
    /// <summary>
    /// Констроллер инструкций для консоли
    /// </summary>
    public class ControllerInstructionConsole : ControllerInstruction
    {
        /// <summary>
        /// Событие закрытия инструкций
        /// </summary>
        public event ModelGame.dEventHandler Close;

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public ControllerInstructionConsole()
        {
            Model = new ModelInstruction();
            View = new ViewInstructionConsole(Model);
        }

        /// <summary>
        /// Метод запуска обработки нажатий клавиш
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
                        View.StopDrawing();
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