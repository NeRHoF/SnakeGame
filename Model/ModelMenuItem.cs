namespace Model
{
    /// <summary>
    /// Модель пункта меню
    /// </summary>
    public class ModelMenuItem
    {
        /// <summary>
        /// Делегат действия пункта меню
        /// </summary>
        public delegate void dDoAction();

        /// <summary>
        /// Действие пункта меню
        /// </summary>
        public dDoAction Action;

        /// <summary>
        /// Текст пункта меню
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="parText">Текст пункта меню</param>
        /// <param name="parDoAction">Действие пункта меню</param>
        public ModelMenuItem(string parText, dDoAction parDoAction)
        {
            Text = parText;
            Action = parDoAction;
        }
    }
}