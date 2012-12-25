using YuriyGuts.UnicodeKeyboard.ResourceWrappers;

namespace YuriyGuts.UnicodeKeyboard.UI
{
    partial class AboutForm
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
            SingleAssemblyComponentResourceManager resources = new SingleAssemblyComponentResourceManager(typeof(AboutForm));
            this.lblApplicationName = new System.Windows.Forms.Label();
            this.lblVersion = new System.Windows.Forms.Label();
            this.lblCopyright = new System.Windows.Forms.Label();
            this.lblThirdPartyLibraryNotice = new System.Windows.Forms.Label();
            this.lnkUserActivityMonitor = new System.Windows.Forms.LinkLabel();
            this.pnlLine = new System.Windows.Forms.Panel();
            this.lnkSilkIcons = new System.Windows.Forms.LinkLabel();
            this.lnkUnicodeCharacterDatabase = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // lblApplicationName
            // 
            resources.ApplyResources(this.lblApplicationName, "lblApplicationName");
            this.lblApplicationName.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblApplicationName.Name = "lblApplicationName";
            // 
            // lblVersion
            // 
            resources.ApplyResources(this.lblVersion, "lblVersion");
            this.lblVersion.ForeColor = System.Drawing.Color.Black;
            this.lblVersion.Name = "lblVersion";
            // 
            // lblCopyright
            // 
            resources.ApplyResources(this.lblCopyright, "lblCopyright");
            this.lblCopyright.ForeColor = System.Drawing.Color.Black;
            this.lblCopyright.Name = "lblCopyright";
            // 
            // lblThirdPartyLibraryNotice
            // 
            resources.ApplyResources(this.lblThirdPartyLibraryNotice, "lblThirdPartyLibraryNotice");
            this.lblThirdPartyLibraryNotice.ForeColor = System.Drawing.Color.Black;
            this.lblThirdPartyLibraryNotice.Name = "lblThirdPartyLibraryNotice";
            // 
            // lnkUserActivityMonitor
            // 
            this.lnkUserActivityMonitor.ActiveLinkColor = System.Drawing.Color.Blue;
            resources.ApplyResources(this.lnkUserActivityMonitor, "lnkUserActivityMonitor");
            this.lnkUserActivityMonitor.LinkColor = System.Drawing.Color.SteelBlue;
            this.lnkUserActivityMonitor.Name = "lnkUserActivityMonitor";
            this.lnkUserActivityMonitor.TabStop = true;
            this.lnkUserActivityMonitor.VisitedLinkColor = System.Drawing.Color.SteelBlue;
            this.lnkUserActivityMonitor.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkUserActivityMonitor_LinkClicked);
            // 
            // pnlLine
            // 
            this.pnlLine.BackColor = System.Drawing.Color.LightSteelBlue;
            resources.ApplyResources(this.pnlLine, "pnlLine");
            this.pnlLine.Name = "pnlLine";
            // 
            // lnkSilkIcons
            // 
            this.lnkSilkIcons.ActiveLinkColor = System.Drawing.Color.Blue;
            resources.ApplyResources(this.lnkSilkIcons, "lnkSilkIcons");
            this.lnkSilkIcons.LinkColor = System.Drawing.Color.SteelBlue;
            this.lnkSilkIcons.Name = "lnkSilkIcons";
            this.lnkSilkIcons.TabStop = true;
            this.lnkSilkIcons.VisitedLinkColor = System.Drawing.Color.SteelBlue;
            this.lnkSilkIcons.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkSilkIcons_LinkClicked);
            // 
            // lnkUnicodeCharacterDatabase
            // 
            this.lnkUnicodeCharacterDatabase.ActiveLinkColor = System.Drawing.Color.Blue;
            resources.ApplyResources(this.lnkUnicodeCharacterDatabase, "lnkUnicodeCharacterDatabase");
            this.lnkUnicodeCharacterDatabase.LinkColor = System.Drawing.Color.SteelBlue;
            this.lnkUnicodeCharacterDatabase.Name = "lnkUnicodeCharacterDatabase";
            this.lnkUnicodeCharacterDatabase.TabStop = true;
            this.lnkUnicodeCharacterDatabase.VisitedLinkColor = System.Drawing.Color.SteelBlue;
            this.lnkUnicodeCharacterDatabase.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkUnicodeCharacterDatabase_LinkClicked);
            // 
            // AboutForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lnkUnicodeCharacterDatabase);
            this.Controls.Add(this.lnkSilkIcons);
            this.Controls.Add(this.lnkUserActivityMonitor);
            this.Controls.Add(this.lblThirdPartyLibraryNotice);
            this.Controls.Add(this.pnlLine);
            this.Controls.Add(this.lblCopyright);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.lblApplicationName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblApplicationName;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Label lblCopyright;
        private System.Windows.Forms.Label lblThirdPartyLibraryNotice;
        private System.Windows.Forms.LinkLabel lnkUserActivityMonitor;
        private System.Windows.Forms.Panel pnlLine;
        private System.Windows.Forms.LinkLabel lnkSilkIcons;
        private System.Windows.Forms.LinkLabel lnkUnicodeCharacterDatabase;
    }
}