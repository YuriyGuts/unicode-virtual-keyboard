using YuriyGuts.UnicodeKeyboard.ResourceWrappers;

namespace YuriyGuts.UnicodeKeyboard.UI
{
    partial class CharacterLookupForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle45 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle43 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new SingleAssemblyComponentResourceManager(typeof(CharacterLookupForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle44 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gridResultDisplayer = new System.Windows.Forms.DataGridView();
            this.colCharacterCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCharacterGlyph = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCharacterName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.lblShortcutAddToFavorites = new System.Windows.Forms.Label();
            this.lblShortcutCopyToClipboard = new System.Windows.Forms.Label();
            this.lblShortcutInsertCharacter = new System.Windows.Forms.Label();
            this.pnlShortcutSeparatorLine = new System.Windows.Forms.Panel();
            this.imgShortcutCopyToClipboard = new System.Windows.Forms.Panel();
            this.imgShortcutAddToFavorites = new System.Windows.Forms.Panel();
            this.imgShortcutInsertCharacterAlt = new System.Windows.Forms.Panel();
            this.imgShortcutInsertCharacter = new System.Windows.Forms.Panel();
            this.pnlSeparatorLine = new System.Windows.Forms.Panel();
            this.tmrSearchTimeout = new System.Windows.Forms.Timer(this.components);
            this.pnlBorder = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.gridResultDisplayer)).BeginInit();
            this.pnlBottom.SuspendLayout();
            this.pnlBorder.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridResultDisplayer
            // 
            this.gridResultDisplayer.AllowUserToAddRows = false;
            this.gridResultDisplayer.AllowUserToDeleteRows = false;
            this.gridResultDisplayer.AllowUserToResizeColumns = false;
            this.gridResultDisplayer.AllowUserToResizeRows = false;
            this.gridResultDisplayer.BackgroundColor = System.Drawing.SystemColors.Window;
            this.gridResultDisplayer.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridResultDisplayer.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.gridResultDisplayer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridResultDisplayer.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCharacterCode,
            this.colCharacterGlyph,
            this.colCharacterName});
            dataGridViewCellStyle45.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle45.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle45.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle45.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle45.SelectionBackColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle45.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle45.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridResultDisplayer.DefaultCellStyle = dataGridViewCellStyle45;
            resources.ApplyResources(this.gridResultDisplayer, "gridResultDisplayer");
            this.gridResultDisplayer.GridColor = System.Drawing.Color.WhiteSmoke;
            this.gridResultDisplayer.MultiSelect = false;
            this.gridResultDisplayer.Name = "gridResultDisplayer";
            this.gridResultDisplayer.RowHeadersVisible = false;
            this.gridResultDisplayer.RowTemplate.Height = 30;
            this.gridResultDisplayer.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridResultDisplayer.VirtualMode = true;
            this.gridResultDisplayer.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridResultDisplayer_CellDoubleClick);
            this.gridResultDisplayer.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.gridResultDisplayer_CellValueNeeded);
            this.gridResultDisplayer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridResultDisplayer_KeyDown);
            // 
            // colCharacterCode
            // 
            this.colCharacterCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle43.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colCharacterCode.DefaultCellStyle = dataGridViewCellStyle43;
            resources.ApplyResources(this.colCharacterCode, "colCharacterCode");
            this.colCharacterCode.Name = "colCharacterCode";
            this.colCharacterCode.ReadOnly = true;
            // 
            // colCharacterGlyph
            // 
            this.colCharacterGlyph.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle44.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle44.Font = new System.Drawing.Font("Arial Unicode MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.colCharacterGlyph.DefaultCellStyle = dataGridViewCellStyle44;
            resources.ApplyResources(this.colCharacterGlyph, "colCharacterGlyph");
            this.colCharacterGlyph.Name = "colCharacterGlyph";
            this.colCharacterGlyph.ReadOnly = true;
            this.colCharacterGlyph.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colCharacterName
            // 
            this.colCharacterName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            resources.ApplyResources(this.colCharacterName, "colCharacterName");
            this.colCharacterName.Name = "colCharacterName";
            this.colCharacterName.ReadOnly = true;
            // 
            // pnlBottom
            // 
            this.pnlBottom.BackColor = System.Drawing.SystemColors.Control;
            this.pnlBottom.Controls.Add(this.lblShortcutAddToFavorites);
            this.pnlBottom.Controls.Add(this.lblShortcutCopyToClipboard);
            this.pnlBottom.Controls.Add(this.lblShortcutInsertCharacter);
            this.pnlBottom.Controls.Add(this.pnlShortcutSeparatorLine);
            this.pnlBottom.Controls.Add(this.imgShortcutCopyToClipboard);
            this.pnlBottom.Controls.Add(this.imgShortcutAddToFavorites);
            this.pnlBottom.Controls.Add(this.imgShortcutInsertCharacterAlt);
            this.pnlBottom.Controls.Add(this.imgShortcutInsertCharacter);
            this.pnlBottom.Controls.Add(this.pnlSeparatorLine);
            resources.ApplyResources(this.pnlBottom, "pnlBottom");
            this.pnlBottom.Name = "pnlBottom";
            // 
            // lblShortcutAddToFavorites
            // 
            resources.ApplyResources(this.lblShortcutAddToFavorites, "lblShortcutAddToFavorites");
            this.lblShortcutAddToFavorites.Name = "lblShortcutAddToFavorites";
            // 
            // lblShortcutCopyToClipboard
            // 
            resources.ApplyResources(this.lblShortcutCopyToClipboard, "lblShortcutCopyToClipboard");
            this.lblShortcutCopyToClipboard.Name = "lblShortcutCopyToClipboard";
            // 
            // lblShortcutInsertCharacter
            // 
            resources.ApplyResources(this.lblShortcutInsertCharacter, "lblShortcutInsertCharacter");
            this.lblShortcutInsertCharacter.Name = "lblShortcutInsertCharacter";
            // 
            // pnlShortcutSeparatorLine
            // 
            this.pnlShortcutSeparatorLine.BackColor = System.Drawing.Color.Silver;
            resources.ApplyResources(this.pnlShortcutSeparatorLine, "pnlShortcutSeparatorLine");
            this.pnlShortcutSeparatorLine.Name = "pnlShortcutSeparatorLine";
            // 
            // imgShortcutCopyToClipboard
            // 
            this.imgShortcutCopyToClipboard.BackColor = System.Drawing.SystemColors.Control;
            this.imgShortcutCopyToClipboard.BackgroundImage = global::YuriyGuts.UnicodeKeyboard.Properties.Resources.KeyShortcutCopyToClipboard;
            resources.ApplyResources(this.imgShortcutCopyToClipboard, "imgShortcutCopyToClipboard");
            this.imgShortcutCopyToClipboard.Name = "imgShortcutCopyToClipboard";
            // 
            // imgShortcutAddToFavorites
            // 
            this.imgShortcutAddToFavorites.BackColor = System.Drawing.SystemColors.Control;
            this.imgShortcutAddToFavorites.BackgroundImage = global::YuriyGuts.UnicodeKeyboard.Properties.Resources.KeyShortcutAddToFavorites;
            resources.ApplyResources(this.imgShortcutAddToFavorites, "imgShortcutAddToFavorites");
            this.imgShortcutAddToFavorites.Name = "imgShortcutAddToFavorites";
            // 
            // imgShortcutInsertCharacterAlt
            // 
            this.imgShortcutInsertCharacterAlt.BackColor = System.Drawing.SystemColors.Control;
            this.imgShortcutInsertCharacterAlt.BackgroundImage = global::YuriyGuts.UnicodeKeyboard.Properties.Resources.MouseShortcutInsertCharacter;
            resources.ApplyResources(this.imgShortcutInsertCharacterAlt, "imgShortcutInsertCharacterAlt");
            this.imgShortcutInsertCharacterAlt.Name = "imgShortcutInsertCharacterAlt";
            // 
            // imgShortcutInsertCharacter
            // 
            this.imgShortcutInsertCharacter.BackColor = System.Drawing.SystemColors.Control;
            this.imgShortcutInsertCharacter.BackgroundImage = global::YuriyGuts.UnicodeKeyboard.Properties.Resources.KeyShortcutInsertCharacter;
            resources.ApplyResources(this.imgShortcutInsertCharacter, "imgShortcutInsertCharacter");
            this.imgShortcutInsertCharacter.Name = "imgShortcutInsertCharacter";
            // 
            // pnlSeparatorLine
            // 
            this.pnlSeparatorLine.BackColor = System.Drawing.Color.Silver;
            resources.ApplyResources(this.pnlSeparatorLine, "pnlSeparatorLine");
            this.pnlSeparatorLine.Name = "pnlSeparatorLine";
            // 
            // tmrSearchTimeout
            // 
            this.tmrSearchTimeout.Interval = 500;
            this.tmrSearchTimeout.Tick += new System.EventHandler(this.tmrSearchTimeout_Tick);
            // 
            // pnlBorder
            // 
            this.pnlBorder.BackColor = System.Drawing.SystemColors.WindowText;
            this.pnlBorder.Controls.Add(this.gridResultDisplayer);
            this.pnlBorder.Controls.Add(this.pnlBottom);
            resources.ApplyResources(this.pnlBorder, "pnlBorder");
            this.pnlBorder.Name = "pnlBorder";
            // 
            // CharacterLookupForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlBorder);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CharacterLookupForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Activated += new System.EventHandler(this.CharacterLookupForm_Activated);
            this.Deactivate += new System.EventHandler(this.CharacterLookupForm_Deactivate);
            this.Shown += new System.EventHandler(this.CharacterLookupForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.gridResultDisplayer)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            this.pnlBorder.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gridResultDisplayer;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Timer tmrSearchTimeout;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCharacterCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCharacterGlyph;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCharacterName;
        private System.Windows.Forms.Panel pnlBorder;
        private System.Windows.Forms.Panel pnlSeparatorLine;
        private System.Windows.Forms.Panel imgShortcutCopyToClipboard;
        private System.Windows.Forms.Panel imgShortcutAddToFavorites;
        private System.Windows.Forms.Panel imgShortcutInsertCharacterAlt;
        private System.Windows.Forms.Panel imgShortcutInsertCharacter;
        private System.Windows.Forms.Label lblShortcutAddToFavorites;
        private System.Windows.Forms.Label lblShortcutCopyToClipboard;
        private System.Windows.Forms.Label lblShortcutInsertCharacter;
        private System.Windows.Forms.Panel pnlShortcutSeparatorLine;
    }
}