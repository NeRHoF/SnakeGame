using System.Drawing;
using Model.Objects;

namespace WindowsFormsView.Objects
{
    /// <summary>
    /// Представление змеи для WindowsForms
    /// </summary>
    public class ViewSnakeWindows : ViewGameObjectWindows
    {
        /// <summary>
        /// Картинка головы вниз
        /// </summary>
        private Bitmap _headDown = new Bitmap("../../../WindowsFormsView/Properties/img/HeadDown.png");
        /// <summary>
        /// Картинка головы влево
        /// </summary>
        private Bitmap _headLeft = new Bitmap("../../../WindowsFormsView/Properties/img/HeadLeft.png");
        /// <summary>
        /// Картинка головы вправо
        /// </summary>
        private Bitmap _headRight = new Bitmap("../../../WindowsFormsView/Properties/img/HeadRight.png");
        /// <summary>
        /// Картинка головы вверх
        /// </summary>
        private Bitmap _headUp = new Bitmap("../../../WindowsFormsView/Properties/img/HeadUp.png");
        
        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="parBufferedGraphics">Двойная буфферизация</param>
        /// <param name="parOffsetX">Координата X</param>
        /// <param name="parOffsetY">Координата Y</param>
        public ViewSnakeWindows(BufferedGraphics parBufferedGraphics, int parOffsetX, int parOffsetY) : base(parBufferedGraphics, parOffsetX, parOffsetY)
        {
        }

        /// <summary>
        /// Метод вывода части змеи на консоль
        /// </summary>
        /// <param name="parGameObject">чассть змеи</param>
        public override void Draw(GameObject parGameObject)
        {
            int x = parGameObject.X * ViewGameWindows.SIZE_GAME_OBJECT + OffsetX;
            int y = parGameObject.Y * ViewGameWindows.SIZE_GAME_OBJECT + OffsetY;
            if (parGameObject is SnakeHead head)
            {
                switch (head.Direction)
                {
                    case Direction.Down:
                        BufferedGraphics.Graphics.DrawImage(_headDown, new Rectangle(x, y, ViewGameWindows.SIZE_GAME_OBJECT, ViewGameWindows.SIZE_GAME_OBJECT));
                        break;
                    case Direction.Left:
                        BufferedGraphics.Graphics.DrawImage(_headLeft, new Rectangle(x, y, ViewGameWindows.SIZE_GAME_OBJECT, ViewGameWindows.SIZE_GAME_OBJECT));
                        break;
                    case Direction.Right:
                        BufferedGraphics.Graphics.DrawImage(_headRight, new Rectangle(x, y, ViewGameWindows.SIZE_GAME_OBJECT, ViewGameWindows.SIZE_GAME_OBJECT));
                        break;
                    case Direction.Up:
                        BufferedGraphics.Graphics.DrawImage(_headUp, new Rectangle(x, y, ViewGameWindows.SIZE_GAME_OBJECT, ViewGameWindows.SIZE_GAME_OBJECT));
                        break;
                }
            }
            else if (parGameObject is SnakeTail)
            {
                Pen = new Pen(Color.FromArgb(75, 113, 74), 2);
                Brush = new SolidBrush(Color.FromArgb(75, 113, 74));
                
                BufferedGraphics.Graphics.FillRectangle(Brush, new Rectangle(x, y, ViewGameWindows.SIZE_GAME_OBJECT, ViewGameWindows.SIZE_GAME_OBJECT));
                BufferedGraphics.Graphics.DrawRectangle(Pen, new Rectangle(x, y, ViewGameWindows.SIZE_GAME_OBJECT, ViewGameWindows.SIZE_GAME_OBJECT));
            }
        }
    }
}