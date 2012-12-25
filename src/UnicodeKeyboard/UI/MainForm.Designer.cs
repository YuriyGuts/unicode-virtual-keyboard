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
            this.pbxAppMainImage = new System.Windows.Forms.PictureBox();
            this.txtCharCode = new System.Windows.Forms.TextBox();
            this.lblHeader = new System.Windows.Forms.Label();
            this.btnAccept = new System.Windows.Forms.Button();
            this.rbHexMode = new System.Windows.Forms.RadioButton();
            this.rbDecimalMode = new System.Windows.Forms.RadioButton();
            this.lblTargetWindow = new System.Windows.Forms.Label();
            this.btnAddToFavorites = new System.Windows.Forms.Button();
            this.btnCopy = new System.Windows.Forms.Button();
            this.lblSenderWindowTitle = new System.Windows.Forms.Label();
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
            this.lnkCharmap = new System.Windows.Forms.LinkLabel();
            this.lblCharDescription = new System.Windows.Forms.Label();
            this.lnkAbout = new System.Windows.Forms.LinkLabel();
            this.rbTextMode = new System.Windows.Forms.RadioButton();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.lnkOptions = new System.Windows.Forms.LinkLabel();
            this.lblCharPreview = new System.Windows.Forms.Label();
            this.lnkExit = new System.Windows.Forms.LinkLabel();
            this.tmrCharacterPreview = new System.Windows.Forms.Timer(this.components);
            this.cmsTrayIconMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxAppMainImage)).BeginInit();
            this.tblFavoriteGlyphs.SuspendLayout();
            this.tblFavoriteIndexes.SuspendLayout();
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
            // pbxAppMainImage
            // 
            resources.ApplyResources(this.pbxAppMainImage, "pbxAppMainImage");
            this.pbxAppMainImage.BackgroundImage = global::YuriyGuts.UnicodeKeyboard.Properties.Resources.KeyboardLarge;
            this.pbxAppMainImage.Name = "pbxAppMainImage";
            this.pbxAppMainImage.TabStop = false;
            this.toolTip.SetToolTip(this.pbxAppMainImage, resources.GetString("pbxAppMainImage.ToolTip"));
            // 
            // txtCharCode
            // 
            resources.ApplyResources(this.txtCharCode, "txtCharCode");
            this.txtCharCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCharCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCharCode.Name = "txtCharCode";
            this.toolTip.SetToolTip(this.txtCharCode, resources.GetString("txtCharCode.ToolTip"));
            this.txtCharCode.TextChanged += new System.EventHandler(this.txtCharCode_TextChanged);
            this.txtCharCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCharCode_KeyDown);
            this.txtCharCode.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.FormMain_PreviewKeyDown);
            // 
            // lblHeader
            // 
            resources.ApplyResources(this.lblHeader, "lblHeader");
            this.lblHeader.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblHeader.Name = "lblHeader";
            this.toolTip.SetToolTip(this.lblHeader, resources.GetString("lblHeader.ToolTip"));
            // 
            // btnAccept
            // 
            resources.ApplyResources(this.btnAccept, "btnAccept");
            this.btnAccept.Image = global::YuriyGuts.UnicodeKeyboard.Properties.Resources.CharAccept;
            this.btnAccept.Name = "btnAccept";
            this.toolTip.SetToolTip(this.btnAccept, resources.GetString("btnAccept.ToolTip"));
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            this.btnAccept.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.FormMain_PreviewKeyDown);
            // 
            // rbHexMode
            // 
            resources.ApplyResources(this.rbHexMode, "rbHexMode");
            this.rbHexMode.Checked = true;
            this.rbHexMode.Name = "rbHexMode";
            this.rbHexMode.TabStop = true;
            this.toolTip.SetToolTip(this.rbHexMode, resources.GetString("rbHexMode.ToolTip"));
            this.rbHexMode.UseVisualStyleBackColor = true;
            this.rbHexMode.CheckedChanged += new System.EventHandler(this.rbHexMode_CheckedChanged);
            this.rbHexMode.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.FormMain_PreviewKeyDown);
            // 
            // rbDecimalMode
            // 
            resources.ApplyResources(this.rbDecimalMode, "rbDecimalMode");
            this.rbDecimalMode.Name = "rbDecimalMode";
            this.toolTip.SetToolTip(this.rbDecimalMode, resources.GetString("rbDecimalMode.ToolTip"));
            this.rbDecimalMode.UseVisualStyleBackColor = true;
            this.rbDecimalMode.CheckedChanged += new System.EventHandler(this.rbDecimalMode_CheckedChanged);
            this.rbDecimalMode.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.FormMain_PreviewKeyDown);
            // 
            // lblTargetWindow
            // 
            resources.ApplyResources(this.lblTargetWindow, "lblTargetWindow");
            this.lblTargetWindow.Name = "lblTargetWindow";
            this.toolTip.SetToolTip(this.lblTargetWindow, resources.GetString("lblTargetWindow.ToolTip"));
            // 
            // btnAddToFavorites
            // 
            resources.ApplyResources(this.btnAddToFavorites, "btnAddToFavorites");
            this.btnAddToFavorites.Image = global::YuriyGuts.UnicodeKeyboard.Properties.Resources.CharAddToFavorites;
            this.btnAddToFavorites.Name = "btnAddToFavorites";
            this.toolTip.SetToolTip(this.btnAddToFavorites, resources.GetString("btnAddToFavorites.ToolTip"));
            this.btnAddToFavorites.UseVisualStyleBackColor = true;
            this.btnAddToFavorites.Click += new System.EventHandler(this.btnAddToFavorites_Click);
            this.btnAddToFavorites.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.FormMain_PreviewKeyDown);
            // 
            // btnCopy
            // 
            resources.ApplyResources(this.btnCopy, "btnCopy");
            this.btnCopy.Image = global::YuriyGuts.UnicodeKeyboard.Properties.Resources.CharCopy;
            this.btnCopy.Name = "btnCopy";
            this.toolTip.SetToolTip(this.btnCopy, resources.GetString("btnCopy.ToolTip"));
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            this.btnCopy.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.FormMain_PreviewKeyDown);
            // 
            // lblSenderWindowTitle
            // 
            resources.ApplyResources(this.lblSenderWindowTitle, "lblSenderWindowTitle");
            this.lblSenderWindowTitle.AutoEllipsis = true;
            this.lblSenderWindowTitle.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblSenderWindowTitle.Name = "lblSenderWindowTitle";
            this.toolTip.SetToolTip(this.lblSenderWindowTitle, resources.GetString("lblSenderWindowTitle.ToolTip"));
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
            // lnkCharmap
            // 
            resources.ApplyResources(this.lnkCharmap, "lnkCharmap");
            this.lnkCharmap.ActiveLinkColor = System.Drawing.Color.Blue;
            this.lnkCharmap.LinkColor = System.Drawing.Color.SteelBlue;
            this.lnkCharmap.Name = "lnkCharmap";
            this.lnkCharmap.TabStop = true;
            this.toolTip.SetToolTip(this.lnkCharmap, resources.GetString("lnkCharmap.ToolTip"));
            this.lnkCharmap.VisitedLinkColor = System.Drawing.Color.SteelBlue;
            this.lnkCharmap.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkCharmap_LinkClicked);
            this.lnkCharmap.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.FormMain_PreviewKeyDown);
            // 
            // lblCharDescription
            // 
            resources.ApplyResources(this.lblCharDescription, "lblCharDescription");
            this.lblCharDescription.AutoEllipsis = true;
            this.lblCharDescription.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblCharDescription.Name = "lblCharDescription";
            this.toolTip.SetToolTip(this.lblCharDescription, resources.GetString("lblCharDescription.ToolTip"));
            // 
            // lnkAbout
            // 
            resources.ApplyResources(this.lnkAbout, "lnkAbout");
            this.lnkAbout.ActiveLinkColor = System.Drawing.Color.Blue;
            this.lnkAbout.LinkColor = System.Drawing.Color.SteelBlue;
            this.lnkAbout.Name = "lnkAbout";
            this.lnkAbout.TabStop = true;
            this.toolTip.SetToolTip(this.lnkAbout, resources.GetString("lnkAbout.ToolTip"));
            this.lnkAbout.VisitedLinkColor = System.Drawing.Color.SteelBlue;
            this.lnkAbout.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkAbout_LinkClicked);
            this.lnkAbout.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.FormMain_PreviewKeyDown);
            // 
            // rbTextMode
            // 
            resources.ApplyResources(this.rbTextMode, "rbTextMode");
            this.rbTextMode.Name = "rbTextMode";
            this.toolTip.SetToolTip(this.rbTextMode, resources.GetString("rbTextMode.ToolTip"));
            this.rbTextMode.UseVisualStyleBackColor = true;
            this.rbTextMode.CheckedChanged += new System.EventHandler(this.rbTextMode_CheckedChanged);
            this.rbTextMode.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.FormMain_PreviewKeyDown);
            // 
            // lnkOptions
            // 
            resources.ApplyResources(this.lnkOptions, "lnkOptions");
            this.lnkOptions.ActiveLinkColor = System.Drawing.Color.Blue;
            this.lnkOptions.LinkColor = System.Drawing.Color.SteelBlue;
            this.lnkOptions.Name = "lnkOptions";
            this.lnkOptions.TabStop = true;
            this.toolTip.SetToolTip(this.lnkOptions, resources.GetString("lnkOptions.ToolTip"));
            this.lnkOptions.VisitedLinkColor = System.Drawing.Color.SteelBlue;
            this.lnkOptions.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkOptions_LinkClicked);
            this.lnkOptions.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.FormMain_PreviewKeyDown);
            // 
            // lblCharPreview
            // 
            resources.ApplyResources(this.lblCharPreview, "lblCharPreview");
            this.lblCharPreview.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblCharPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCharPreview.ForeColor = System.Drawing.Color.Silver;
            this.lblCharPreview.Name = "lblCharPreview";
            this.toolTip.SetToolTip(this.lblCharPreview, resources.GetString("lblCharPreview.ToolTip"));
            // 
            // lnkExit
            // 
            resources.ApplyResources(this.lnkExit, "lnkExit");
            this.lnkExit.ActiveLinkColor = System.Drawing.Color.Blue;
            this.lnkExit.LinkColor = System.Drawing.Color.SteelBlue;
            this.lnkExit.Name = "lnkExit";
            this.lnkExit.TabStop = true;
            this.toolTip.SetToolTip(this.lnkExit, resources.GetString("lnkExit.ToolTip"));
            this.lnkExit.VisitedLinkColor = System.Drawing.Color.SteelBlue;
            this.lnkExit.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkExit_LinkClicked);
            // 
            // tmrCharacterPreview
            // 
            this.tmrCharacterPreview.Interval = 500;
            this.tmrCharacterPreview.Tick += new System.EventHandler(this.tmrCharacterPreview_Tick);
            // 
            // MainForm
            // 
            this.AcceptButton = this.btnAccept;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblCharPreview);
            this.Controls.Add(this.rbTextMode);
            this.Controls.Add(this.lblCharDescription);
            this.Controls.Add(this.lnkExit);
            this.Controls.Add(this.lnkOptions);
            this.Controls.Add(this.lnkCharmap);
            this.Controls.Add(this.tblFavoriteIndexes);
            this.Controls.Add(this.lblFavorites);
            this.Controls.Add(this.tblFavoriteGlyphs);
            this.Controls.Add(this.lnkAbout);
            this.Controls.Add(this.lblSenderWindowTitle);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.btnAddToFavorites);
            this.Controls.Add(this.lblTargetWindow);
            this.Controls.Add(this.rbDecimalMode);
            this.Controls.Add(this.rbHexMode);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.lblHeader);
            this.Controls.Add(this.txtCharCode);
            this.Controls.Add(this.pbxAppMainImage);
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
            ((System.ComponentModel.ISupportInitialize)(this.pbxAppMainImage)).EndInit();
            this.tblFavoriteGlyphs.ResumeLayout(false);
            this.tblFavoriteGlyphs.PerformLayout();
            this.tblFavoriteIndexes.ResumeLayout(false);
            this.tblFavoriteIndexes.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon trayIcon;
        private System.Windows.Forms.PictureBox pbxAppMainImage;
        private System.Windows.Forms.TextBox txtCharCode;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.RadioButton rbHexMode;
        private System.Windows.Forms.RadioButton rbDecimalMode;
        private System.Windows.Forms.Label lblTargetWindow;
        private System.Windows.Forms.Button btnAddToFavorites;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.Label lblSenderWindowTitle;
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
        private System.Windows.Forms.LinkLabel lnkCharmap;
        private System.Windows.Forms.Label lblCharDescription;
        private System.Windows.Forms.LinkLabel lnkAbout;
        private System.Windows.Forms.RadioButton rbTextMode;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.LinkLabel lnkOptions;
        private System.Windows.Forms.Label lblCharPreview;
        private System.Windows.Forms.Timer tmrCharacterPreview;
        private System.Windows.Forms.ContextMenuStrip cmsTrayIconMenu;
        private System.Windows.Forms.ToolStripMenuItem cmiTrayExit;
        private System.Windows.Forms.ToolStripMenuItem cmiTrayUsageHint;
        private System.Windows.Forms.ToolStripSeparator cmiTraySeparator;
        private System.Windows.Forms.ToolStripMenuItem cmiTrayOptions;
        private System.Windows.Forms.LinkLabel lnkExit;
    }
}

