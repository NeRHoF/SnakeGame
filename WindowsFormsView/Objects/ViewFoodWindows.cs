using System.Drawing;
using Model.Objects;
using View.Objects;

namespace WindowsFormsView.Objects
{
    /// <summary>
    /// Представление еды для WindowsForms
    /// </summary>
    public class ViewFoodWindows : ViewGameObjectWindows
    {
        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="parBufferedGraphics">Двойная буфферизация</param>
        /// <param name="parOffsetX">Координата X</param>
        /// <param name="parOffsetY">Координата Y</param>
        public ViewFoodWindows(BufferedGraphics parBufferedGraphics, int parOffsetX, int parOffsetY) : base(parBufferedGraphics, parOffsetX, parOffsetY)
        {
        }

        /// <summary>
        /// Вывод 
        /// </summary>
        /// <param name="parGameObject"></param>
        public override void Draw(GameObject parGameObject)
        {
            int x = parGameObject.X * ViewGameWindows.SIZE_GAME_OBJECT + OffsetX;
            int y = parGameObject.Y * ViewGameWindows.SIZE_GAME_OBJECT + OffsetY;
            
            BufferedGraphics.Graphics.DrawImage(new Bitmap("../../../WindowsFormsView/Properties/img/Eat.png"), new Rectangle(x, y, ViewGameWindows.SIZE_GAME_OBJECT, ViewGameWindows.SIZE_GAME_OBJECT));
        }
    }
}