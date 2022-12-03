using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;

namespace ConsoleView
{
    /// <summary>
    /// Класс, позволяющий быстро выводить данные на консоль
    /// </summary>
    public class FastOutput
    {
        private static CharInfo[,] _buf;
        private static SmallRect _rect;
        private static short _width, _height;
        private static SafeFileHandle _h;

        [DllImport("Kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static extern SafeFileHandle CreateFile(
           string parFileName,
           [MarshalAs(UnmanagedType.U4)] uint parFileAccess,
           [MarshalAs(UnmanagedType.U4)] uint parFileShare,
           IntPtr parSecurityAttributes,
           [MarshalAs(UnmanagedType.U4)] FileMode parCreationDisposition,
           [MarshalAs(UnmanagedType.U4)] int parFlags,
           IntPtr parTemplate);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool WriteConsoleOutput(
          SafeFileHandle parHConsoleOutput,
          CharInfo[] parLpBuffer,
          Coord parDwBufferSize,
          Coord parDwBufferCoord,
          ref SmallRect parLpWriteRegion);

        [StructLayout(LayoutKind.Sequential)]
        public struct Coord
        {
            public short X;
            public short Y;

            public Coord(short X, short Y)
            {
                this.X = X;
                this.Y = Y;
            }
        };

        [StructLayout(LayoutKind.Explicit)]
        public struct CharUnion
        {
            [FieldOffset(0)] public char UnicodeChar;
            [FieldOffset(0)] public byte AsciiChar;
        }

        [StructLayout(LayoutKind.Explicit)]
        public struct CharInfo
        {
            [FieldOffset(0)] public CharUnion Char;
            [FieldOffset(2)] public short Attributes;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct SmallRect
        {
            public short Left;
            public short Top;
            public short Right;
            public short Bottom;
        }

        /// <summary>
        /// Статический конструктор класса
        /// </summary>
        static FastOutput()
        {
            _h = CreateFile("CONOUT$", 0x40000000, 2, IntPtr.Zero, FileMode.Open, 0, IntPtr.Zero);
            _width = (short)Console.WindowWidth;
            _height = (short)Console.WindowHeight;

            if (!_h.IsInvalid)
            {
                _buf = new CharInfo[_height, _width];
                _rect = new SmallRect() { Left = 0, Top = 0, Right = _width, Bottom = _height };
            }
        }

        /// <summary>
        /// Вывести строку в буфер на позиции с заданным цветом
        /// </summary>
        /// <param name="parS">Строка</param>
        /// <param name="parX">Позиция X</param>
        /// <param name="parY">Позиция Y</param>
        /// <param name="parColor">Цвет вывода</param>
        public static void Write(string parS, int parX, int parY, ConsoleColor parColor)
        {
            var bytes = Console.OutputEncoding.GetBytes(parS);
            int offset = 0;
            byte previousByte = 0;
            foreach (var item in bytes)
            {
                if (parX + offset >= _width-1 || item == 10 && previousByte == 13)
                {
                    parY++;
                    offset = 0;
                }
                if (item < 20)
                {
                    previousByte = item;
                    continue;
                }
                _buf[parY, parX + offset].Attributes = (byte)parColor;
                _buf[parY, parX + offset++].Char.AsciiChar = item;
                previousByte = item;
            }
        }
        /// <summary>
        /// Очищает буфер
        /// </summary>
        public static void Clear()
        {
            _buf = new CharInfo[_height, _width];
        }

        /// <summary>
        /// Вывести буфер на консоль
        /// </summary>
        public static void PrintOnConsole()
        {
            WriteConsoleOutput(_h, _buf.Cast<CharInfo>().ToArray(),
                  new Coord() { X = _width, Y = _height },
                  new Coord() { X = 0, Y = 0 },
                  ref _rect);
        }
    }
}
