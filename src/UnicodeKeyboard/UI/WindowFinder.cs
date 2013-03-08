using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using YuriyGuts.UnicodeKeyboard.Properties;
using YuriyGuts.UnicodeKeyboard.WindowsIntegration;

namespace YuriyGuts.UnicodeKeyboard.UI
{
    /// <summary>
    /// Crosshair control for selecting windows on the desktop.
    /// Portions Copyright (c) 2005 Corneliu I. Tusnea [http://hawkeye.codeplex.com/].
    /// </summary>
    [DefaultEvent("ActiveWindowChanged")]
    internal partial class WindowFinder : UserControl
    {
        public event EventHandler ActiveWindowChanged;
        public event EventHandler ActiveWindowSelected;

        private bool isSearching;
        private readonly CapturedWindow window;
        private readonly Cursor crosshairCursor;

        public WindowFinder()
        {
            window = new CapturedWindow();
            crosshairCursor = new Cursor(new MemoryStream(Resources.CrosshairCursor));

            InitializeComponent();

            MouseDown += WindowFinder_MouseDown;
            MouseUp += WindowFinder_MouseUp;
        }

        public CapturedWindow Window
        {
            get { return window; }
        }

        public object SelectedObject
        {
            get { return window.ActiveObject; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public IntPtr SelectedHandle
        {
            get { return window.Handle; }
            set
            {
                window.SetWindowHandle(value);
                InvokeActiveWindowChanged();
            }
        }

        public void StartSearch()
        {
            Cursor.Current = crosshairCursor;
            isSearching = true;
            Capture = true;
            MouseMove += WindowFinder_MouseMove;
        }

        public void EndSearch()
        {
            MouseMove -= WindowFinder_MouseMove;
            Capture = false;
            isSearching = false;
            Cursor.Current = Cursors.Default;

            Window.Refresh();
            if (ActiveWindowSelected != null)
            {
                ActiveWindowSelected(this, EventArgs.Empty);
            }
        }

        private void InvokeActiveWindowChanged()
        {
            if (ActiveWindowChanged != null)
            {
                ActiveWindowChanged(this, EventArgs.Empty);
            }
        }

        private void WindowFinder_MouseDown(object sender, MouseEventArgs e)
        {
            if (!isSearching)
            {
                StartSearch();
            }
        }

        private void WindowFinder_MouseMove(object sender, MouseEventArgs e)
        {
            if (!isSearching)
            {
                EndSearch();
            }

            // Grab the window from the screen location of the mouse.
            Point newPoint = PointToScreen(new Point(e.X, e.Y));
            NativeStructs.POINT windowPoint = NativeStructs.POINT.FromPoint(newPoint);
            IntPtr foundWindow = NativeMethods.WindowFromPoint(windowPoint);

            // Do we have a valid window handle?
            if (foundWindow != IntPtr.Zero)
            {
                // Give it another try, it might be a child window (disabled, hidden, etc.).
                // Offset the point to be a client point of the active window.
                if (NativeMethods.ScreenToClient(foundWindow, ref windowPoint))
                {
                    // Check if there is some hidden/disabled child window at this point.
                    IntPtr childWindow = NativeMethods.ChildWindowFromPoint(foundWindow, windowPoint);
                    if (childWindow != IntPtr.Zero)
                    {
                        // Great, we have the inner child.
                        foundWindow = childWindow;
                    }
                }
            }

            // Is this the same window as the last detected one?
            if (window.Handle != foundWindow)
            {
                if (window.SetWindowHandle(foundWindow))
                {
                    InvokeActiveWindowChanged();
                }
            }
        }

        private void WindowFinder_MouseUp(object sender, MouseEventArgs e)
        {
            EndSearch();
        }

        private void DisposeCustom()
        {
            window.Dispose();
            crosshairCursor.Dispose();
        }
    }
}