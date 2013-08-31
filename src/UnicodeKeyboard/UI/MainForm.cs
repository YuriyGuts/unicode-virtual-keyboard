using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using YuriyGuts.UnicodeKeyboard.Interaction;
using YuriyGuts.UnicodeKeyboard.ResourceWrappers;
using YuriyGuts.UnicodeKeyboard.Settings;
using YuriyGuts.UnicodeKeyboard.WindowsIntegration;

namespace YuriyGuts.UnicodeKeyboard.UI
{
    /// <summary>
    /// Represents the main form of the application.
    /// </summary>
    public partial class MainForm : Form
    {
        private bool isWindowTrackingEnabled;
        private IntPtr hTargetWindow;

        private bool lockFocusLostEvents;

        /// <summary>
        /// Initializes a new instance of the MainForm class.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            InitializeComponentCustom();
        }

        #region Initialization

        private void InitializeComponentCustom()
        {
            InitializeMUI();
            InitializeCommandProcessor();
            InitializeCharacterLookupForm();
            LoadFavorites();
        }

        private void LoadFavorites()
        {
            List<Label> favoriteControls = new List<Label>
            {
                lblFavoriteGlyph0, lblFavoriteGlyph1, lblFavoriteGlyph2, lblFavoriteGlyph3, lblFavoriteGlyph4,
                lblFavoriteGlyph5, lblFavoriteGlyph6, lblFavoriteGlyph7, lblFavoriteGlyph8, lblFavoriteGlyph9,
            };

            for (int i = 0; i < UserSettings.Instance.Favorites.Length; i++)
            {
                if (UserSettings.Instance.Favorites[i] > 0)
                {
                    ushort charCode = UserSettings.Instance.Favorites[i];
                    favoriteControls[i].Text = (((char)charCode).ToString());
                    string toolTipText = string.Format("{0:X4} - {1}", charCode, UnicodeCharacterDatabase.GetCharacterName(charCode));
                    toolTip.SetToolTip(favoriteControls[i], toolTipText);
                }
                else
                {
                    favoriteControls[i].Text = string.Empty;
                    toolTip.SetToolTip(favoriteControls[i], null);
                }
            }
        }

        private void InitializeCommandProcessor()
        {
            commandGateway = new CommandGateway();
            commandGateway.BeforeKeystrokeProcessed += commandGateway_BeforeKeystrokeProcessed;
            commandGateway.ShowApplicationCommandReceived += commandGateway_ShowApplicationCommandReceived;
            commandGateway.SendCharacterCommandReceived += commandGateway_SendCharacterCommandReceived;
        }

        private void InitializeCharacterLookupForm()
        {
            frmCharacterLookup = new CharacterLookupForm();
            frmCharacterLookup.ResultSubmitted += frmCharacterLookup_ResultSubmitted;
            frmCharacterLookup.VisibleChanged += (sender, args) => { lockFocusLostEvents = frmCharacterLookup.Visible; };
        }

        #endregion Initialization

        #region Application control

        private bool isTrayIconCloseClicked;
        private bool isTerminating;

        private static MainForm instance;

        /// <summary>
        /// Singleton implementation.
        /// </summary>
        public static MainForm Instance
        {
            get { return instance ?? (instance = new MainForm()); }
        }

        private void ShowApplication()
        {
            Show();
            Activate();
            WindowState = FormWindowState.Normal;
            txtCharSearch.Focus();
            txtCharSearch.SelectAll();
            isWindowTrackingEnabled = false;
        }

        private void HideApplication()
        {
            if (frmCharacterLookup.Visible)
            {
                frmCharacterLookup.SubmitResult(new CharacterSearchResult { Action = CharacterSearchAction.Cancel });
            }
            WindowState = FormWindowState.Minimized;
        }

        private void TerminateApplication()
        {
            isTerminating = true;
            UserSettings.Instance.Save(false);
            Close();
        }

        #endregion Application control

        #region Command processing

        private CommandGateway commandGateway;

        private void commandGateway_BeforeKeystrokeProcessed(object sender, KeyEventArgs e)
        {
            if (isWindowTrackingEnabled)
            {
                IntPtr hNewTargetWnd = NativeMethods.GetForegroundWindow();
                if (hNewTargetWnd != hTargetWindow && hNewTargetWnd != Handle)
                {
                    hTargetWindow = hNewTargetWnd;
                    Trace.WriteLine("New target window: " + hTargetWindow.ToInt32().ToString("X8"));
                }
            }
        }

        private void commandGateway_ShowApplicationCommandReceived(object sender, EventArgs e)
        {
            ShowApplication();
        }

        private void commandGateway_SendCharacterCommandReceived(object sender, SendCharacterCommandEventArgs e)
        {
            UnicodeCharSender.Send(hTargetWindow, e.CharacterCode);
        }

        #endregion Command processing

        #region Localization

        private void InitializeMUI()
        {
            Text = trayIcon.Text = trayIcon.BalloonTipTitle = LocalizationHelper.GetGlobalResource("ApplicationName");
            UpdateKeyboardShortcutDependentControls();
        }

        private void UpdateKeyboardShortcutDependentControls()
        {
            string primaryShortcutString = KeyboardShortcutTranscriber.Instance.GetKeyboardShortcutDisplayText(UserSettings.Instance.PrimaryApplicationShortcut);
            string secondaryShortcutString = KeyboardShortcutTranscriber.Instance.GetKeyboardShortcutDisplayText(UserSettings.Instance.SecondaryApplicationShortcut);

            trayIcon.BalloonTipText = string.Format(LocalizationHelper.GetObjectInternalResource(typeof(MainForm), "trayIcon.BalloonTipText"), primaryShortcutString);
            cmiTrayUsageHint.Text = string.Format(LocalizationHelper.GetObjectInternalResource(typeof(MainForm), "cmiTrayUsageHint.Text"), primaryShortcutString, secondaryShortcutString);
            lblFavorites.Text = string.Format(LocalizationHelper.GetObjectInternalResource(typeof(MainForm), "lblFavorites.Text"), secondaryShortcutString);
        }

        #endregion Localization

        #region Input box processing

        private CharacterLookupForm frmCharacterLookup;

        private void ShowCharacterLookupForm(bool focusSearchForm)
        {
            if (frmCharacterLookup.Visible)
            {
                frmCharacterLookup.SubmitResult(new CharacterSearchResult { Action = CharacterSearchAction.None });
            }

            frmCharacterLookup.SearchQuery = txtCharSearch.Text;
            AdjustCharacterLookupFormPosition();

            if (!frmCharacterLookup.Visible)
            {
                frmCharacterLookup.Show(this);
                AdjustCharacterLookupFormPosition();
            }

            if (focusSearchForm)
            {
                frmCharacterLookup.Focus();
            }
            else
            {
                txtCharSearch.Focus();
            }
        }

        private void AdjustCharacterLookupFormPosition()
        {
            frmCharacterLookup.Left = Left + txtCharSearch.Left + SystemInformation.FixedFrameBorderSize.Width;
            frmCharacterLookup.Top = Top + txtCharSearch.Top + txtCharSearch.Height + SystemInformation.ToolWindowCaptionHeight + 2;
        }

        private void SubmitSearchQuery(bool focusSearchForm)
        {
            tmrSearchPopupTimeout.Stop();
            ShowCharacterLookupForm(focusSearchForm);
        }

        private void ClearInput()
        {
            txtCharSearch.Clear();
            txtCharSearch.Focus();
        }

        #endregion Input box processing

        #region Utilities

        /// <summary>
        /// Executes an action without handling the focus change events 
        /// (critical for the MinimizeOnFocusLost = True user setting).
        /// </summary>
        /// <param name="action">Action to execute.</param>
        private void ExecuteActionWithFocusLostEventLock(MethodInvoker action)
        {
            lockFocusLostEvents = true;
            try
            {
                action();
            }
            finally
            {
                lockFocusLostEvents = false;
            }
        }

        private void LaunchWindowsCharmap()
        {
            try
            {
                Process.Start("charmap");
            }
            catch (Exception ex)
            {
                ShowErrorMessage(LocalizationHelper.GetResource(this, "msgCharmapLaunchFailed"), ex);
            }
        }

        private void ShowOptionsWindow()
        {
            // The command gateway has to be suspended because otherwise it might be impossible to edit the magic keystrokes.
            commandGateway.IsEnabled = false;
            cmiTrayOptions.Enabled = false;
            try
            {
                ExecuteActionWithFocusLostEventLock(() => OptionsForm.Execute(this));
                UpdateKeyboardShortcutDependentControls();
                trayIcon.Visible = UserSettings.Instance.ShowIconInSystemTray;
            }
            finally
            {
                commandGateway.IsEnabled = true;
                cmiTrayOptions.Enabled = true;
            }
        }

        private void ShowAboutWindow()
        {
            ExecuteActionWithFocusLostEventLock(() => AboutForm.Execute(this));
        }

        private void ShowErrorMessage(string text)
        {
            ExecuteActionWithFocusLostEventLock(() =>
                MessageBox.Show
                (
                    this,
                    text,
                    LocalizationHelper.GetGlobalResource("Error"),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation
                ));
        }

        private void ShowErrorMessage(string text, Exception exception)
        {
            ExecuteActionWithFocusLostEventLock(() =>
                MessageBox.Show
                  (
                    this,
                    string.Concat(text, Environment.NewLine, LocalizationHelper.GetGlobalResource("Details"), ": ", exception.Message),
                    LocalizationHelper.GetGlobalResource("Error"),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation
                  ));
        }

        private void UpdateTargetWindowDescription()
        {
            string title = NativeMethods.GetParentWindowTitle(hTargetWindow);
            lblTargetWindowTitle.Text = title;
        }

        #endregion Utilities

        #region Form and control events

        private void FormMain_Activated(object sender, EventArgs e)
        {
            Opacity = 1;
            UpdateTargetWindowDescription();
        }

        private void FormMain_Deactivate(object sender, EventArgs e)
        {
            if (lockFocusLostEvents)
            {
                return;
            }

            isWindowTrackingEnabled = true;
            if (UserSettings.Instance.MinimizeOnFocusLost)
            {
                HideApplication();
            }
            else
            {
                Opacity = 0.5;
            }
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            Hide();
            if (UserSettings.Instance.ShowIconInSystemTray)
            {
                trayIcon.Visible = true;
                trayIcon.ShowBalloonTip(2000);
            }
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isTerminating || e.CloseReason == CloseReason.ApplicationExitCall || e.CloseReason == CloseReason.TaskManagerClosing)
            {
                return;
            }

            if (!isTrayIconCloseClicked)
            {
                if (UserSettings.Instance.TerminateOnClose)
                {
                    TerminateApplication();
                }
                else
                {
                    e.Cancel = true;
                    HideApplication();
                }
            }
            isTrayIconCloseClicked = false;
        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (commandGateway != null)
            {
                commandGateway.Dispose();
            }
        }

        private void FormMain_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                isWindowTrackingEnabled = true;
                Hide();
            }
        }

        private void FormMain_Shown(object sender, EventArgs e)
        {
            txtCharSearch.Focus();
        }

        private void FormMain_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (!e.Alt && !e.Shift && e.Control)
            {
                if (e.KeyCode == Keys.Delete)
                {
                    ClearInput();
                }
            }

            // Esc: hide window.
            if (!e.Alt && !e.Control && !e.Shift && e.KeyCode == Keys.Escape)
            {
                HideApplication();
            }

            // Ctrl + M: launch Windows Character Map.
            if (e.KeyCode == Keys.M && e.Control && !e.Alt && !e.Shift)
            {
                LaunchWindowsCharmap();
            }

            // Ctrl + O: show options window.
            if (e.KeyCode == Keys.O && e.Control && !e.Alt && !e.Shift)
            {
                ShowOptionsWindow();
            }
        }

        private void frmCharacterLookup_ResultSubmitted(object sender, CharacterSearchResultEventArgs e)
        {
            switch (e.Result.Action)
            {
                case CharacterSearchAction.Cancel:
                    break;

                case CharacterSearchAction.InsertCharacter:
                    if (!e.Result.KeepApplicationActive)
                    {
                        HideApplication();
                    }

                    try
                    {
                        UnicodeCharSender.Send(hTargetWindow, e.Result.CharacterCode);
                    }
                    catch (Exception ex)
                    {
                        ShowErrorMessage(LocalizationHelper.GetResource(this, "msgSendCharFailed"), ex);
                    }

                    if (e.Result.KeepApplicationActive)
                    {
                        NativeMethods.SetForegroundWindow(Handle);
                    }
                    break;

                case CharacterSearchAction.CopyCharacterToClipboard:
                    Clipboard.SetText(((char)e.Result.CharacterCode).ToString());
                    HideApplication();
                    break;

                case CharacterSearchAction.AddCharacterToFavorites:
                    int? selectedIndex = AddToFavoritesForm.Execute(e.Result.CharacterCode, this);
                    if (selectedIndex.HasValue)
                    {
                        UserSettings.Instance.Favorites[selectedIndex.Value] = e.Result.CharacterCode;
                        UserSettings.Instance.Save(false);
                        LoadFavorites();
                    }
                    break;
            }
        }

        private void txtCharCode_KeyDown(object sender, KeyEventArgs e)
        {
            // Enter: search characters
            if (e.KeyCode == Keys.Enter && (e.Modifiers == Keys.None || e.Modifiers == Keys.Control))
            {
                e.Handled = e.SuppressKeyPress = true;
                SubmitSearchQuery(true);
            }

            // Alt + F4 or Esc: hide application
            if ((e.Modifiers == Keys.Alt && e.KeyCode == Keys.F4) || e.KeyCode == Keys.Escape)
            {
                e.Handled = e.SuppressKeyPress = true;
                HideApplication();
            }

            // Arrow / PageUp / PageDown keys: move focus to the popup form
            if (e.Modifiers == Keys.None && (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down || e.KeyCode == Keys.PageUp || e.KeyCode == Keys.PageDown))
            {
                if (frmCharacterLookup.Visible)
                {
                    frmCharacterLookup.Focus();
                }
            }

            // Backspace or Del with empty text box: hide the popup form.
            if (e.Modifiers == Keys.None && (e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete))
            {
                if (frmCharacterLookup.Visible && txtCharSearch.Text.Length == 0)
                {
                    frmCharacterLookup.SubmitResult(new CharacterSearchResult { Action = CharacterSearchAction.Cancel });
                }
            }
        }

        private void txtCharCode_TextChanged(object sender, EventArgs e)
        {
            tmrSearchPopupTimeout.Stop();
            tmrSearchPopupTimeout.Start();
        }

        private void tmrSearchPopupTimeout_Tick(object sender, EventArgs e)
        {
            tmrSearchPopupTimeout.Stop();
            SubmitSearchQuery(false);
        }

        private void cmiTrayOptions_Click(object sender, EventArgs e)
        {
            ShowOptionsWindow();
        }

        private void cmiTrayExit_Click(object sender, EventArgs e)
        {
            isTrayIconCloseClicked = true;
            TerminateApplication();
        }

        private void lblFavoriteGlyph_Click(object sender, EventArgs e)
        {
            Label label = sender as Label;
            if (label != null)
            {
                int favoriteIndex = label.Name[label.Name.Length - 1] - '0';
                if (UserSettings.Instance.Favorites[favoriteIndex] != 0)
                {
                    HideApplication();
                    UnicodeCharSender.Send(hTargetWindow, UserSettings.Instance.Favorites[favoriteIndex]);
                }
            }
        }

        private void btnOptions_Click(object sender, EventArgs e)
        {
            cmsOptions.Show(btnOptions, 0, btnOptions.Height);
        }

        private void cmiOptions_Click(object sender, EventArgs e)
        {
            ShowOptionsWindow();
        }

        private void cmiWindowsCharMap_Click(object sender, EventArgs e)
        {
            LaunchWindowsCharmap();
        }

        private void cmiAbout_Click(object sender, EventArgs e)
        {
            ShowAboutWindow();
        }

        private void cmiExit_Click(object sender, EventArgs e)
        {
            TerminateApplication();
        }

        private void windowFinder_ActiveWindowChanged(object sender, EventArgs e)
        {
            hTargetWindow = windowFinder.SelectedHandle;
            UpdateTargetWindowDescription();
        }

        private void windowFinder_ActiveWindowSelected(object sender, EventArgs e)
        {
            hTargetWindow = windowFinder.SelectedHandle;
            UpdateTargetWindowDescription();
        }

        #endregion Form and control events
    }
}
