using System.Drawing;
using View.Objects;

namespace WindowsFormsView.Objects
{
    /// <summary>
    /// Представление строки на экране для WindowsForms
    /// </summary>
    public class ViewStringWindows : ViewObject
    {
        /// <summary>
        /// Размер шрифта
        /// </summary>
        private const int FONT_SIZE = 20;
        /// <summary>
        /// Кисть вывода
        /// </summary>
        private readonly Brush _brush;
        /// <summary>
        /// Pen вывода
        /// </summary>
        private readonly Pen _pen;
        /// <summary>
        /// Объект двойной буфферизации
        /// </summary>
        private BufferedGraphics _bufferedGraphics;
        
        /// <summary>
        /// Конструктор класса вывода
        /// </summary>
        /// <param name="parOffsetX">Координата Х начала вывода</param>
        /// <param name="parOffsetY">Координата Y начала вывода</param>
        /// <param name="parBufferedGraphics">Объект двойной буфферизации</param>
        public ViewStringWindows(int parOffsetX, int parOffsetY, BufferedGraphics parBufferedGraphics) : base(parOffsetX, parOffsetY)
        {
            _bufferedGraphics = parBufferedGraphics;
            _brush = new SolidBrush(Color.Blue);
            _pen = new Pen(Color.LightBlue);
        }

        /// <summary>
        /// Метод рисования
        /// </summary>
        /// <param name="parText">Строка вывода</param>
        public void Draw(string parText)
        {
            _bufferedGraphics.Graphics.DrawString(parText, new Font("Arial", FONT_SIZE), _brush, new Rectangle(OffsetX, OffsetY, 800, 400));
        }
    }
}