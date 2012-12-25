using System;
using System.Data;
using System.Windows.Forms;
using YuriyGuts.UnicodeKeyboard.ResourceWrappers;
using YuriyGuts.UnicodeKeyboard.Settings;

namespace YuriyGuts.UnicodeKeyboard.UI
{
    /// <summary>
    /// Application options form.
    /// </summary>
    public partial class OptionsForm : Form
    {
        private string oldLanguageCode;
        private DataTable languageTable;

        private const string LanguageCodeColumn = "LanguageCode";
        private const string LanguageNameColumn = "LanguageName";

        /// <summary>
        /// Initializes a new instance of the OptionsForm class.
        /// </summary>
        public OptionsForm()
        {
            InitializeComponent();
            InitializeComponentCustom();
        }

        private void InitializeComponentCustom()
        {
            languageTable = new DataTable();
            languageTable.Columns.Add(LanguageCodeColumn, typeof(string));
            languageTable.Columns.Add(LanguageNameColumn, typeof(string));

            languageTable.Rows.Add("en", "English");
            languageTable.Rows.Add("ru", "Russian");
            languageTable.Rows.Add("uk", "Ukrainian");
        }

        /// <summary>
        /// Opens the Options form with the specified owner window.
        /// </summary>
        /// <param name="owner">Owner window.</param>
        /// <returns>DialogResult of the OptionsForm.</returns>
        public static DialogResult Execute(IWin32Window owner)
        {
            DialogResult result;
            using (OptionsForm optionsForm = new OptionsForm())
            {
                result = optionsForm.ShowDialog(owner);
            }
            return result;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            InitializeMUI();
            LoadData();
        }

        private void InitializeMUI()
        {
            languageTable.Rows[0][LanguageNameColumn] = LocalizationHelper.GetGlobalResource("Language_EN_US");
            languageTable.Rows[1][LanguageNameColumn] = LocalizationHelper.GetGlobalResource("Language_RU_RU");
            languageTable.Rows[2][LanguageNameColumn] = LocalizationHelper.GetGlobalResource("Language_UK_UA");
        }

        private void LoadData()
        {
            oldLanguageCode = UserSettings.Instance.Language;
            cmbInterfaceLanguage.DisplayMember = LanguageNameColumn;
            cmbInterfaceLanguage.ValueMember = LanguageCodeColumn;
            cmbInterfaceLanguage.DataSource = languageTable;
            cmbInterfaceLanguage.SelectedValue = UserSettings.Instance.Language;

            kbdPrimaryShortcut.Transcriber = KeyboardShortcutTranscriber.Instance;
            kbdSecondaryShortcut.Transcriber = KeyboardShortcutTranscriber.Instance;

            kbdPrimaryShortcut.Value = UserSettings.Instance.PrimaryApplicationShortcut;
            kbdSecondaryShortcut.Value = UserSettings.Instance.SecondaryApplicationShortcut;

            chkShowIconInSystemTray.Checked = UserSettings.Instance.ShowIconInSystemTray;
            chkMinimizeOnFocusLost.Checked = UserSettings.Instance.MinimizeOnFocusLost;
            chkExitOnClose.Checked = UserSettings.Instance.TerminateOnClose;
            chkLaunchOnWindowsStartup.Checked = UserSettings.Instance.LaunchOnWindowsStartup;
        }

        private bool ValidateData()
        {
            if (kbdPrimaryShortcut.Value == kbdSecondaryShortcut.Value)
            {
                ShowValidationErrorMessage(LocalizationHelper.GetResource(this, "msgDuplicateKeyboardShortcuts"));
                return false;
            }
            if (!IsKeyboardShortcutValid(kbdPrimaryShortcut.Value))
            {
                ShowValidationErrorMessage(LocalizationHelper.GetResource(this, "msgInvalidPrimaryShortcut"));
                return false;
            }
            if (!IsKeyboardShortcutValid(kbdSecondaryShortcut.Value))
            {
                ShowValidationErrorMessage(LocalizationHelper.GetResource(this, "msgInvalidSecondaryShortcut"));
                return false;
            }

            return true;
        }

        private void ShowValidationErrorMessage(string message)
        {
            MessageBox.Show
            (
                this,
                message,
                LocalizationHelper.GetGlobalResource("Error"),
                MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation
            );
        }

        private void ApplyAndSaveSettings()
        {
            UserSettings.Instance.Language = cmbInterfaceLanguage.SelectedValue.ToString();
            
            UserSettings.Instance.PrimaryApplicationShortcut = kbdPrimaryShortcut.Value;
            UserSettings.Instance.SecondaryApplicationShortcut = kbdSecondaryShortcut.Value;

            UserSettings.Instance.ShowIconInSystemTray = chkShowIconInSystemTray.Checked;
            UserSettings.Instance.MinimizeOnFocusLost = chkMinimizeOnFocusLost.Checked;
            UserSettings.Instance.TerminateOnClose = chkExitOnClose.Checked;
            UserSettings.Instance.LaunchOnWindowsStartup = chkLaunchOnWindowsStartup.Checked;

            UserSettings.Instance.Save(true);
        }

        private void CheckIfLanguageChangedAndOfferRestart()
        {
            if (cmbInterfaceLanguage.SelectedValue.ToString().ToLower() != oldLanguageCode.ToLower())
            {
                DialogResult restartConfirmationResult = MessageBox.Show
                (
                    this,
                    LocalizationHelper.GetResource(this, "msgLanguageSettingsAppRestartConfirmation"),
                    Text,
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (restartConfirmationResult == DialogResult.Yes)
                {
                    Application.Restart();
                }
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (ValidateData())
            {
                ApplyAndSaveSettings();
                CheckIfLanguageChangedAndOfferRestart();
                DialogResult = DialogResult.OK;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void kbdPrimaryShortcut_ValidateShortcut(object sender, KeyboardShortcutValidationEventArgs e)
        {
            e.IsValid = IsKeyboardShortcutValid(e.Keys);
        }

        private void kbdSecondaryShortcut_ValidateShortcut(object sender, KeyboardShortcutValidationEventArgs e)
        {
            e.IsValid = IsKeyboardShortcutValid(e.Keys);
        }

        private bool IsKeyboardShortcutValid(Keys keys)
        {
            return (keys & ~Keys.Modifiers) != Keys.None;
        }
    }
}
