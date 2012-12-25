using YuriyGuts.UnicodeKeyboard.ResourceWrappers;

namespace YuriyGuts.UnicodeKeyboard.UI
{
    partial class AddToFavoritesForm
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
            SingleAssemblyComponentResourceManager resources = new SingleAssemblyComponentResourceManager(typeof(AddToFavoritesForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblUsageHint = new System.Windows.Forms.Label();
            this.lblCharacterName = new System.Windows.Forms.Label();
            this.lblCharacterPreview = new System.Windows.Forms.Label();
            this.pnlMiddle = new System.Windows.Forms.Panel();
            this.gridFavorites = new System.Windows.Forms.DataGridView();
            this.colIndex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCharacterCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCharacterGlyph = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCharacterName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlBottom.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlMiddle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridFavorites)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlBottom
            // 
            resources.ApplyResources(this.pnlBottom, "pnlBottom");
            this.pnlBottom.Controls.Add(this.btnOK);
            this.pnlBottom.Controls.Add(this.btnCancel);
            this.pnlBottom.Name = "pnlBottom";
            // 
            // btnOK
            // 
            resources.ApplyResources(this.btnOK, "btnOK");
            this.btnOK.Name = "btnOK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // pnlTop
            // 
            resources.ApplyResources(this.pnlTop, "pnlTop");
            this.pnlTop.Controls.Add(this.lblUsageHint);
            this.pnlTop.Controls.Add(this.lblCharacterName);
            this.pnlTop.Controls.Add(this.lblCharacterPreview);
            this.pnlTop.Name = "pnlTop";
            // 
            // lblUsageHint
            // 
            resources.ApplyResources(this.lblUsageHint, "lblUsageHint");
            this.lblUsageHint.Name = "lblUsageHint";
            // 
            // lblCharacterName
            // 
            resources.ApplyResources(this.lblCharacterName, "lblCharacterName");
            this.lblCharacterName.AutoEllipsis = true;
            this.lblCharacterName.Name = "lblCharacterName";
            // 
            // lblCharacterPreview
            // 
            resources.ApplyResources(this.lblCharacterPreview, "lblCharacterPreview");
            this.lblCharacterPreview.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblCharacterPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCharacterPreview.Name = "lblCharacterPreview";
            // 
            // pnlMiddle
            // 
            resources.ApplyResources(this.pnlMiddle, "pnlMiddle");
            this.pnlMiddle.Controls.Add(this.gridFavorites);
            this.pnlMiddle.Name = "pnlMiddle";
            // 
            // gridFavorites
            // 
            resources.ApplyResources(this.gridFavorites, "gridFavorites");
            this.gridFavorites.AllowUserToAddRows = false;
            this.gridFavorites.AllowUserToDeleteRows = false;
            this.gridFavorites.AllowUserToResizeColumns = false;
            this.gridFavorites.AllowUserToResizeRows = false;
            this.gridFavorites.BackgroundColor = System.Drawing.SystemColors.Window;
            this.gridFavorites.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridFavorites.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIndex,
            this.colCharacterCode,
            this.colCharacterGlyph,
            this.colCharacterName});
            this.gridFavorites.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridFavorites.DefaultCellStyle = dataGridViewCellStyle4;
            this.gridFavorites.GridColor = System.Drawing.Color.WhiteSmoke;
            this.gridFavorites.MultiSelect = false;
            this.gridFavorites.Name = "gridFavorites";
            this.gridFavorites.ReadOnly = true;
            this.gridFavorites.RowHeadersVisible = false;
            this.gridFavorites.RowTemplate.Height = 30;
            this.gridFavorites.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridFavorites.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridFavorites_CellMouseEnter);
            this.gridFavorites.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridFavorites_CellMouseLeave);
            this.gridFavorites.SelectionChanged += new System.EventHandler(this.gridFavorites_SelectionChanged);
            // 
            // colIndex
            // 
            this.colIndex.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.colIndex.DefaultCellStyle = dataGridViewCellStyle1;
            resources.ApplyResources(this.colIndex, "colIndex");
            this.colIndex.Name = "colIndex";
            this.colIndex.ReadOnly = true;
            this.colIndex.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colIndex.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colCharacterCode
            // 
            this.colCharacterCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colCharacterCode.DefaultCellStyle = dataGridViewCellStyle2;
            resources.ApplyResources(this.colCharacterCode, "colCharacterCode");
            this.colCharacterCode.Name = "colCharacterCode";
            this.colCharacterCode.ReadOnly = true;
            this.colCharacterCode.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colCharacterCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colCharacterGlyph
            // 
            this.colCharacterGlyph.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colCharacterGlyph.DefaultCellStyle = dataGridViewCellStyle3;
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
            this.colCharacterName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // AddToFavoritesForm
            // 
            this.AcceptButton = this.btnOK;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.Controls.Add(this.pnlMiddle);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.pnlBottom);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "AddToFavoritesForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.FormAddToFavorites_Load);
            this.pnlBottom.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlMiddle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridFavorites)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Panel pnlMiddle;
        private System.Windows.Forms.DataGridView gridFavorites;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblCharacterPreview;
        private System.Windows.Forms.Label lblCharacterName;
        private System.Windows.Forms.Label lblUsageHint;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIndex;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCharacterCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCharacterGlyph;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCharacterName;
    }
}