using System;

namespace YuriyGuts.UnicodeKeyboard.Interaction
{
    /// <summary>
    /// Represents the possible options for showing the main window in reaction to a keyboard command.
    /// </summary>
    public enum ApplicationPopupMode
    {
        /// <summary>
        /// Decimal code search mode.
        /// </summary>
        DecimalCodeSearch,

        /// <summary>
        /// Hex code search mode.
        /// </summary>
        HexCodeSearch,

        /// <summary>
        /// Character name search mode.
        /// </summary>
        TextSearch,
    }

    /// <summary>
    /// Represents the event arguments for the ShowApplicationCommandReceived event.
    /// </summary>
    public class ApplicationPopupModeEventArgs : EventArgs
    {
        /// <summary>
        /// Application popup mode.
        /// </summary>
        public ApplicationPopupMode PopupMode { get; private set; }

        /// <summary>
        /// Initializes a new instance of ApplicationPopupModeEventArgs.
        /// </summary>
        /// <param name="popupMode">Application popup mode.</param>
        public ApplicationPopupModeEventArgs(ApplicationPopupMode popupMode)
        {
            PopupMode = popupMode;
        }
    }
}
