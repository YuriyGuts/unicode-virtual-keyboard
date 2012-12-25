using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Windows.Forms;
using YuriyGuts.UnicodeKeyboard.Interaction;
using YuriyGuts.UnicodeKeyboard.Properties;
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
            InitializeGlyphDisplayer();
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
            txtCharCode.Focus();
            txtCharCode.SelectAll();
            isWindowTrackingEnabled = false;
        }

        private void HideApplication()
        {
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
                IntPtr hNewTargetWnd = UnsafeNativeMethods.GetForegroundWindow();
                if (hNewTargetWnd != hTargetWindow && hNewTargetWnd != Handle)
                {
                    hTargetWindow = hNewTargetWnd;
                    Trace.WriteLine("New target window: " + hTargetWindow.ToInt32().ToString("X8"));
                }
            }
        }

        private void commandGateway_ShowApplicationCommandReceived(object sender, ApplicationPopupModeEventArgs e)
        {
            switch (e.PopupMode)
            {
                case ApplicationPopupMode.DecimalCodeSearch:
                    rbDecimalMode.Checked = true;
                    break;
                case ApplicationPopupMode.HexCodeSearch:
                    rbHexMode.Checked = true;
                    break;
                case ApplicationPopupMode.TextSearch:
                    rbTextMode.Checked = true;
                    break;
            }
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

        private ushort EnteredCharacterCode
        {
            get
            {
                ushort result;
                if (!ParseCharacterCode(txtCharCode.Text, rbHexMode.Checked || rbTextMode.Checked, out result))
                {
                    result = 0;
                }
                return result;
            }
        }

        private void InitializeGlyphDisplayer()
        {
            lblCharPreview.Font = UIHelper.UnicodeCharacterFont;
        }

        private static bool ParseCharacterCode(string text, bool allowHex, out ushort result)
        {
            return ushort.TryParse(text, allowHex ? NumberStyles.HexNumber : NumberStyles.Integer, CultureInfo.InvariantCulture, out result);
        }

        private void HandleAccept(bool minimizeBeforeSending)
        {
            ushort charCode = 0;
            bool shouldSendChar = false;

            if (rbHexMode.Checked || rbDecimalMode.Checked)
            {
                charCode = EnteredCharacterCode;
                if (charCode > 0)
                {
                    shouldSendChar = true;
                }
                else
                {
                    ShowErrorMessage(LocalizationHelper.GetResource(this, "msgInvalidCharCode"));
                    return;
                }
            }

            if (rbTextMode.Checked)
            {
                ExecuteActionWithFocusLostEventLock(() =>
                {
                    ushort pickedCharCode = CharacterLookupForm.Execute(txtCharCode.Text, this);
                    if (pickedCharCode > 0)
                    {
                        charCode = pickedCharCode;
                        shouldSendChar = true;
                    }
                });
            }

            if (shouldSendChar)
            {
                if (minimizeBeforeSending)
                {
                    HideApplication();
                }

                try
                {
                    UnicodeCharSender.Send(hTargetWindow, charCode);
                }
                catch (Exception ex)
                {
                    ShowErrorMessage(LocalizationHelper.GetResource(this, "msgSendCharFailed"), ex);
                }

                if (!minimizeBeforeSending)
                {
                    UnsafeNativeMethods.SetForegroundWindow(Handle);
                }
            }
        }

        private void CopyEnteredCharToClipboard()
        {
            ushort enteredCharCode = EnteredCharacterCode;
            if (enteredCharCode > 0)
            {
                Clipboard.SetText(((char)enteredCharCode).ToString());
            }
        }

        private void AddCharCodeToFavorites(ushort charCode)
        {
            if (charCode != 0)
            {
                ExecuteActionWithFocusLostEventLock(() =>
                {
                    int? selectedIndex = AddToFavoritesForm.Execute(charCode, this);
                    if (selectedIndex.HasValue)
                    {
                        UserSettings.Instance.Favorites[selectedIndex.Value] = charCode;
                        UserSettings.Instance.Save(false);
                        LoadFavorites();
                    }
                });
            }
            else
            {
                ShowErrorMessage(LocalizationHelper.GetResource(this, "msgInvalidCharCode"));
            }
        }

        private void ClearInput()
        {
            txtCharCode.Clear();
            txtCharCode.Focus();
        }

        private void HandleInputModeChanged()
        {
            ushort charCode = 0;
            if (!rbTextMode.Checked)
            {
                charCode = EnteredCharacterCode;
                if (charCode == 0)
                {
                    txtCharCode.Clear();
                }
            }

            btnAccept.Image = !rbTextMode.Checked ? Resources.CharAccept : Resources.CharSearch;
            toolTip.SetToolTip(btnAccept, LocalizationHelper.GetResource(this, string.Format("{0}_{1}", btnAccept.Name, !rbTextMode.Checked ? "ToolTip" : "SearchToolTip")));
            txtCharCode.CharacterCasing = rbTextMode.Checked ? CharacterCasing.Normal : CharacterCasing.Upper;
            txtCharCode.Focus();

            UpdateCharacterPreview(charCode);
        }

        private void UpdateCharacterPreview(ushort charCode)
        {
            if (charCode == 0)
            {
                lblCharPreview.ForeColor = Color.Silver;
                lblCharPreview.Text = @"?";
                lblCharDescription.Text = string.Empty;
            }
            else
            {
                lblCharPreview.ForeColor = Color.Black;
                lblCharPreview.Text = ((char)charCode).ToString();

                string charDescription = UnicodeCharacterDatabase.GetCharacterName(charCode) ?? string.Empty;
                lblCharDescription.Text = charDescription;
            }
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
            StringBuilder nameBuilder = new StringBuilder(1024);
            int nameLength = UnsafeNativeMethods.GetWindowText(hTargetWindow, nameBuilder, nameBuilder.Capacity);
            lblSenderWindowTitle.Text = nameLength > 0 ? nameBuilder.ToString() : LocalizationHelper.GetResource(this, "strNoTargetWindow");
            lblSenderWindowTitle.ForeColor = nameLength > 0 ? Color.DarkGreen : Color.Red;
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
            isWindowTrackingEnabled = true;
            if (lockFocusLostEvents)
            {
                return;
            }

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
            txtCharCode.Focus();
        }

        private void FormMain_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (!e.Alt && !e.Shift && e.Control)
            {
                if (e.KeyCode == Keys.Delete)
                {
                    ClearInput();
                }
                if (e.KeyCode == Keys.F1)
                {
                    rbHexMode.Checked = true;
                }
                if (e.KeyCode == Keys.F2)
                {
                    rbDecimalMode.Checked = true;
                }
                if (e.KeyCode == Keys.F3)
                {
                    rbTextMode.Checked = true;
                }
            }

            // Esc - hide window.
            if (!e.Alt && !e.Control && !e.Shift && e.KeyCode == Keys.Escape)
            {
                HideApplication();
            }

            // Ctrl+Alt+C - copy character to clipboard
            if (e.KeyCode == Keys.C && e.Modifiers == (Keys.Control | Keys.Alt))
            {
                CopyEnteredCharToClipboard();
            }

            // Ctrl+M - launch Windows Character Map.
            if (e.KeyCode == Keys.M && e.Control && !e.Alt && !e.Shift)
            {
                LaunchWindowsCharmap();
            }

            // Ctrl+O - show options window.
            if (e.KeyCode == Keys.O && e.Control && !e.Alt && !e.Shift)
            {
                ShowOptionsWindow();
            }
        }

        private void rbHexMode_CheckedChanged(object sender, EventArgs e)
        {
            HandleInputModeChanged();
        }

        private void rbDecimalMode_CheckedChanged(object sender, EventArgs e)
        {
            HandleInputModeChanged();
        }

        private void rbTextMode_CheckedChanged(object sender, EventArgs e)
        {
            HandleInputModeChanged();
        }

        private void lnkCharmap_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LaunchWindowsCharmap();
        }

        private void lnkOptions_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ShowOptionsWindow();
        }

        private void lnkAbout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ShowAboutWindow();
        }

        private void lnkExit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            TerminateApplication();
        }

        private void txtCharCode_KeyDown(object sender, KeyEventArgs e)
        {
            bool isNoModifiers = e.Modifiers == Keys.None;
            bool isNavigationKey = (e.KeyCode == Keys.Left || e.KeyCode == Keys.Right || e.KeyCode == Keys.Home || e.KeyCode == Keys.End) && (isNoModifiers || e.Modifiers == Keys.Shift);
            bool isEditKey = (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back || e.KeyValue == 3);
            bool isValidDecimalKey = isNoModifiers && (e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9) || (e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9);
            bool isValidHexKey = isValidDecimalKey || (e.KeyCode >= Keys.A && e.KeyCode <= Keys.F);

            bool shouldAcceptKey = false;
            do
            {
                // Enter - accept character code or text
                if (e.KeyCode == Keys.Enter && (isNoModifiers || e.Modifiers == Keys.Control))
                {
                    HandleAccept(e.Modifiers != Keys.Control);
                    break;
                }

                // Alt+F4 or Esc - hide application
                if ((e.Modifiers == Keys.Alt && e.KeyCode == Keys.F4) || e.KeyCode == Keys.Escape)
                {
                    HideApplication();
                    break;
                }

                if (rbHexMode.Checked)
                {
                    shouldAcceptKey = isEditKey || isNavigationKey || isValidHexKey;
                    break;
                }
                if (rbDecimalMode.Checked)
                {
                    shouldAcceptKey = isEditKey || isNavigationKey || isValidDecimalKey;
                    break;
                }
                if (rbTextMode.Checked)
                {
                    shouldAcceptKey = true;
                    break;
                }
            }
            while (false);

            e.Handled = e.SuppressKeyPress = !shouldAcceptKey;
        }

        private void txtCharCode_TextChanged(object sender, EventArgs e)
        {
            if (!rbTextMode.Checked)
            {
                tmrCharacterPreview.Stop();
                tmrCharacterPreview.Start();
            }
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            HandleAccept(true);
            txtCharCode.Focus();
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            CopyEnteredCharToClipboard();
        }

        private void btnAddToFavorites_Click(object sender, EventArgs e)
        {
            if (rbHexMode.Checked || rbDecimalMode.Checked)
            {
                AddCharCodeToFavorites(EnteredCharacterCode);
            }
            if (rbTextMode.Checked)
            {
                ExecuteActionWithFocusLostEventLock(() =>
                {
                    ushort pickedCharCode = CharacterLookupForm.Execute(txtCharCode.Text, this);
                    if (pickedCharCode > 0)
                    {
                        AddCharCodeToFavorites(pickedCharCode);
                    }
                });
            }
        }

        private void tmrCharacterPreview_Tick(object sender, EventArgs e)
        {
            tmrCharacterPreview.Stop();
            ushort charCode = EnteredCharacterCode;
            UpdateCharacterPreview(charCode);
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

        #endregion Form and control events
    }
}
