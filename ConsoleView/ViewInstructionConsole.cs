using System;
using Model;
using View;

namespace ConsoleView
{
    /// <summary>
    /// Представление инструкций к игре для консоли
    /// </summary>
    public class ViewInstructionConsole : ViewInstruction
    {
        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="parModel">Модель инструкций</param>
        public ViewInstructionConsole(ModelInstruction parModel) : base(parModel)
        {
            StartDrawing();
        }

        /// <summary>
        /// вывод инструкции на консоль
        /// </summary>
        public override void ShowInstruction()
        {
            while (true)
            {
                FastOutput.Clear();
                FastOutput.Write(Model.TextInstruction, 1, 1, ConsoleColor.Yellow);
                FastOutput.PrintOnConsole();
            }
        }

        /// <summary>
        /// Остановка вывода на консоль
        /// </summary>
        public override void StopDrawing()
        {
            ThreadView.Abort();
        }
    }
}