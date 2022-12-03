namespace Model
{
    /// <summary>
    /// Модель строки таблицы рекордов
    /// </summary>
    public class ModelRecordLine
    {
        /// <summary>
        /// Имя игрока
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Очки
        /// </summary>
        public int Score { get; set; }

        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="parName">Имя игрока</param>
        /// <param name="parScore">Очки</param>
        public ModelRecordLine(string parName, int parScore)
        {
            Name = parName;
            Score = parScore;
        }

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public ModelRecordLine()
        {
        }
    }
}