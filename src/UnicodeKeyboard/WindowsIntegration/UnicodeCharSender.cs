using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace YuriyGuts.UnicodeKeyboard.WindowsIntegration
{
    /// <summary>
    /// Responsible for sending Unicode input to native windows.
    /// </summary>
    public static class UnicodeCharSender
    {
        /// <summary>
        /// Activates a window and sends a Unicode character with the specified code to it.
        /// </summary>
        /// <param name="hTargetWindow">Target window handle.</param>
        /// <param name="charCode">Unicode character code.</param>
        public static void Send(IntPtr hTargetWindow, ushort charCode)
        {
            UnsafeNativeMethods.SetForegroundWindow(hTargetWindow);
            UnsafeNativeMethods.INPUT input = new UnsafeNativeMethods.INPUT
            {
                type = UnsafeNativeMethods.INPUT_KEYBOARD,
                input = new UnsafeNativeMethods.KEYBDINPUT
                {
                    wVk = 0,
                    wScan = charCode,
                    dwFlags = UnsafeNativeMethods.KEYEVENTF_UNICODE,
                    time = 0,
                    dwExtraInfo = IntPtr.Zero
                }
            };

            Trace.WriteLine(string.Format("Sending {0:X4} to {1:X8}", charCode, hTargetWindow.ToInt32()));
            UnsafeNativeMethods.SendInput(1, ref input, Marshal.SizeOf(typeof(UnsafeNativeMethods.INPUT)));
        }
    }
}
