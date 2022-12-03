using System.Collections.Generic;

namespace Model
{
    /// <summary>
    /// Модель главного меню
    /// </summary>
    public class ModelMenu
    {
        /// <summary>
        /// Номер выбранного пункта меню
        /// </summary>
        private int _actualState;

        /// <summary>
        /// Список пунктов меню
        /// </summary>
        public List<ModelMenuItem> ListStates { get; set; }

        /// <summary>
        /// Номер выбранного пункта меню
        /// </summary>
        public int ActualState
        {
            get => _actualState;
            set
            {
                if (value >= 0 && value < ListStates.Count)
                {
                    _actualState = value;
                }
                else
                {
                    if (value < 0)
                    {
                        _actualState = ListStates.Count - 1;
                    }
                    else
                    {
                        _actualState = 0;
                    }
                }
            }
        }

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public ModelMenu()
        {
            ListStates = new List<ModelMenuItem>();
        }

        /// <summary>
        /// Выполнить действие текущего пункта меню
        /// </summary>
        public void DoActualAction()
        {
            ListStates[ActualState].Action();
        }
    }
}