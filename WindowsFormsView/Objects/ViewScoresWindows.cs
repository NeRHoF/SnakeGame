using System;
using System.Drawing;
using View.Objects;

namespace WindowsFormsView.Objects
{
    /// <summary>
    /// Представление количества очков для WindowsForms
    /// </summary>
    public class ViewScoresWindows : ViewScores
    {

        /// <summary>
        /// Кисть для рисования
        /// </summary>
        public Brush Brush { get; set; }

        /// <summary>
        /// Перо для рисования
        /// </summary>
        public Pen Pen { get; set; }

        /// <summary>
        /// Двойная буфферизация
        /// </summary>
        public BufferedGraphics BufferedGraphics { get; set; }

        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="parOffsetX">Координата X</param>
        /// <param name="parOffsetY">Координата Y</param>
        /// /// <param name="parBufferedGraphics">Двойная буфферизация</param>
        public ViewScoresWindows(BufferedGraphics parBufferedGraphics, int parOffsetX, int parOffsetY) : base(parOffsetX, parOffsetY)
        {
            BufferedGraphics = parBufferedGraphics;
            Pen = new Pen(Color.DarkGreen, 2);
            Brush = new SolidBrush(Color.DarkGreen);
        }

        /// <summary>
        /// Отрисовка количества очков на WindowsForms
        /// </summary>
        /// <param name="parScores"></param>
        public override void Draw(int parScores)
        {
            int x = OffsetX;
            int y = 17 * ViewGameWindows.SIZE_GAME_OBJECT + OffsetY;
            BufferedGraphics.Graphics.DrawString("Очки: " + parScores, new Font(FontFamily.GenericSansSerif, 12), Brush, x, y);
        }
    }
}