using System;
using System.Diagnostics;
using System.Windows.Forms;
using YuriyGuts.UnicodeKeyboard.ResourceWrappers;

namespace YuriyGuts.UnicodeKeyboard.UI
{
    public partial class AboutForm : Form
    {
        /// <summary>
        /// Initializes a new instance of AboutForm.
        /// </summary>
        public AboutForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Shows the About form with the specified owner window.
        /// </summary>
        /// <param name="owner">Owner window.</param>
        public static void Execute(IWin32Window owner)
        {
            using (AboutForm aboutForm = new AboutForm())
            {
                aboutForm.ShowDialog(owner);
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            InitializeMUI();
        }

        private void InitializeMUI()
        {
            lblApplicationName.Text = LocalizationHelper.GetGlobalResource("ApplicationName");
            lblCopyright.Text = LocalizationHelper.GetGlobalResource("Copyright");
            lblVersion.Text += @" " + LocalizationHelper.GetGlobalResource("ApplicationVersion");
        }

        private void OpenURLFromStringResource(string resourceKey)
        {
            string url = LocalizationHelper.GetResource(this, resourceKey);
            if (!string.IsNullOrEmpty(url))
            {
                Process.Start(url);
            }
        }

        private void lnkUserActivityMonitor_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenURLFromStringResource("UserActivityMonitorURL");
        }

        private void lnkSilkIcons_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenURLFromStringResource("SilkIconsURL");
        }

        private void lnkUnicodeCharacterDatabase_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenURLFromStringResource("UnicodeCharacterDatabaseURL");
        }
    }
}
