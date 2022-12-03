using Model;
using View;

namespace Controller
{
    /// <summary>
    /// Базовый контроллер для инструкций
    /// </summary>
    public abstract class ControllerInstruction
    {
        /// <summary>
        /// Модель инструкции
        /// </summary>
        public ModelInstruction Model { get; set; }

        /// <summary>
        /// Представление инструкции
        /// </summary>
        public ViewInstruction View { get; set; }

        /// <summary>
        /// Запуск отслеживания нажатия клавиши
        /// </summary>
        public abstract void Start();
    }
}