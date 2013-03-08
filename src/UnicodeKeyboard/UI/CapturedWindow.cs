using System;
using System.Drawing;
using System.Windows.Forms;
using YuriyGuts.UnicodeKeyboard.WindowsIntegration;

namespace YuriyGuts.UnicodeKeyboard.UI
{
    internal class CapturedWindow : IDisposable
    {
        private IntPtr handle = IntPtr.Zero;
        private readonly Pen highlightPen = new Pen(Brushes.Red, 2);

        private object selectedObject;

        public IntPtr Handle
        {
            get { return handle; }
        }

        public object ActiveObject
        {
            get { return selectedObject; }
        }

        public object ActiveWindow
        {
            get
            {
                if (handle != IntPtr.Zero)
                {
                    return Control.FromHandle(handle);
                }
                return null;
            }
        }

        public string ClassName
        {
            get
            {
                if (!IsValid)
                {
                    return null;
                }
                return NativeMethods.GetClassName(handle);
            }
        }

        public bool IsManagedByClassName
        {
            get
            {
                string className = ClassName;
                if (className != null && className.StartsWith("WindowsForms10"))
                {
                    return true;
                }
                return false;
            }
        }

        public bool IsValid
        {
            get { return handle != IntPtr.Zero; }
        }

        public bool IsManaged
        {
            get { return ActiveWindow != null; }
        }

        internal bool SetWindowHandle(IntPtr hWnd)
        {
            Refresh();
            handle = hWnd;

            Refresh();
            Highlight();

            bool changed = false;
            object activeWindow = ActiveWindow;
            if (activeWindow != selectedObject)
            {
                changed = true;
                selectedObject = activeWindow;
            }

            return changed;
        }

        public void Refresh()
        {
            if (!IsValid)
            {
                return;
            }

            IntPtr windowToRedraw = handle;
            IntPtr parentWindow = NativeMethods.GetParent(windowToRedraw);
            if (parentWindow != IntPtr.Zero)
            {
                windowToRedraw = parentWindow;
            }

            NativeMethods.InvalidateRect(windowToRedraw, IntPtr.Zero, true);
            NativeMethods.UpdateWindow(windowToRedraw);
            NativeMethods.RedrawWindow
            (
                windowToRedraw,
                IntPtr.Zero,
                IntPtr.Zero,
                NativeStructs.RDW.RDW_FRAME
                    | NativeStructs.RDW.RDW_INVALIDATE
                    | NativeStructs.RDW.RDW_UPDATENOW
                    | NativeStructs.RDW.RDW_ERASENOW
                    | NativeStructs.RDW.RDW_ALLCHILDREN
            );
        }

        public void Highlight()
        {
            NativeStructs.RECT windowRect = new NativeStructs.RECT(0, 0, 0, 0);
            NativeMethods.GetWindowRect(handle, ref windowRect);

            IntPtr windowDC = NativeMethods.GetWindowDC(handle);
            if (windowDC != IntPtr.Zero)
            {
                Graphics graph = Graphics.FromHdc(windowDC, handle);
                graph.DrawRectangle(highlightPen, 1, 1, windowRect.Width - 2, windowRect.Height - 2);
                graph.Dispose();
                NativeMethods.ReleaseDC(handle, windowDC);
            }
        }

        #region IDisposable Members

        public void Dispose()
        {
            Refresh();
            highlightPen.Dispose();
        }

        #endregion
    }
}
