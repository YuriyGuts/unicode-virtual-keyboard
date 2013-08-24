using System;

namespace YuriyGuts.UnicodeKeyboard.Interaction
{
    /// <summary>
    /// Represents the results of interaction with the character lookup form.
    /// </summary>
    public class CharacterSearchResult
    {
        public CharacterSearchAction Action { get; set; }

        public ushort CharacterCode { get; set; }

        public bool KeepApplicationActive { get; set; }
    }

    /// <summary>
    /// Represents the possible actions that can be performed on the character lookup form.
    /// </summary>
    public enum CharacterSearchAction
    {
        None,
        Cancel,
        InsertCharacter,
        CopyCharacterToClipboard,
        AddCharacterToFavorites,
    }

    public class CharacterSearchResultEventArgs : EventArgs
    {
        public CharacterSearchResult Result { get; set; }

        public CharacterSearchResultEventArgs(CharacterSearchResult result)
        {
            Result = result;
        }
    }
}
