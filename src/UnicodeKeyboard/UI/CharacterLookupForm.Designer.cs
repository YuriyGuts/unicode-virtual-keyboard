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
            SingleAssemblyComponentResourceManager resources = new SingleAssemblyComponentResourceManager(typeof(CharacterLookupForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gridResultDisplayer = new System.Windows.Forms.DataGridView();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.btnCopy = new System.Windows.Forms.Button();
            this.lblFilterEditHint = new System.Windows.Forms.Label();
            this.btnAccept = new System.Windows.Forms.Button();
            this.lblTotalItemsValue = new System.Windows.Forms.Label();
            this.lblTotalItemsCaption = new System.Windows.Forms.Label();
            this.pnlFilterContainer = new System.Windows.Forms.Panel();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.tmrSearchTimeout = new System.Windows.Forms.Timer(this.components);
            this.colCharacterCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCharacterGlyph = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCharacterName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridResultDisplayer)).BeginInit();
            this.pnlBottom.SuspendLayout();
            this.pnlFilterContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridResultDisplayer
            // 
            resources.ApplyResources(this.gridResultDisplayer, "gridResultDisplayer");
            this.gridResultDisplayer.AllowUserToAddRows = false;
            this.gridResultDisplayer.AllowUserToDeleteRows = false;
            this.gridResultDisplayer.AllowUserToResizeColumns = false;
            this.gridResultDisplayer.AllowUserToResizeRows = false;
            this.gridResultDisplayer.BackgroundColor = System.Drawing.SystemColors.Window;
            this.gridResultDisplayer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridResultDisplayer.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCharacterCode,
            this.colCharacterGlyph,
            this.colCharacterName});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridResultDisplayer.DefaultCellStyle = dataGridViewCellStyle3;
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
            // pnlBottom
            // 
            resources.ApplyResources(this.pnlBottom, "pnlBottom");
            this.pnlBottom.Controls.Add(this.btnCopy);
            this.pnlBottom.Controls.Add(this.lblFilterEditHint);
            this.pnlBottom.Controls.Add(this.btnAccept);
            this.pnlBottom.Controls.Add(this.lblTotalItemsValue);
            this.pnlBottom.Controls.Add(this.lblTotalItemsCaption);
            this.pnlBottom.Name = "pnlBottom";
            // 
            // btnCopy
            // 
            resources.ApplyResources(this.btnCopy, "btnCopy");
            this.btnCopy.Image = global::YuriyGuts.UnicodeKeyboard.Properties.Resources.CharCopy;
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // lblFilterEditHint
            // 
            resources.ApplyResources(this.lblFilterEditHint, "lblFilterEditHint");
            this.lblFilterEditHint.BackColor = System.Drawing.SystemColors.Control;
            this.lblFilterEditHint.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblFilterEditHint.Name = "lblFilterEditHint";
            // 
            // btnAccept
            // 
            resources.ApplyResources(this.btnAccept, "btnAccept");
            this.btnAccept.Image = global::YuriyGuts.UnicodeKeyboard.Properties.Resources.CharAccept;
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // lblTotalItemsValue
            // 
            resources.ApplyResources(this.lblTotalItemsValue, "lblTotalItemsValue");
            this.lblTotalItemsValue.Name = "lblTotalItemsValue";
            // 
            // lblTotalItemsCaption
            // 
            resources.ApplyResources(this.lblTotalItemsCaption, "lblTotalItemsCaption");
            this.lblTotalItemsCaption.Name = "lblTotalItemsCaption";
            // 
            // pnlFilterContainer
            // 
            resources.ApplyResources(this.pnlFilterContainer, "pnlFilterContainer");
            this.pnlFilterContainer.Controls.Add(this.txtFilter);
            this.pnlFilterContainer.Name = "pnlFilterContainer";
            // 
            // txtFilter
            // 
            resources.ApplyResources(this.txtFilter, "txtFilter");
            this.txtFilter.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.TextChanged += new System.EventHandler(this.txtFilter_TextChanged);
            this.txtFilter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFilter_KeyDown);
            // 
            // tmrSearchTimeout
            // 
            this.tmrSearchTimeout.Interval = 500;
            this.tmrSearchTimeout.Tick += new System.EventHandler(this.tmrSearchTimeout_Tick);
            // 
            // colCharacterCode
            // 
            this.colCharacterCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colCharacterCode.DefaultCellStyle = dataGridViewCellStyle1;
            resources.ApplyResources(this.colCharacterCode, "colCharacterCode");
            this.colCharacterCode.Name = "colCharacterCode";
            this.colCharacterCode.ReadOnly = true;
            // 
            // colCharacterGlyph
            // 
            this.colCharacterGlyph.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial Unicode MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.colCharacterGlyph.DefaultCellStyle = dataGridViewCellStyle2;
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
            // CharacterLookupForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridResultDisplayer);
            this.Controls.Add(this.pnlFilterContainer);
            this.Controls.Add(this.pnlBottom);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "CharacterLookupForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.FormCharacterLookup_Load);
            this.Shown += new System.EventHandler(this.FormCharacterLookup_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.gridResultDisplayer)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottom.PerformLayout();
            this.pnlFilterContainer.ResumeLayout(false);
            this.pnlFilterContainer.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gridResultDisplayer;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Label lblTotalItemsValue;
        private System.Windows.Forms.Label lblTotalItemsCaption;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.Panel pnlFilterContainer;
        private System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.Timer tmrSearchTimeout;
        private System.Windows.Forms.Label lblFilterEditHint;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCharacterCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCharacterGlyph;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCharacterName;
    }
}