using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Forms;
using YuriyGuts.UnicodeKeyboard.ResourceWrappers;

namespace YuriyGuts.UnicodeKeyboard.UI
{
    /// <summary>
    /// Represents the character search form.
    /// </summary>
    public partial class CharacterLookupForm : Form
    {
        private readonly char[] namePartSeparators = new[] { ' ' };
        private List<KeyValuePair<ushort, string>> lastSearchResults;

        /// <summary>
        /// Gets or sets the code of the character to be added to Favorites.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ushort CharacterCode { get; set; }

        /// <summary>
        /// Gets or sets the current character name filter.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Filter
        {
            get { return txtFilter.Text; }
            set { txtFilter.Text = value; }
        }

        /// <summary>
        /// Executes the character lookup form with the specified initial filter.
        /// </summary>
        /// <param name="initialFilter">Initial character name filter.</param>
        /// <param name="owner">Owner window.</param>
        /// <returns></returns>
        public static ushort Execute(string initialFilter, Control owner)
        {
            ushort result = 0;
            using (CharacterLookupForm frmCharacterLookup = new CharacterLookupForm())
            {
                frmCharacterLookup.Filter = initialFilter;
                DialogResult dialogResult = frmCharacterLookup.ShowDialog(owner ?? MainForm.Instance);
                if (dialogResult == DialogResult.OK)
                {
                    result = frmCharacterLookup.CharacterCode;
                }
            }
            return result;
        }

        /// <summary>
        /// Initializes a new instance of CharacterLookupForm.
        /// </summary>
        public CharacterLookupForm()
        {
            InitializeComponent();
            InitializeComponentCustom();
        }

        private void InitializeComponentCustom()
        {
            colCharacterGlyph.DefaultCellStyle.Font = UIHelper.UnicodeCharacterFont;
        }

        private void PerformSearch()
        {
            UseWaitCursor = true;

            tmrSearchTimeout.Enabled = false;

            if (Filter.Contains(" ") && Filter.Trim().Length > 0)
            {
                string[] filterParts = Filter.Split(namePartSeparators, StringSplitOptions.RemoveEmptyEntries);
                string regexPattern = string.Join(@".*?", filterParts);
                lastSearchResults = UnicodeCharacterDatabase.FindCharactersByNameRegex(regexPattern);
            }
            else
            {
                lastSearchResults = UnicodeCharacterDatabase.FindCharactersByName(Filter, false);
            }

            gridResultDisplayer.Rows.Clear();
            gridResultDisplayer.RowCount = lastSearchResults.Count;
            lblTotalItemsValue.Text = lastSearchResults.Count.ToString();

            UseWaitCursor = false;
        }

        private void CopySelectedCharacterToClipboard()
        {
            ushort charCode = GetSelectedCharacter();
            if (charCode != 0)
            {
                Clipboard.SetText(((char)charCode).ToString());
            }
        }

        private ushort GetSelectedCharacter()
        {
            ushort result = 0;
            if (gridResultDisplayer.SelectedRows.Count == 1)
            {
                result = GetCharacterCodeFromRow(gridResultDisplayer.SelectedRows[0].Index);
            }
            return result;
        }

        private ushort GetCharacterCodeFromRow(int rowIndex)
        {
            string cellValueHex = gridResultDisplayer.Rows[rowIndex].Cells[colCharacterCode.Index].Value.ToString();
            return ushort.Parse(cellValueHex, NumberStyles.HexNumber);
        }

        private void Accept(ushort charCode)
        {
            CharacterCode = charCode;
            DialogResult = DialogResult.OK;
        }

        private void Cancel()
        {
            CharacterCode = 0;
            DialogResult = DialogResult.Cancel;
        }

        private static bool IsNoModifiers(KeyEventArgs args)
        {
            return !args.Alt && !args.Control && !args.Shift;
        }

        private static bool IsControlPressed(KeyEventArgs args)
        {
            return !args.Alt && args.Control && !args.Shift;
        }

        private void FormCharacterLookup_Shown(object sender, EventArgs e)
        {
            if (Filter != null)
            {
                PerformSearch();
                gridResultDisplayer.Focus();
            }
        }

        private void FormCharacterLookup_Load(object sender, EventArgs e)
        {
            // Place the search form right under the main form's search box.
            Top += 165;
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            CopySelectedCharacterToClipboard();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            ushort charCode = GetSelectedCharacter();
            if (charCode != 0)
            {
                Accept(charCode);
            }
            else
            {
                PerformSearch();
            }
        }

        private void gridResultDisplayer_KeyDown(object sender, KeyEventArgs e)
        {
            // Esc - close form.
            if (IsNoModifiers(e) && e.KeyCode == Keys.Escape)
            {
                Cancel();
            }

            // Enter - accept character.
            if (IsNoModifiers(e) && e.KeyCode == Keys.Enter)
            {
                ushort charCode = GetSelectedCharacter();
                if (charCode != 0)
                {
                    Accept(charCode);
                }
            }

            // F3 or Ctrl+F - focus the search box.
            if ((IsNoModifiers(e) && e.KeyCode == Keys.F3) || (IsControlPressed(e) && e.KeyCode == Keys.F))
            {
                txtFilter.Focus();
                txtFilter.SelectAll();
            }

            // Ctrl+Alt+C - copy selected character to clipboard.
            if (e.Control && e.Alt && !e.Shift && e.KeyCode == Keys.C)
            {
                CopySelectedCharacterToClipboard();
            }
        }

        private void gridResultDisplayer_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            if (lastSearchResults.Count > e.RowIndex)
            {
                KeyValuePair<ushort, string> dataEntry = lastSearchResults[e.RowIndex];

                if (e.ColumnIndex == colCharacterCode.Index)
                {
                    e.Value = dataEntry.Key.ToString("X4");
                }
                else if (e.ColumnIndex == colCharacterGlyph.Index)
                {
                    e.Value = (char)dataEntry.Key;
                }
                else if (e.ColumnIndex == colCharacterName.Index)
                {
                    e.Value = dataEntry.Value;
                }
            }
        }

        private void gridResultDisplayer_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                ushort charCode = GetCharacterCodeFromRow(e.RowIndex);
                Accept(charCode);
            }
        }

        private void txtFilter_KeyDown(object sender, KeyEventArgs e)
        {
            // Esc - close form.
            if (IsNoModifiers(e) && e.KeyCode == Keys.Escape)
            {
                Cancel();
            }

            // Enter - perform search and focus the first row.
            if (IsNoModifiers(e) && e.KeyCode == Keys.Enter)
            {
                PerformSearch();
                if (lastSearchResults.Count > 0)
                {
                    gridResultDisplayer.Focus();
                }
            }

            // ArrowUp, ArrowDown, PageUp, PageDown - focus the grid.
            if (IsNoModifiers(e) && (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down || e.KeyCode == Keys.PageUp || e.KeyCode == Keys.PageDown))
            {
                gridResultDisplayer.Focus();
            }
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            tmrSearchTimeout.Enabled = true;
        }

        private void tmrSearchTimeout_Tick(object sender, EventArgs e)
        {
            PerformSearch();
        }
    }
}