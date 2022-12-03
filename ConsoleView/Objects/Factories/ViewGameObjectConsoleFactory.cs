using View.Objects;

namespace ConsoleView.Objects.Factories
{
    /// <summary>
    /// Фабрика представлений для консоли
    /// </summary>
    public class ViewGameObjectConsoleFactory
    {
        /// <summary>
        /// Создание представления для игрового объекта
        /// </summary>
        /// <param name="parViewType">Тип представления</param>
        /// <param name="parX">Координата X</param>
        /// <param name="parY">Координата Y</param>
        /// <returns></returns>
        public ViewGameObject CreateView(ViewType parViewType, int parX, int parY)
        {
            switch (parViewType)
            {
                case ViewType.Food:
                    return new ViewFoodConsole(parX, parY);
                case ViewType.Snake:
                    return new ViewSnakeConsole(parX, parY);
                case ViewType.Wall:
                    return new ViewWallConsole(parX, parY);
                default: return null;
            }
        }
    }
}