using System;
using View.Objects;

namespace ConsoleView.Objects
{
    /// <summary>
    /// Предстваление количества очков для консоли
    /// </summary>
    public class ViewScoresConsole : ViewScores
    {
        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="parOffsetX">Координата X</param>
        /// <param name="parOffsetY">Координата Y</param>
        public ViewScoresConsole(int parOffsetX, int parOffsetY) : base(parOffsetX, parOffsetY)
        {
        }

        /// <summary>
        /// вывод количества очков на консоль
        /// </summary>
        /// <param name="parScores">Количество очков</param>
        public override void Draw(int parScores)
        {
            int x = 33 + OffsetX;
            int y = OffsetY;
            
            FastOutput.Write("Очки: " + parScores, x, y, ConsoleColor.White);
        }
    }
}