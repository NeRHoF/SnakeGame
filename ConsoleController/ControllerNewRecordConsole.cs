using System;
using ConsoleView;
using Controller;
using Model;

namespace ConsoleController
{
    /// <summary>
    /// Контроллер нового рекорда для консоли
    /// </summary>
    public class ControllerNewRecordConsole : ControllerNewRecord
    {

        /// <summary>
        /// Событие при закрытии нового рекорда
        /// </summary>
        public event ModelGame.dEventHandler Close;
        
        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="parScore">Заработанные очки</param>
        public ControllerNewRecordConsole(int parScore) : base(parScore)
        {
            IsNewRecord = ModelRecords.Records.Count < 10;
            if (!IsNewRecord)
            {
                foreach (var elRecord in ModelRecords.Records)
                {
                    if (elRecord.Score >= Model.Score)
                    {
                        IsNewRecord = true;
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Старт контроллера
        /// </summary>
        public override void Start()
        {
            View = new ViewNewRecordConsole();
            View.StartDrawing();
            if (IsNewRecord)
            {
                string name = Console.ReadLine();
                Model.Name = name;
                ModelRecords.Records.Add(Model);
                ModelRecords.WriteRecordsToFile();
            }
            Close?.Invoke();
        }
    }
}