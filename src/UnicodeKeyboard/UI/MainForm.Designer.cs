using YuriyGuts.UnicodeKeyboard.ResourceWrappers;

namespace YuriyGuts.UnicodeKeyboard.UI
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            SingleAssemblyComponentResourceManager resources = new SingleAssemblyComponentResourceManager(typeof(MainForm));
            this.trayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.cmsTrayIconMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmiTrayUsageHint = new System.Windows.Forms.ToolStripMenuItem();
            this.cmiTraySeparator = new System.Windows.Forms.ToolStripSeparator();
            this.cmiTrayOptions = new System.Windows.Forms.ToolStripMenuItem();
            this.cmiTrayExit = new System.Windows.Forms.ToolStripMenuItem();
            this.txtCharSearch = new System.Windows.Forms.TextBox();
            this.lblHeader = new System.Windows.Forms.Label();
            this.lblTargetWindow = new System.Windows.Forms.Label();
            this.lblTargetWindowTitle = new System.Windows.Forms.Label();
            this.tblFavoriteGlyphs = new System.Windows.Forms.TableLayoutPanel();
            this.lblFavoriteGlyph9 = new System.Windows.Forms.Label();
            this.lblFavoriteGlyph8 = new System.Windows.Forms.Label();
            this.lblFavoriteGlyph7 = new System.Windows.Forms.Label();
            this.lblFavoriteGlyph6 = new System.Windows.Forms.Label();
            this.lblFavoriteGlyph5 = new System.Windows.Forms.Label();
            this.lblFavoriteGlyph4 = new System.Windows.Forms.Label();
            this.lblFavoriteGlyph3 = new System.Windows.Forms.Label();
            this.lblFavoriteGlyph2 = new System.Windows.Forms.Label();
            this.lblFavoriteGlyph1 = new System.Windows.Forms.Label();
            this.lblFavoriteGlyph0 = new System.Windows.Forms.Label();
            this.lblFavorites = new System.Windows.Forms.Label();
            this.tblFavoriteIndexes = new System.Windows.Forms.TableLayoutPanel();
            this.lblFavoriteIndex9 = new System.Windows.Forms.Label();
            this.lblFavoriteIndex8 = new System.Windows.Forms.Label();
            this.lblFavoriteIndex7 = new System.Windows.Forms.Label();
            this.lblFavoriteIndex6 = new System.Windows.Forms.Label();
            this.lblFavoriteIndex5 = new System.Windows.Forms.Label();
            this.lblFavoriteIndex4 = new System.Windows.Forms.Label();
            this.lblFavoriteIndex3 = new System.Windows.Forms.Label();
            this.lblFavoriteIndex2 = new System.Windows.Forms.Label();
            this.lblFavoriteIndex1 = new System.Windows.Forms.Label();
            this.lblFavoriteIndex0 = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.btnOptions = new System.Windows.Forms.Button();
            this.cmsOptions = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmiOptions = new System.Windows.Forms.ToolStripMenuItem();
            this.cmiWindowsCharMap = new System.Windows.Forms.ToolStripMenuItem();
            this.cmiOptionsSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.cmiAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.cmiExit = new System.Windows.Forms.ToolStripMenuItem();
            this.windowFinder = new YuriyGuts.UnicodeKeyboard.UI.WindowFinder();
            this.tmrSearchPopupTimeout = new System.Windows.Forms.Timer(this.components);
            this.cmsTrayIconMenu.SuspendLayout();
            this.tblFavoriteGlyphs.SuspendLayout();
            this.tblFavoriteIndexes.SuspendLayout();
            this.cmsOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // trayIcon
            // 
            this.trayIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            resources.ApplyResources(this.trayIcon, "trayIcon");
            this.trayIcon.ContextMenuStrip = this.cmsTrayIconMenu;
            // 
            // cmsTrayIconMenu
            // 
            resources.ApplyResources(this.cmsTrayIconMenu, "cmsTrayIconMenu");
            this.cmsTrayIconMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmiTrayUsageHint,
            this.cmiTraySeparator,
            this.cmiTrayOptions,
            this.cmiTrayExit});
            this.cmsTrayIconMenu.Name = "cmsTrayIconMenu";
            this.toolTip.SetToolTip(this.cmsTrayIconMenu, resources.GetString("cmsTrayIconMenu.ToolTip"));
            // 
            // cmiTrayUsageHint
            // 
            resources.ApplyResources(this.cmiTrayUsageHint, "cmiTrayUsageHint");
            this.cmiTrayUsageHint.Name = "cmiTrayUsageHint";
            // 
            // cmiTraySeparator
            // 
            resources.ApplyResources(this.cmiTraySeparator, "cmiTraySeparator");
            this.cmiTraySeparator.Name = "cmiTraySeparator";
            // 
            // cmiTrayOptions
            // 
            resources.ApplyResources(this.cmiTrayOptions, "cmiTrayOptions");
            this.cmiTrayOptions.Name = "cmiTrayOptions";
            this.cmiTrayOptions.Click += new System.EventHandler(this.cmiTrayOptions_Click);
            // 
            // cmiTrayExit
            // 
            resources.ApplyResources(this.cmiTrayExit, "cmiTrayExit");
            this.cmiTrayExit.Name = "cmiTrayExit";
            this.cmiTrayExit.Click += new System.EventHandler(this.cmiTrayExit_Click);
            // 
            // txtCharSearch
            // 
            resources.ApplyResources(this.txtCharSearch, "txtCharSearch");
            this.txtCharSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCharSearch.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCharSearch.Name = "txtCharSearch";
            this.toolTip.SetToolTip(this.txtCharSearch, resources.GetString("txtCharSearch.ToolTip"));
            this.txtCharSearch.TextChanged += new System.EventHandler(this.txtCharCode_TextChanged);
            this.txtCharSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCharCode_KeyDown);
            this.txtCharSearch.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.FormMain_PreviewKeyDown);
            // 
            // lblHeader
            // 
            resources.ApplyResources(this.lblHeader, "lblHeader");
            this.lblHeader.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblHeader.Name = "lblHeader";
            this.toolTip.SetToolTip(this.lblHeader, resources.GetString("lblHeader.ToolTip"));
            // 
            // lblTargetWindow
            // 
            resources.ApplyResources(this.lblTargetWindow, "lblTargetWindow");
            this.lblTargetWindow.Name = "lblTargetWindow";
            this.toolTip.SetToolTip(this.lblTargetWindow, resources.GetString("lblTargetWindow.ToolTip"));
            // 
            // lblTargetWindowTitle
            // 
            resources.ApplyResources(this.lblTargetWindowTitle, "lblTargetWindowTitle");
            this.lblTargetWindowTitle.AutoEllipsis = true;
            this.lblTargetWindowTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTargetWindowTitle.ForeColor = System.Drawing.Color.Gray;
            this.lblTargetWindowTitle.Name = "lblTargetWindowTitle";
            this.toolTip.SetToolTip(this.lblTargetWindowTitle, resources.GetString("lblTargetWindowTitle.ToolTip"));
            // 
            // tblFavoriteGlyphs
            // 
            resources.ApplyResources(this.tblFavoriteGlyphs, "tblFavoriteGlyphs");
            this.tblFavoriteGlyphs.BackColor = System.Drawing.SystemColors.Window;
            this.tblFavoriteGlyphs.Controls.Add(this.lblFavoriteGlyph9, 9, 0);
            this.tblFavoriteGlyphs.Controls.Add(this.lblFavoriteGlyph8, 8, 0);
            this.tblFavoriteGlyphs.Controls.Add(this.lblFavoriteGlyph7, 7, 0);
            this.tblFavoriteGlyphs.Controls.Add(this.lblFavoriteGlyph6, 6, 0);
            this.tblFavoriteGlyphs.Controls.Add(this.lblFavoriteGlyph5, 5, 0);
            this.tblFavoriteGlyphs.Controls.Add(this.lblFavoriteGlyph4, 4, 0);
            this.tblFavoriteGlyphs.Controls.Add(this.lblFavoriteGlyph3, 3, 0);
            this.tblFavoriteGlyphs.Controls.Add(this.lblFavoriteGlyph2, 2, 0);
            this.tblFavoriteGlyphs.Controls.Add(this.lblFavoriteGlyph1, 1, 0);
            this.tblFavoriteGlyphs.Controls.Add(this.lblFavoriteGlyph0, 0, 0);
            this.tblFavoriteGlyphs.Name = "tblFavoriteGlyphs";
            this.toolTip.SetToolTip(this.tblFavoriteGlyphs, resources.GetString("tblFavoriteGlyphs.ToolTip"));
            // 
            // lblFavoriteGlyph9
            // 
            resources.ApplyResources(this.lblFavoriteGlyph9, "lblFavoriteGlyph9");
            this.lblFavoriteGlyph9.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblFavoriteGlyph9.Name = "lblFavoriteGlyph9";
            this.toolTip.SetToolTip(this.lblFavoriteGlyph9, resources.GetString("lblFavoriteGlyph9.ToolTip"));
            this.lblFavoriteGlyph9.Click += new System.EventHandler(this.lblFavoriteGlyph_Click);
            // 
            // lblFavoriteGlyph8
            // 
            resources.ApplyResources(this.lblFavoriteGlyph8, "lblFavoriteGlyph8");
            this.lblFavoriteGlyph8.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblFavoriteGlyph8.Name = "lblFavoriteGlyph8";
            this.toolTip.SetToolTip(this.lblFavoriteGlyph8, resources.GetString("lblFavoriteGlyph8.ToolTip"));
            this.lblFavoriteGlyph8.Click += new System.EventHandler(this.lblFavoriteGlyph_Click);
            // 
            // lblFavoriteGlyph7
            // 
            resources.ApplyResources(this.lblFavoriteGlyph7, "lblFavoriteGlyph7");
            this.lblFavoriteGlyph7.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblFavoriteGlyph7.Name = "lblFavoriteGlyph7";
            this.toolTip.SetToolTip(this.lblFavoriteGlyph7, resources.GetString("lblFavoriteGlyph7.ToolTip"));
            this.lblFavoriteGlyph7.Click += new System.EventHandler(this.lblFavoriteGlyph_Click);
            // 
            // lblFavoriteGlyph6
            // 
            resources.ApplyResources(this.lblFavoriteGlyph6, "lblFavoriteGlyph6");
            this.lblFavoriteGlyph6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblFavoriteGlyph6.Name = "lblFavoriteGlyph6";
            this.toolTip.SetToolTip(this.lblFavoriteGlyph6, resources.GetString("lblFavoriteGlyph6.ToolTip"));
            this.lblFavoriteGlyph6.Click += new System.EventHandler(this.lblFavoriteGlyph_Click);
            // 
            // lblFavoriteGlyph5
            // 
            resources.ApplyResources(this.lblFavoriteGlyph5, "lblFavoriteGlyph5");
            this.lblFavoriteGlyph5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblFavoriteGlyph5.Name = "lblFavoriteGlyph5";
            this.toolTip.SetToolTip(this.lblFavoriteGlyph5, resources.GetString("lblFavoriteGlyph5.ToolTip"));
            this.lblFavoriteGlyph5.Click += new System.EventHandler(this.lblFavoriteGlyph_Click);
            // 
            // lblFavoriteGlyph4
            // 
            resources.ApplyResources(this.lblFavoriteGlyph4, "lblFavoriteGlyph4");
            this.lblFavoriteGlyph4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblFavoriteGlyph4.Name = "lblFavoriteGlyph4";
            this.toolTip.SetToolTip(this.lblFavoriteGlyph4, resources.GetString("lblFavoriteGlyph4.ToolTip"));
            this.lblFavoriteGlyph4.Click += new System.EventHandler(this.lblFavoriteGlyph_Click);
            // 
            // lblFavoriteGlyph3
            // 
            resources.ApplyResources(this.lblFavoriteGlyph3, "lblFavoriteGlyph3");
            this.lblFavoriteGlyph3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblFavoriteGlyph3.Name = "lblFavoriteGlyph3";
            this.toolTip.SetToolTip(this.lblFavoriteGlyph3, resources.GetString("lblFavoriteGlyph3.ToolTip"));
            this.lblFavoriteGlyph3.Click += new System.EventHandler(this.lblFavoriteGlyph_Click);
            // 
            // lblFavoriteGlyph2
            // 
            resources.ApplyResources(this.lblFavoriteGlyph2, "lblFavoriteGlyph2");
            this.lblFavoriteGlyph2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblFavoriteGlyph2.Name = "lblFavoriteGlyph2";
            this.toolTip.SetToolTip(this.lblFavoriteGlyph2, resources.GetString("lblFavoriteGlyph2.ToolTip"));
            this.lblFavoriteGlyph2.Click += new System.EventHandler(this.lblFavoriteGlyph_Click);
            // 
            // lblFavoriteGlyph1
            // 
            resources.ApplyResources(this.lblFavoriteGlyph1, "lblFavoriteGlyph1");
            this.lblFavoriteGlyph1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblFavoriteGlyph1.Name = "lblFavoriteGlyph1";
            this.toolTip.SetToolTip(this.lblFavoriteGlyph1, resources.GetString("lblFavoriteGlyph1.ToolTip"));
            this.lblFavoriteGlyph1.Click += new System.EventHandler(this.lblFavoriteGlyph_Click);
            // 
            // lblFavoriteGlyph0
            // 
            resources.ApplyResources(this.lblFavoriteGlyph0, "lblFavoriteGlyph0");
            this.lblFavoriteGlyph0.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblFavoriteGlyph0.Name = "lblFavoriteGlyph0";
            this.toolTip.SetToolTip(this.lblFavoriteGlyph0, resources.GetString("lblFavoriteGlyph0.ToolTip"));
            this.lblFavoriteGlyph0.Click += new System.EventHandler(this.lblFavoriteGlyph_Click);
            // 
            // lblFavorites
            // 
            resources.ApplyResources(this.lblFavorites, "lblFavorites");
            this.lblFavorites.AutoEllipsis = true;
            this.lblFavorites.Name = "lblFavorites";
            this.toolTip.SetToolTip(this.lblFavorites, resources.GetString("lblFavorites.ToolTip"));
            // 
            // tblFavoriteIndexes
            // 
            resources.ApplyResources(this.tblFavoriteIndexes, "tblFavoriteIndexes");
            this.tblFavoriteIndexes.Controls.Add(this.lblFavoriteIndex9, 9, 0);
            this.tblFavoriteIndexes.Controls.Add(this.lblFavoriteIndex8, 8, 0);
            this.tblFavoriteIndexes.Controls.Add(this.lblFavoriteIndex7, 7, 0);
            this.tblFavoriteIndexes.Controls.Add(this.lblFavoriteIndex6, 6, 0);
            this.tblFavoriteIndexes.Controls.Add(this.lblFavoriteIndex5, 5, 0);
            this.tblFavoriteIndexes.Controls.Add(this.lblFavoriteIndex4, 4, 0);
            this.tblFavoriteIndexes.Controls.Add(this.lblFavoriteIndex3, 3, 0);
            this.tblFavoriteIndexes.Controls.Add(this.lblFavoriteIndex2, 2, 0);
            this.tblFavoriteIndexes.Controls.Add(this.lblFavoriteIndex1, 1, 0);
            this.tblFavoriteIndexes.Controls.Add(this.lblFavoriteIndex0, 0, 0);
            this.tblFavoriteIndexes.Name = "tblFavoriteIndexes";
            this.toolTip.SetToolTip(this.tblFavoriteIndexes, resources.GetString("tblFavoriteIndexes.ToolTip"));
            // 
            // lblFavoriteIndex9
            // 
            resources.ApplyResources(this.lblFavoriteIndex9, "lblFavoriteIndex9");
            this.lblFavoriteIndex9.Name = "lblFavoriteIndex9";
            this.toolTip.SetToolTip(this.lblFavoriteIndex9, resources.GetString("lblFavoriteIndex9.ToolTip"));
            // 
            // lblFavoriteIndex8
            // 
            resources.ApplyResources(this.lblFavoriteIndex8, "lblFavoriteIndex8");
            this.lblFavoriteIndex8.Name = "lblFavoriteIndex8";
            this.toolTip.SetToolTip(this.lblFavoriteIndex8, resources.GetString("lblFavoriteIndex8.ToolTip"));
            // 
            // lblFavoriteIndex7
            // 
            resources.ApplyResources(this.lblFavoriteIndex7, "lblFavoriteIndex7");
            this.lblFavoriteIndex7.Name = "lblFavoriteIndex7";
            this.toolTip.SetToolTip(this.lblFavoriteIndex7, resources.GetString("lblFavoriteIndex7.ToolTip"));
            // 
            // lblFavoriteIndex6
            // 
            resources.ApplyResources(this.lblFavoriteIndex6, "lblFavoriteIndex6");
            this.lblFavoriteIndex6.Name = "lblFavoriteIndex6";
            this.toolTip.SetToolTip(this.lblFavoriteIndex6, resources.GetString("lblFavoriteIndex6.ToolTip"));
            // 
            // lblFavoriteIndex5
            // 
            resources.ApplyResources(this.lblFavoriteIndex5, "lblFavoriteIndex5");
            this.lblFavoriteIndex5.Name = "lblFavoriteIndex5";
            this.toolTip.SetToolTip(this.lblFavoriteIndex5, resources.GetString("lblFavoriteIndex5.ToolTip"));
            // 
            // lblFavoriteIndex4
            // 
            resources.ApplyResources(this.lblFavoriteIndex4, "lblFavoriteIndex4");
            this.lblFavoriteIndex4.Name = "lblFavoriteIndex4";
            this.toolTip.SetToolTip(this.lblFavoriteIndex4, resources.GetString("lblFavoriteIndex4.ToolTip"));
            // 
            // lblFavoriteIndex3
            // 
            resources.ApplyResources(this.lblFavoriteIndex3, "lblFavoriteIndex3");
            this.lblFavoriteIndex3.Name = "lblFavoriteIndex3";
            this.toolTip.SetToolTip(this.lblFavoriteIndex3, resources.GetString("lblFavoriteIndex3.ToolTip"));
            // 
            // lblFavoriteIndex2
            // 
            resources.ApplyResources(this.lblFavoriteIndex2, "lblFavoriteIndex2");
            this.lblFavoriteIndex2.Name = "lblFavoriteIndex2";
            this.toolTip.SetToolTip(this.lblFavoriteIndex2, resources.GetString("lblFavoriteIndex2.ToolTip"));
            // 
            // lblFavoriteIndex1
            // 
            resources.ApplyResources(this.lblFavoriteIndex1, "lblFavoriteIndex1");
            this.lblFavoriteIndex1.Name = "lblFavoriteIndex1";
            this.toolTip.SetToolTip(this.lblFavoriteIndex1, resources.GetString("lblFavoriteIndex1.ToolTip"));
            // 
            // lblFavoriteIndex0
            // 
            resources.ApplyResources(this.lblFavoriteIndex0, "lblFavoriteIndex0");
            this.lblFavoriteIndex0.Name = "lblFavoriteIndex0";
            this.toolTip.SetToolTip(this.lblFavoriteIndex0, resources.GetString("lblFavoriteIndex0.ToolTip"));
            // 
            // btnOptions
            // 
            resources.ApplyResources(this.btnOptions, "btnOptions");
            this.btnOptions.Image = global::YuriyGuts.UnicodeKeyboard.Properties.Resources.Wrench;
            this.btnOptions.Name = "btnOptions";
            this.toolTip.SetToolTip(this.btnOptions, resources.GetString("btnOptions.ToolTip"));
            this.btnOptions.UseVisualStyleBackColor = true;
            this.btnOptions.Click += new System.EventHandler(this.btnOptions_Click);
            // 
            // cmsOptions
            // 
            resources.ApplyResources(this.cmsOptions, "cmsOptions");
            this.cmsOptions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmiOptions,
            this.cmiWindowsCharMap,
            this.cmiOptionsSeparator,
            this.cmiAbout,
            this.cmiExit});
            this.cmsOptions.Name = "cmsOptions";
            this.toolTip.SetToolTip(this.cmsOptions, resources.GetString("cmsOptions.ToolTip"));
            // 
            // cmiOptions
            // 
            resources.ApplyResources(this.cmiOptions, "cmiOptions");
            this.cmiOptions.Name = "cmiOptions";
            this.cmiOptions.Click += new System.EventHandler(this.cmiOptions_Click);
            // 
            // cmiWindowsCharMap
            // 
            resources.ApplyResources(this.cmiWindowsCharMap, "cmiWindowsCharMap");
            this.cmiWindowsCharMap.Name = "cmiWindowsCharMap";
            this.cmiWindowsCharMap.Click += new System.EventHandler(this.cmiWindowsCharMap_Click);
            // 
            // cmiOptionsSeparator
            // 
            resources.ApplyResources(this.cmiOptionsSeparator, "cmiOptionsSeparator");
            this.cmiOptionsSeparator.Name = "cmiOptionsSeparator";
            // 
            // cmiAbout
            // 
            resources.ApplyResources(this.cmiAbout, "cmiAbout");
            this.cmiAbout.Name = "cmiAbout";
            this.cmiAbout.Click += new System.EventHandler(this.cmiAbout_Click);
            // 
            // cmiExit
            // 
            resources.ApplyResources(this.cmiExit, "cmiExit");
            this.cmiExit.Name = "cmiExit";
            this.cmiExit.Click += new System.EventHandler(this.cmiExit_Click);
            // 
            // windowFinder
            // 
            resources.ApplyResources(this.windowFinder, "windowFinder");
            this.windowFinder.BackColor = System.Drawing.SystemColors.Control;
            this.windowFinder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.windowFinder.Name = "windowFinder";
            this.toolTip.SetToolTip(this.windowFinder, resources.GetString("windowFinder.ToolTip"));
            this.windowFinder.ActiveWindowChanged += new System.EventHandler(this.windowFinder_ActiveWindowChanged);
            this.windowFinder.ActiveWindowSelected += new System.EventHandler(this.windowFinder_ActiveWindowSelected);
            // 
            // tmrSearchPopupTimeout
            // 
            this.tmrSearchPopupTimeout.Interval = 500;
            this.tmrSearchPopupTimeout.Tick += new System.EventHandler(this.tmrSearchPopupTimeout_Tick);
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.windowFinder);
            this.Controls.Add(this.btnOptions);
            this.Controls.Add(this.tblFavoriteIndexes);
            this.Controls.Add(this.lblFavorites);
            this.Controls.Add(this.tblFavoriteGlyphs);
            this.Controls.Add(this.lblTargetWindowTitle);
            this.Controls.Add(this.lblTargetWindow);
            this.Controls.Add(this.lblHeader);
            this.Controls.Add(this.txtCharSearch);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.ShowInTaskbar = false;
            this.toolTip.SetToolTip(this, resources.GetString("$this.ToolTip"));
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Activated += new System.EventHandler(this.FormMain_Activated);
            this.Deactivate += new System.EventHandler(this.FormMain_Deactivate);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMain_FormClosed);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.Shown += new System.EventHandler(this.FormMain_Shown);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.FormMain_PreviewKeyDown);
            this.Resize += new System.EventHandler(this.FormMain_Resize);
            this.cmsTrayIconMenu.ResumeLayout(false);
            this.tblFavoriteGlyphs.ResumeLayout(false);
            this.tblFavoriteGlyphs.PerformLayout();
            this.tblFavoriteIndexes.ResumeLayout(false);
            this.tblFavoriteIndexes.PerformLayout();
            this.cmsOptions.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon trayIcon;
        private System.Windows.Forms.TextBox txtCharSearch;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Label lblTargetWindow;
        private System.Windows.Forms.Label lblTargetWindowTitle;
        private System.Windows.Forms.TableLayoutPanel tblFavoriteGlyphs;
        private System.Windows.Forms.Label lblFavoriteGlyph6;
        private System.Windows.Forms.Label lblFavoriteGlyph9;
        private System.Windows.Forms.Label lblFavoriteGlyph8;
        private System.Windows.Forms.Label lblFavoriteGlyph7;
        private System.Windows.Forms.Label lblFavoriteGlyph5;
        private System.Windows.Forms.Label lblFavoriteGlyph4;
        private System.Windows.Forms.Label lblFavoriteGlyph3;
        private System.Windows.Forms.Label lblFavoriteGlyph2;
        private System.Windows.Forms.Label lblFavoriteGlyph1;
        private System.Windows.Forms.Label lblFavoriteGlyph0;
        private System.Windows.Forms.Label lblFavorites;
        private System.Windows.Forms.TableLayoutPanel tblFavoriteIndexes;
        private System.Windows.Forms.Label lblFavoriteIndex8;
        private System.Windows.Forms.Label lblFavoriteIndex7;
        private System.Windows.Forms.Label lblFavoriteIndex6;
        private System.Windows.Forms.Label lblFavoriteIndex5;
        private System.Windows.Forms.Label lblFavoriteIndex4;
        private System.Windows.Forms.Label lblFavoriteIndex3;
        private System.Windows.Forms.Label lblFavoriteIndex2;
        private System.Windows.Forms.Label lblFavoriteIndex1;
        private System.Windows.Forms.Label lblFavoriteIndex0;
        private System.Windows.Forms.Label lblFavoriteIndex9;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Timer tmrSearchPopupTimeout;
        private System.Windows.Forms.ContextMenuStrip cmsTrayIconMenu;
        private System.Windows.Forms.ToolStripMenuItem cmiTrayExit;
        private System.Windows.Forms.ToolStripMenuItem cmiTrayUsageHint;
        private System.Windows.Forms.ToolStripSeparator cmiTraySeparator;
        private System.Windows.Forms.ToolStripMenuItem cmiTrayOptions;
        private System.Windows.Forms.Button btnOptions;
        private WindowFinder windowFinder;
        private System.Windows.Forms.ContextMenuStrip cmsOptions;
        private System.Windows.Forms.ToolStripMenuItem cmiOptions;
        private System.Windows.Forms.ToolStripMenuItem cmiWindowsCharMap;
        private System.Windows.Forms.ToolStripSeparator cmiOptionsSeparator;
        private System.Windows.Forms.ToolStripMenuItem cmiAbout;
        private System.Windows.Forms.ToolStripMenuItem cmiExit;
    }
}

