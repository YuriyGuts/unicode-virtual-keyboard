using System.Windows.Forms;

namespace YuriyGuts.UnicodeKeyboard.UI
{
    /// <summary>
    /// Provides user-friendly keyboard shortcut transcription services.
    /// </summary>
    public interface IKeyboardShortcutTranscriber
    {
        /// <summary>
        /// Provides a user-friendly string representation of an instance of Keys.
        /// </summary>
        /// <param name="key">An instance of the Keys enumeration.</param>
        /// <returns>String representation of the specified Keys instance.</returns>
        string GetKeyboardShortcutDisplayText(Keys key);
    }
}
