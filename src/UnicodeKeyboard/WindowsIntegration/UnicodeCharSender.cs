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
            NativeMethods.SetForegroundWindow(hTargetWindow);
            NativeStructs.INPUT input = new NativeStructs.INPUT
            {
                type = NativeMethods.INPUT_KEYBOARD,
                input = new NativeStructs.KEYBDINPUT
                {
                    wVk = 0,
                    wScan = charCode,
                    dwFlags = NativeMethods.KEYEVENTF_UNICODE,
                    time = 0,
                    dwExtraInfo = IntPtr.Zero
                }
            };

            Trace.WriteLine(string.Format("Sending {0:X4} to {1:X8}", charCode, hTargetWindow.ToInt32()));
            NativeMethods.SendInput(1, ref input, Marshal.SizeOf(typeof(NativeStructs.INPUT)));
        }
    }
}
