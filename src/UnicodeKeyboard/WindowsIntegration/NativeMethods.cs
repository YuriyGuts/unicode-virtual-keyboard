using System;
using System.Runtime.InteropServices;
using System.Text;

namespace YuriyGuts.UnicodeKeyboard.WindowsIntegration
{
    /// <summary>
    /// Provides managed wrappers for some of the WinAPI functions.
    /// </summary>
    internal static class NativeMethods
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

        [DllImport("user32.dll")]
        public static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        private static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int GetWindowText(IntPtr hWnd, StringBuilder lpResult, int nMaxCount);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr GetParent(IntPtr hWnd);

        [DllImport("user32.dll")]
        public static extern IntPtr GetWindowDC(IntPtr hWnd);

        [DllImport("user32.dll")]
        public static extern IntPtr GetWindowRect(IntPtr hwnd, ref NativeStructs.RECT rc);

        [DllImport("user32.dll")]
        public static extern bool InvalidateRect(IntPtr hWnd, IntPtr lpRect, bool bErase);

        [DllImport("user32.dll")]
        public static extern bool ScreenToClient(IntPtr hWnd, ref NativeStructs.POINT lpPoint);

        [DllImport("user32.dll")]
        public static extern IntPtr WindowFromPoint(NativeStructs.POINT Point);

        [DllImport("user32.dll")]
        public static extern IntPtr ChildWindowFromPoint(IntPtr hWndParent, NativeStructs.POINT Point);

        [DllImport("user32.dll")]
        public static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

        [DllImport("user32.dll")]
        public static extern bool RedrawWindow(IntPtr hWnd, IntPtr lpRect, IntPtr hrgnUpdate, uint flags);

        [DllImport("user32.dll")]
        public static extern bool UpdateWindow(IntPtr hWnd);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern UInt32 SendInput(UInt32 nInputs, ref NativeStructs.INPUT pInputs, int cbSize);


        public static string GetParentWindowTitle(IntPtr hWnd)
        {
            IntPtr parentWindow = hWnd;
            while (true)
            {
                IntPtr newParent = GetParent(parentWindow);
                if (newParent == IntPtr.Zero)
                {
                    break;
                }
                parentWindow = newParent;
            }
            
            StringBuilder buffer = new StringBuilder(256);
            GetWindowText(parentWindow, buffer, buffer.Capacity);
            return buffer.ToString();
        }

        public static string GetClassName(IntPtr hWnd)
        {
            StringBuilder buffer = new StringBuilder(256);
            GetClassName(hWnd, buffer, buffer.Capacity);
            return buffer.ToString();
        }
    }
}
