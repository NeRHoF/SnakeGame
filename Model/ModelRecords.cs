using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Model
{
    /// <summary>
    /// Модель рекордов
    /// </summary>
    public class ModelRecords
    {
        /// <summary>
        /// Путь к файлу рекордов
        /// </summary>
        private const string FILE_RECORD_PATH = "records.txt";

        /// <summary>
        /// Список рекордов
        /// </summary>
        public List<ModelRecordLine> Records { get; set; }

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public ModelRecords()
        {
            Records = new List<ModelRecordLine>();
            if (File.Exists(FILE_RECORD_PATH))
            {
                string[] recordLines = File.ReadAllLines(FILE_RECORD_PATH);
                foreach (var elLine in recordLines)
                {
                    string[] recordParams = elLine.Split(' ');
                    if (recordParams.Length == 2)
                    {
                        ModelRecordLine highscoreLine = new ModelRecordLine(
                            recordParams[0],
                            Int32.Parse(recordParams[1])
                        );
                        Records.Add(highscoreLine);
                    }
                }
            }
            else
            {
                File.Create(FILE_RECORD_PATH).Close();
            }
        }

        /// <summary>
        /// Запись списка 10 последних рекордов в файл
        /// </summary>
        public void WriteRecordsToFile()
        {
            var file = File.OpenWrite(FILE_RECORD_PATH);
            Records.Sort((a, b) => b.Score - a.Score);
            for (int i = 0; i < Records.Count && i < 10; i++)
            {
                var line = $"{Records[i].Name} {Records[i].Score.ToString()}\r\n";
                var bytes = Encoding.UTF8.GetBytes(line);
                file.Write(bytes, 0, bytes.Length);
            }
            file.Flush();
            file.Close();
        }
    }
}