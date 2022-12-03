namespace Model
{
    /// <summary>
    /// Модель инструкций
    /// </summary>
    public class ModelInstruction
    {
        /// <summary>
        /// Текст инструкции
        /// </summary>
        public string TextInstruction { get; }

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public ModelInstruction()
        {
            TextInstruction = Resources.Instruction;
        }
    }
}