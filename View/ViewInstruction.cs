using System.Threading;
using Model;

namespace View
{
    /// <summary>
    /// Общее представление инструкции
    /// </summary>
    public abstract class ViewInstruction
    {
        /// <summary>
        /// Объект блокировщик потока вывода
        /// </summary>
        protected object Locker { get; set; }

        /// <summary>
        /// Поток вывода
        /// </summary>
        public Thread ThreadView { get; set; }

        /// <summary>
        /// Модель инструкций
        /// </summary>
        public ModelInstruction Model { get; set; }

        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="parModel">Модель инструкций</param>
        public ViewInstruction(ModelInstruction parModel)
        {
            Locker = new object();
            Model = parModel;
        }

        /// <summary>
        /// Запуск потока вывода
        /// </summary>
        public void StartDrawing()
        {
            ThreadView = new Thread(ShowInstruction);
            ThreadView.Start();
        }

        /// <summary>
        /// Остановка потока вывода
        /// </summary>
        public virtual void StopDrawing()
        {
            ThreadView.Abort();
        }

        /// <summary>
        /// Метод вывода инструкций
        /// </summary>
        public abstract void ShowInstruction();
    }
}