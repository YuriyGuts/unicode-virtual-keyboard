using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using YuriyGuts.UnicodeKeyboard.Interaction;
using YuriyGuts.UnicodeKeyboard.ResourceWrappers;

namespace YuriyGuts.UnicodeKeyboard.UI
{
    /// <summary>
    /// Represents the character search form.
    /// </summary>
    public partial class CharacterLookupForm : Form
    {
        private readonly char[] namePartSeparators = { ' ' };

        private string searchQuery;
        private List<KeyValuePair<ushort, string>> lastSearchResults;

        /// <summary>
        /// Gets or sets the current character name filter.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string SearchQuery
        {
            get
            {
                return searchQuery;
            }
            set
            {
                searchQuery = value;
                PerformSearch();
            }
        }

        public event EventHandler<CharacterSearchResultEventArgs> ResultSubmitted;

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

        public void SubmitResult(CharacterSearchResult result)
        {
            if (result.Action != CharacterSearchAction.None)
            {
                Hide();
            }
            OnResultSubmitted(new CharacterSearchResultEventArgs(result));
        }

        protected virtual void OnResultSubmitted(CharacterSearchResultEventArgs e)
        {
            if (ResultSubmitted != null)
            {
                ResultSubmitted(this, e);
            }
        }

        private void PerformSearch()
        {
            UseWaitCursor = true;

            // Try to search by character code first...
            lastSearchResults = UnicodeCharacterDatabase.FindCharactersByCodeString(SearchQuery);

            // ...If that fails, search characters by name.
            if (lastSearchResults == null || lastSearchResults.Count == 0)
            {
                if (SearchQuery.Contains(" ") && SearchQuery.Trim().Length > 0)
                {
                    string[] filterParts = SearchQuery.Split(namePartSeparators, StringSplitOptions.RemoveEmptyEntries);
                    string regexPattern = string.Join(@".*?", filterParts);
                    lastSearchResults = UnicodeCharacterDatabase.FindCharactersByNameRegex(regexPattern);
                }
                else
                {
                    lastSearchResults = UnicodeCharacterDatabase.FindCharactersByName(SearchQuery, false);
                }
            }

            gridResultDisplayer.Rows.Clear();
            gridResultDisplayer.RowCount = lastSearchResults.Count;
            if (!Focused)
            {
                gridResultDisplayer.ClearSelection();
            }

            UseWaitCursor = false;
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

        private static bool KeyHasNoModifiers(KeyEventArgs args)
        {
            return !args.Alt && !args.Control && !args.Shift;
        }

        private static bool KeyHasControlModifierOnly(KeyEventArgs args)
        {
            return !args.Alt && args.Control && !args.Shift;
        }

        private void CharacterLookupForm_Activated(object sender, EventArgs e)
        {
            gridResultDisplayer.DefaultCellStyle.SelectionBackColor = Color.LightSteelBlue;
            if (gridResultDisplayer.RowCount > 0)
            {
                gridResultDisplayer.Rows[gridResultDisplayer.FirstDisplayedScrollingRowIndex].Selected = true;
            }
        }

        private void CharacterLookupForm_Deactivate(object sender, EventArgs e)
        {
            gridResultDisplayer.DefaultCellStyle.SelectionBackColor = Color.Gainsboro;
        }

        private void CharacterLookupForm_Shown(object sender, EventArgs e)
        {
            if (SearchQuery != null)
            {
                PerformSearch();
            }
        }

        private void gridResultDisplayer_KeyDown(object sender, KeyEventArgs e)
        {
            // Esc: close form.
            if (KeyHasNoModifiers(e) && e.KeyCode == Keys.Escape)
            {
                e.Handled = e.SuppressKeyPress = true;
                SubmitResult(new CharacterSearchResult
                {
                    Action = CharacterSearchAction.Cancel,
                    CharacterCode = 0,
                });
            }

            // Enter: insert character.
            if ((KeyHasNoModifiers(e) || KeyHasControlModifierOnly(e)) && e.KeyCode == Keys.Enter)
            {
                ushort charCode = GetSelectedCharacter();
                if (charCode != 0)
                {
                    SubmitResult(new CharacterSearchResult
                    {
                        Action = CharacterSearchAction.InsertCharacter,
                        CharacterCode = charCode,
                        KeepApplicationActive = KeyHasControlModifierOnly(e),
                    });
                }
            }

            // Ctrl + C: copy selected character to clipboard.
            if (KeyHasControlModifierOnly(e) && e.KeyCode == Keys.C)
            {
                e.Handled = e.SuppressKeyPress = true;
                SubmitResult(new CharacterSearchResult
                {
                    Action = CharacterSearchAction.CopyCharacterToClipboard,
                    CharacterCode = GetSelectedCharacter(),
                });
            }

            // Ctrl + D: add selected character to Favorites.
            if (KeyHasControlModifierOnly(e) && e.KeyCode == Keys.D)
            {
                e.Handled = e.SuppressKeyPress = true;
                SubmitResult(new CharacterSearchResult
                {
                    Action = CharacterSearchAction.AddCharacterToFavorites,
                    CharacterCode = GetSelectedCharacter(),
                });
            }

            // Backspace, Delete: return the focus to the owner.
            if (KeyHasNoModifiers(e) && (e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete))
            {
                if (Owner != null)
                {
                    gridResultDisplayer.ClearSelection();
                    Owner.Focus();
                }
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
                SubmitResult(new CharacterSearchResult
                {
                    Action = CharacterSearchAction.InsertCharacter,
                    CharacterCode = charCode,
                });
            }
        }

        private void tmrSearchTimeout_Tick(object sender, EventArgs e)
        {
            PerformSearch();
        }
    }
}