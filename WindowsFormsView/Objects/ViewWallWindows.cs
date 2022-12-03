using System.Drawing;
using Model.Objects;

namespace WindowsFormsView.Objects
{
    /// <summary>
    /// Представление стены для WindowsForms
    /// </summary>
    public class ViewWallWindows : ViewGameObjectWindows
    {
        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="parBufferedGraphics"></param>
        /// <param name="parOffsetX"></param>
        /// <param name="parOffsetY"></param>
        public ViewWallWindows(BufferedGraphics parBufferedGraphics, int parOffsetX, int parOffsetY) : base(parBufferedGraphics, parOffsetX, parOffsetY)
        {
            Pen = new Pen(Color.FromArgb(74, 117, 45), 2);
            Brush = new SolidBrush(Color.FromArgb(74, 117, 45));
        }

        /// <summary>
        /// Отрисовка стены на форму
        /// </summary>
        /// <param name="parGameObject">стена</param>
        public override void Draw(GameObject parGameObject)
        {
            int x = parGameObject.X * ViewGameWindows.SIZE_GAME_OBJECT + OffsetX;
            int y = parGameObject.Y * ViewGameWindows.SIZE_GAME_OBJECT + OffsetY;
            
            BufferedGraphics.Graphics.FillRectangle(Brush, new Rectangle(x + 4, y + 4, ViewGameWindows.SIZE_GAME_OBJECT, ViewGameWindows.SIZE_GAME_OBJECT));
            BufferedGraphics.Graphics.DrawRectangle(Pen, new Rectangle(x + 4, y + 4, ViewGameWindows.SIZE_GAME_OBJECT, ViewGameWindows.SIZE_GAME_OBJECT));
        }
    }
}