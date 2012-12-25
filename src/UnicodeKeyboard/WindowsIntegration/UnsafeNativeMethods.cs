using System;
using System.Runtime.InteropServices;
using System.Text;

namespace YuriyGuts.UnicodeKeyboard.WindowsIntegration
{
    /// <summary>
    /// Provides managed wrappers for some of the WinAPI functions.
    /// </summary>
    internal static class UnsafeNativeMethods
    {
        public const int INPUT_MOUSE = 0;
        public const int INPUT_KEYBOARD = 1;
        public const int INPUT_HARDWARE = 2;

        public const UInt32 KEYEVENTF_EXTENDEDKEY = 0x0001;
        public const UInt32 KEYEVENTF_KEYUP = 0x0002;
        public const UInt32 KEYEVENTF_UNICODE = 0x0004;
        public const UInt32 KEYEVENTF_SCANCODE = 0x0008;

        public const UInt32 WM_KEYDOWN = 0x0100;
        public const UInt32 WM_KEYUP = 0x0101;
        public const UInt32 WM_CHAR = 0x0102;

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

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        public static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int GetWindowText(IntPtr hWnd, StringBuilder lpResult, int nMaxCount);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern UInt32 SendInput(UInt32 nInputs, ref INPUT pInputs, int cbSize);
    }
}
