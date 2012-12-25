using YuriyGuts.UnicodeKeyboard.ResourceWrappers;

namespace YuriyGuts.UnicodeKeyboard.UI
{
    partial class OptionsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            SingleAssemblyComponentResourceManager resources = new SingleAssemblyComponentResourceManager(typeof(OptionsForm));
            this.chkMinimizeOnFocusLost = new System.Windows.Forms.CheckBox();
            this.chkExitOnClose = new System.Windows.Forms.CheckBox();
            this.chkLaunchOnWindowsStartup = new System.Windows.Forms.CheckBox();
            this.lblInterfaceLanguage = new System.Windows.Forms.Label();
            this.cmbInterfaceLanguage = new System.Windows.Forms.ComboBox();
            this.pnlButtonContainer = new System.Windows.Forms.Panel();
            this.btnOK = new System.Windows.Forms.Button();
            this.pnlButtonSpacer = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.pnlBottomLine = new System.Windows.Forms.Panel();
            this.pnlSettingsContainer = new System.Windows.Forms.Panel();
            this.chkShowIconInSystemTray = new System.Windows.Forms.CheckBox();
            this.pnlShortcutSelectorContainer = new System.Windows.Forms.Panel();
            this.pnlSecondaryShortcutSelectorPadding = new System.Windows.Forms.Panel();
            this.kbdSecondaryShortcut = new YuriyGuts.UnicodeKeyboard.UI.KeyboardShortcutEditor();
            this.lblSecondaryShortcut = new System.Windows.Forms.Label();
            this.pnlPrimaryShortcutSelectorPadding = new System.Windows.Forms.Panel();
            this.kbdPrimaryShortcut = new YuriyGuts.UnicodeKeyboard.UI.KeyboardShortcutEditor();
            this.lblPrimaryShortcut = new System.Windows.Forms.Label();
            this.pnlLanguageSelectorContainer = new System.Windows.Forms.Panel();
            this.pnlLanguageSelectorPadding = new System.Windows.Forms.Panel();
            this.pnlButtonContainer.SuspendLayout();
            this.pnlSettingsContainer.SuspendLayout();
            this.pnlShortcutSelectorContainer.SuspendLayout();
            this.pnlSecondaryShortcutSelectorPadding.SuspendLayout();
            this.pnlPrimaryShortcutSelectorPadding.SuspendLayout();
            this.pnlLanguageSelectorContainer.SuspendLayout();
            this.pnlLanguageSelectorPadding.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkMinimizeOnFocusLost
            // 
            resources.ApplyResources(this.chkMinimizeOnFocusLost, "chkMinimizeOnFocusLost");
            this.chkMinimizeOnFocusLost.Name = "chkMinimizeOnFocusLost";
            this.chkMinimizeOnFocusLost.UseVisualStyleBackColor = true;
            // 
            // chkExitOnClose
            // 
            resources.ApplyResources(this.chkExitOnClose, "chkExitOnClose");
            this.chkExitOnClose.Name = "chkExitOnClose";
            this.chkExitOnClose.UseVisualStyleBackColor = true;
            // 
            // chkLaunchOnWindowsStartup
            // 
            resources.ApplyResources(this.chkLaunchOnWindowsStartup, "chkLaunchOnWindowsStartup");
            this.chkLaunchOnWindowsStartup.Name = "chkLaunchOnWindowsStartup";
            this.chkLaunchOnWindowsStartup.UseVisualStyleBackColor = true;
            // 
            // lblInterfaceLanguage
            // 
            resources.ApplyResources(this.lblInterfaceLanguage, "lblInterfaceLanguage");
            this.lblInterfaceLanguage.Name = "lblInterfaceLanguage";
            // 
            // cmbInterfaceLanguage
            // 
            resources.ApplyResources(this.cmbInterfaceLanguage, "cmbInterfaceLanguage");
            this.cmbInterfaceLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbInterfaceLanguage.FormattingEnabled = true;
            this.cmbInterfaceLanguage.Name = "cmbInterfaceLanguage";
            // 
            // pnlButtonContainer
            // 
            this.pnlButtonContainer.Controls.Add(this.btnOK);
            this.pnlButtonContainer.Controls.Add(this.pnlButtonSpacer);
            this.pnlButtonContainer.Controls.Add(this.btnCancel);
            resources.ApplyResources(this.pnlButtonContainer, "pnlButtonContainer");
            this.pnlButtonContainer.Name = "pnlButtonContainer";
            // 
            // btnOK
            // 
            resources.ApplyResources(this.btnOK, "btnOK");
            this.btnOK.Name = "btnOK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // pnlButtonSpacer
            // 
            resources.ApplyResources(this.pnlButtonSpacer, "pnlButtonSpacer");
            this.pnlButtonSpacer.Name = "pnlButtonSpacer";
            // 
            // btnCancel
            // 
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // pnlBottomLine
            // 
            this.pnlBottomLine.BackColor = System.Drawing.Color.LightSteelBlue;
            resources.ApplyResources(this.pnlBottomLine, "pnlBottomLine");
            this.pnlBottomLine.Name = "pnlBottomLine";
            // 
            // pnlSettingsContainer
            // 
            this.pnlSettingsContainer.BackColor = System.Drawing.SystemColors.Control;
            this.pnlSettingsContainer.Controls.Add(this.chkLaunchOnWindowsStartup);
            this.pnlSettingsContainer.Controls.Add(this.chkExitOnClose);
            this.pnlSettingsContainer.Controls.Add(this.chkMinimizeOnFocusLost);
            this.pnlSettingsContainer.Controls.Add(this.chkShowIconInSystemTray);
            this.pnlSettingsContainer.Controls.Add(this.pnlShortcutSelectorContainer);
            this.pnlSettingsContainer.Controls.Add(this.pnlLanguageSelectorContainer);
            resources.ApplyResources(this.pnlSettingsContainer, "pnlSettingsContainer");
            this.pnlSettingsContainer.Name = "pnlSettingsContainer";
            // 
            // chkShowIconInSystemTray
            // 
            resources.ApplyResources(this.chkShowIconInSystemTray, "chkShowIconInSystemTray");
            this.chkShowIconInSystemTray.Name = "chkShowIconInSystemTray";
            this.chkShowIconInSystemTray.UseVisualStyleBackColor = true;
            // 
            // pnlShortcutSelectorContainer
            // 
            this.pnlShortcutSelectorContainer.Controls.Add(this.pnlSecondaryShortcutSelectorPadding);
            this.pnlShortcutSelectorContainer.Controls.Add(this.lblSecondaryShortcut);
            this.pnlShortcutSelectorContainer.Controls.Add(this.pnlPrimaryShortcutSelectorPadding);
            this.pnlShortcutSelectorContainer.Controls.Add(this.lblPrimaryShortcut);
            resources.ApplyResources(this.pnlShortcutSelectorContainer, "pnlShortcutSelectorContainer");
            this.pnlShortcutSelectorContainer.Name = "pnlShortcutSelectorContainer";
            // 
            // pnlSecondaryShortcutSelectorPadding
            // 
            this.pnlSecondaryShortcutSelectorPadding.Controls.Add(this.kbdSecondaryShortcut);
            resources.ApplyResources(this.pnlSecondaryShortcutSelectorPadding, "pnlSecondaryShortcutSelectorPadding");
            this.pnlSecondaryShortcutSelectorPadding.Name = "pnlSecondaryShortcutSelectorPadding";
            // 
            // kbdSecondaryShortcut
            // 
            this.kbdSecondaryShortcut.BackColor = System.Drawing.SystemColors.Window;
            this.kbdSecondaryShortcut.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.kbdSecondaryShortcut, "kbdSecondaryShortcut");
            this.kbdSecondaryShortcut.InvalidShortcutColor = System.Drawing.Color.Red;
            this.kbdSecondaryShortcut.Name = "kbdSecondaryShortcut";
            this.kbdSecondaryShortcut.ReadOnly = true;
            this.kbdSecondaryShortcut.ValidShortcutColor = System.Drawing.Color.Green;
            this.kbdSecondaryShortcut.ValidateShortcut += new System.EventHandler<YuriyGuts.UnicodeKeyboard.UI.KeyboardShortcutValidationEventArgs>(this.kbdSecondaryShortcut_ValidateShortcut);
            // 
            // lblSecondaryShortcut
            // 
            resources.ApplyResources(this.lblSecondaryShortcut, "lblSecondaryShortcut");
            this.lblSecondaryShortcut.Name = "lblSecondaryShortcut";
            // 
            // pnlPrimaryShortcutSelectorPadding
            // 
            this.pnlPrimaryShortcutSelectorPadding.Controls.Add(this.kbdPrimaryShortcut);
            resources.ApplyResources(this.pnlPrimaryShortcutSelectorPadding, "pnlPrimaryShortcutSelectorPadding");
            this.pnlPrimaryShortcutSelectorPadding.Name = "pnlPrimaryShortcutSelectorPadding";
            // 
            // kbdPrimaryShortcut
            // 
            this.kbdPrimaryShortcut.BackColor = System.Drawing.SystemColors.Window;
            this.kbdPrimaryShortcut.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.kbdPrimaryShortcut, "kbdPrimaryShortcut");
            this.kbdPrimaryShortcut.InvalidShortcutColor = System.Drawing.Color.Red;
            this.kbdPrimaryShortcut.Name = "kbdPrimaryShortcut";
            this.kbdPrimaryShortcut.ReadOnly = true;
            this.kbdPrimaryShortcut.ValidShortcutColor = System.Drawing.Color.Green;
            this.kbdPrimaryShortcut.ValidateShortcut += new System.EventHandler<YuriyGuts.UnicodeKeyboard.UI.KeyboardShortcutValidationEventArgs>(this.kbdPrimaryShortcut_ValidateShortcut);
            // 
            // lblPrimaryShortcut
            // 
            resources.ApplyResources(this.lblPrimaryShortcut, "lblPrimaryShortcut");
            this.lblPrimaryShortcut.Name = "lblPrimaryShortcut";
            // 
            // pnlLanguageSelectorContainer
            // 
            this.pnlLanguageSelectorContainer.Controls.Add(this.pnlLanguageSelectorPadding);
            this.pnlLanguageSelectorContainer.Controls.Add(this.lblInterfaceLanguage);
            resources.ApplyResources(this.pnlLanguageSelectorContainer, "pnlLanguageSelectorContainer");
            this.pnlLanguageSelectorContainer.Name = "pnlLanguageSelectorContainer";
            // 
            // pnlLanguageSelectorPadding
            // 
            this.pnlLanguageSelectorPadding.Controls.Add(this.cmbInterfaceLanguage);
            resources.ApplyResources(this.pnlLanguageSelectorPadding, "pnlLanguageSelectorPadding");
            this.pnlLanguageSelectorPadding.Name = "pnlLanguageSelectorPadding";
            // 
            // OptionsForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlSettingsContainer);
            this.Controls.Add(this.pnlBottomLine);
            this.Controls.Add(this.pnlButtonContainer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OptionsForm";
            this.ShowInTaskbar = false;
            this.pnlButtonContainer.ResumeLayout(false);
            this.pnlSettingsContainer.ResumeLayout(false);
            this.pnlSettingsContainer.PerformLayout();
            this.pnlShortcutSelectorContainer.ResumeLayout(false);
            this.pnlShortcutSelectorContainer.PerformLayout();
            this.pnlSecondaryShortcutSelectorPadding.ResumeLayout(false);
            this.pnlSecondaryShortcutSelectorPadding.PerformLayout();
            this.pnlPrimaryShortcutSelectorPadding.ResumeLayout(false);
            this.pnlPrimaryShortcutSelectorPadding.PerformLayout();
            this.pnlLanguageSelectorContainer.ResumeLayout(false);
            this.pnlLanguageSelectorContainer.PerformLayout();
            this.pnlLanguageSelectorPadding.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox chkMinimizeOnFocusLost;
        private System.Windows.Forms.CheckBox chkExitOnClose;
        private System.Windows.Forms.CheckBox chkLaunchOnWindowsStartup;
        private System.Windows.Forms.Label lblInterfaceLanguage;
        private System.Windows.Forms.ComboBox cmbInterfaceLanguage;
        private System.Windows.Forms.Panel pnlButtonContainer;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Panel pnlButtonSpacer;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel pnlBottomLine;
        private System.Windows.Forms.Panel pnlSettingsContainer;
        private System.Windows.Forms.Panel pnlLanguageSelectorContainer;
        private KeyboardShortcutEditor kbdPrimaryShortcut;
        private System.Windows.Forms.CheckBox chkShowIconInSystemTray;
        private System.Windows.Forms.Panel pnlShortcutSelectorContainer;
        private KeyboardShortcutEditor kbdSecondaryShortcut;
        private System.Windows.Forms.Label lblSecondaryShortcut;
        private System.Windows.Forms.Label lblPrimaryShortcut;
        private System.Windows.Forms.Panel pnlPrimaryShortcutSelectorPadding;
        private System.Windows.Forms.Panel pnlSecondaryShortcutSelectorPadding;
        private System.Windows.Forms.Panel pnlLanguageSelectorPadding;
    }
}