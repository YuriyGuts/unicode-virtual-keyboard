using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using YuriyGuts.UnicodeKeyboard.ResourceWrappers;
using YuriyGuts.UnicodeKeyboard.Settings;

namespace YuriyGuts.UnicodeKeyboard.UI
{
    /// <summary>
    /// Represents the form used for adding a character to the Favorites.
    /// </summary>
    public partial class AddToFavoritesForm : Form
    {
        private static readonly Color gridNormalColor = SystemColors.Window;
        private static readonly Color gridHoverColor = Color.LightSteelBlue;
        private static readonly Color gridFavoriteColor = Color.LemonChiffon;
        private static readonly Color gridFavoriteHoverColor = Color.Khaki;

        /// <summary>
        /// Executes the Add To Favorites Form for the specified character.
        /// </summary>
        /// <param name="charCode">Character code.</param>
        /// <param name="owner">Owner window.</param>
        /// <returns></returns>
        public static int? Execute(ushort charCode, Control owner)
        {
            int? result = null;
            using (AddToFavoritesForm frmAddToFavorites = new AddToFavoritesForm())
            {
                frmAddToFavorites.CharacterCode = charCode;
                DialogResult dialogResult = frmAddToFavorites.ShowDialog(owner);
                if (dialogResult == DialogResult.OK)
                {
                    result = frmAddToFavorites.SelectedIndex;
                }
            }
            return result;
        }

        private ushort characterCode;

        /// <summary>
        /// Gets or sets the code of the character to be placed into the Favorites panel.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ushort CharacterCode
        {
            get { return characterCode; }
            set
            {
                characterCode = value;
                lblCharacterPreview.Text = ((char)characterCode).ToString();
                lblCharacterName.Text = UnicodeCharacterDatabase.GetCharacterName(characterCode) ?? "(?)";
            }
        }

        private int? selectedIndex;

        /// <summary>
        /// Gets the index of the currently selected placeholder.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int? SelectedIndex
        {
            get { return selectedIndex; }
        }

        /// <summary>
        /// Initializes a new instance of AddToFavoritesForm.
        /// </summary>
        public AddToFavoritesForm()
        {
            InitializeComponent();
            InitializeComponentCustom();
        }

        private void InitializeComponentCustom()
        {
            lblCharacterPreview.Font = UIHelper.UnicodeCharacterFont;
            colCharacterGlyph.DefaultCellStyle.Font = UIHelper.UnicodeCharacterFont;
            gridFavorites.DefaultCellStyle.SelectionBackColor = gridFavoriteColor;
        }

        private void LoadFavorites()
        {
            gridFavorites.RowCount = UserSettings.Instance.Favorites.Length;
            for (int i = 0; i < gridFavorites.RowCount; i++)
            {
                ushort charCode = UserSettings.Instance.Favorites[i];
                gridFavorites[colIndex.Index, i].Value = i;
                PlaceCharacterIntoRow(i, charCode);
            }
            gridFavorites.ClearSelection();
        }

        private void PlaceCharacterIntoRow(int rowIndex, ushort charCode)
        {
            gridFavorites[colCharacterCode.Index, rowIndex].Value = charCode != 0 ? charCode.ToString("X4") : string.Empty;
            gridFavorites[colCharacterGlyph.Index, rowIndex].Value = charCode != 0 ? ((char)charCode).ToString() : string.Empty;
            gridFavorites[colCharacterName.Index, rowIndex].Value = charCode != 0 ? UnicodeCharacterDatabase.GetCharacterName(charCode) : string.Empty;
        }

        private void SetRowBackgroundColor(int rowIndex, Color newBackColor)
        {
            for (int i = 0; i < gridFavorites.ColumnCount; i++)
            {
                gridFavorites[i, rowIndex].Style.BackColor = newBackColor;
            }
        }

        private void FormAddToFavorites_Load(object sender, EventArgs e)
        {
            LoadFavorites();
            btnOK.Enabled = false;
        }

        private void gridFavorites_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                SetRowBackgroundColor(e.RowIndex, selectedIndex != e.RowIndex ? gridHoverColor : gridFavoriteHoverColor);
            }
        }

        private void gridFavorites_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                SetRowBackgroundColor(e.RowIndex, selectedIndex != e.RowIndex ? gridNormalColor : gridFavoriteColor);
            }
        }

        private void gridFavorites_SelectionChanged(object sender, EventArgs e)
        {
            bool selectionExists = gridFavorites.SelectedRows.Count > 0;

            // Discard the previously selected placeholder.
            if (selectedIndex != null)
            {
                PlaceCharacterIntoRow(selectedIndex.Value, UserSettings.Instance.Favorites[selectedIndex.Value]);
                SetRowBackgroundColor(selectedIndex.Value, gridNormalColor);
            }
            selectedIndex = selectionExists ? gridFavorites.SelectedRows[0].Index : (int?)null;

            // Apply new selection.
            if (selectionExists)
            {
                PlaceCharacterIntoRow(selectedIndex.Value, CharacterCode);
            }

            // Refresh background colors.
            for (int i = 0; i < gridFavorites.Rows.Count; i++)
            {
                SetRowBackgroundColor(i, i != selectedIndex ? gridNormalColor : gridFavoriteColor);
            }

            btnOK.Enabled = selectionExists;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}