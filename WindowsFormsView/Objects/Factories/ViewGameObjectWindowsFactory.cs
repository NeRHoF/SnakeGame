using System.Drawing;
using View.Objects;

namespace WindowsFormsView.Objects.Factories
{
    /// <summary>
    /// Фабрика представлений для WindowsForms
    /// </summary>
    public class ViewGameObjectWindowsFactory
    {
        /// <summary>
        /// Создание представления для WindowsForms
        /// </summary>
        /// <param name="parViewType"></param>
        /// <param name="parOffsetX"></param>
        /// <param name="parOffsetY"></param>
        /// <param name="parBufferedGraphics"></param>
        /// <returns></returns>
        public ViewGameObject CreateView(ViewType parViewType, int parOffsetX, int parOffsetY, BufferedGraphics parBufferedGraphics)
        {
            switch (parViewType)
            {
                case ViewType.Food:
                    return new ViewFoodWindows(parBufferedGraphics, parOffsetX, parOffsetY);
                case ViewType.Snake:
                    return new ViewSnakeWindows(parBufferedGraphics, parOffsetX, parOffsetY);
                case ViewType.Wall:
                    return new ViewWallWindows(parBufferedGraphics, parOffsetX, parOffsetY);
                default: return null;
            }
        }
    }
}