using System.Drawing;
using Model.Objects;
using View.Objects;

namespace WindowsFormsView.Objects
{
    /// <summary>
    /// Представление игрового объекта для WindowsForms
    /// </summary>
    public abstract class ViewGameObjectWindows : ViewGameObject
    {
        /// <summary>
        /// Двойная буфферизация
        /// </summary>
        protected BufferedGraphics BufferedGraphics { get; set; }

        /// <summary>
        /// Перо для рисования
        /// </summary>
        protected Pen Pen { get; set; }

        /// <summary>
        /// Кисть для рисования
        /// </summary>
        protected Brush Brush { get; set; }

        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="parOffsetX">Координата X</param>
        /// <param name="parOffsetY">Координата Y</param>
        /// <param name="parBufferedGraphics">Двойная буфферизация</param>
        public ViewGameObjectWindows(BufferedGraphics parBufferedGraphics, int parOffsetX, int parOffsetY) : base(parOffsetX, parOffsetY)
        {
            BufferedGraphics = parBufferedGraphics;
        }
    }
}