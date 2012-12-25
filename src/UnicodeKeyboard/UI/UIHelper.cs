using System;
using System.Drawing;

namespace YuriyGuts.UnicodeKeyboard.UI
{
    /// <summary>
    /// Provides helper functions for common UI tasks.
    /// </summary>
    public static class UIHelper
    {
        private static bool isInitialized;
        private static Font unicodeCharacterFont;

        private const string universalFontFamily = "Arial Unicode MS";
        private const string minimumFontFamily = "Arial";
        private const float emSize = 15.75F;

        /// <summary>
        /// Font used for displaying Unicode characters.
        /// </summary>
        public static Font UnicodeCharacterFont
        {
            get { EnsureInitialized(); return unicodeCharacterFont; }
        }

        private static void EnsureInitialized()
        {
            if (isInitialized)
            {
                return;
            }
            string fontFamilyToUse = IsFontInstalled(universalFontFamily) ? universalFontFamily : minimumFontFamily;
            unicodeCharacterFont = new Font(fontFamilyToUse, emSize);
            isInitialized = true;
        }

        private static bool IsFontInstalled(string fontName)
        {
            using (Font testFont = new Font(fontName, 8))
            {
                return 0 == string.Compare(fontName, testFont.Name, StringComparison.InvariantCultureIgnoreCase);
            }
        }
    }
}
