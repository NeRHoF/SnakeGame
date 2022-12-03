using System.Threading;
using Model;
using View;

namespace ConsoleView
{
    public class ViewRecordsConsole : ViewRecords
    {
        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="parModel">Модель таблицы рекордов</param>
        public ViewRecordsConsole(ModelRecords parModel) : base(parModel)
        {
            Model = parModel;
            ThreadView = new Thread(ShowRecords);
            ThreadView.Start();
        }

        /// <summary>
        /// Остановка вывода в консоль
        /// </summary>
        public override void StopView()
        {
            ThreadView.Abort();
        }

        /// <summary>
        /// Вывод таблицы рекордов в консоль
        /// </summary>
        public override void ShowRecords()
        {
            ViewRecordLineConsole view = new ViewRecordLineConsole(30, 1);
            while (true)
            {
                FastOutput.Clear();
                view.DrawAllItems(Model.Records);
                FastOutput.PrintOnConsole();
            }
        }
    }
}