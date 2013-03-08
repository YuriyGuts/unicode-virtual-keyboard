using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace YuriyGuts.UnicodeKeyboard.WindowsIntegration
{
    internal static class NativeStructs
    {
        public class RDW
        {
            public const uint RDW_INVALIDATE = 0x0001;
            public const uint RDW_INTERNALPAINT = 0x0002;
            public const uint RDW_ERASE = 0x0004;

            public const uint RDW_VALIDATE = 0x0008;
            public const uint RDW_NOINTERNALPAINT = 0x0010;
            public const uint RDW_NOERASE = 0x0020;

            public const uint RDW_NOCHILDREN = 0x0040;
            public const uint RDW_ALLCHILDREN = 0x0080;

            public const uint RDW_UPDATENOW = 0x0100;
            public const uint RDW_ERASENOW = 0x0200;

            public const uint RDW_FRAME = 0x0400;
            public const uint RDW_NOFRAME = 0x0800;
        }

        public struct KEYBDINPUT
        {
            public ushort wVk;
            public ushort wScan;
            public UInt32 dwFlags;
            public UInt32 time;
            public IntPtr dwExtraInfo;
        }

        [StructLayout(LayoutKind.Explicit, Size = 28)]
        public struct INPUT
        {
            [FieldOffset(0)]
            public int type;

            [FieldOffset(4)]
            public KEYBDINPUT input;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            public readonly int x;
            public readonly int y;

            public POINT(int x, int y)
            {
                this.x = x;
                this.y = y;
            }

            public POINT ToPoint()
            {
                return new POINT(x, y);
            }

            public static POINT FromPoint(Point pt)
            {
                return new POINT(pt.X, pt.Y);
            }

            public override bool Equals(object other)
            {
                if (other is POINT)
                {
                    POINT that = (POINT)other;
                    return that.x == x && that.y == y;
                }
                return false;
            }

            public override int GetHashCode()
            {
                return (x ^ y);
            }

            public override string ToString()
            {
                return string.Format("{{X={0}, Y={1}}}", x, y);
            }
        }

        [Serializable, StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
            public RECT(int Left, int Top, int Right, int Bottom)
            {
                this.Left = Left;
                this.Top = Top;
                this.Right = Right;
                this.Bottom = Bottom;
            }

            public int Height
            {
                get { return (Bottom - Top); }
            }

            public int Width
            {
                get { return (Right - Left); }
            }

            public Size Size
            {
                get { return new Size(Width, Height); }
            }

            public Point Location
            {
                get { return new Point(Left, Top); }
            }

            public Rectangle ToRectangle()
            {
                return Rectangle.FromLTRB(Left, Top, Right, Bottom);
            }

            public static RECT FromRectangle(Rectangle rectangle)
            {
                return new RECT(rectangle.Left, rectangle.Top, rectangle.Right, rectangle.Bottom);
            }
        }
    }
}
