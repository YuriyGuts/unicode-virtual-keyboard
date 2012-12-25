using System.Collections.Generic;
using System.Windows.Forms;

namespace YuriyGuts.UnicodeKeyboard.UI
{
    public class KeyboardShortcutTranscriber : IKeyboardShortcutTranscriber
    {
        protected Dictionary<string, string> keyNameSubstitutionDictionary;

        /// <summary>
        /// Singleton implementation.
        /// </summary>
        private static KeyboardShortcutTranscriber instance;
        public static KeyboardShortcutTranscriber Instance
        {
            get { return instance ?? (instance = new KeyboardShortcutTranscriber()); }
        }

        public string GetKeyboardShortcutDisplayText(Keys keys)
        {
            if (keyNameSubstitutionDictionary == null)
            {
                InitializeKeyNameSubstitutionDictionary();
            }

            List<string> parts = new List<string>();

            // Append modifier prefixes.
            if ((keys & Keys.Control) == Keys.Control)
            {
                parts.Add("Ctrl");
            }
            if ((keys & Keys.Alt) == Keys.Alt)
            {
                parts.Add("Alt");
            }
            if ((keys & Keys.Shift) == Keys.Shift)
            {
                parts.Add("Shift");
            }

            // Append the meaningful key itself.
            Keys meaningfulKey = keys & ~Keys.Modifiers;
            if (meaningfulKey != Keys.None)
            {
                string meaningfulKeyName = meaningfulKey.ToString();
                if (keyNameSubstitutionDictionary != null && keyNameSubstitutionDictionary.ContainsKey(meaningfulKeyName))
                {
                    meaningfulKeyName = keyNameSubstitutionDictionary[meaningfulKeyName];
                }
                parts.Add(meaningfulKeyName);
            }

            string result = string.Join(" + ", parts.ToArray());
            return result;
        }

        protected virtual void InitializeKeyNameSubstitutionDictionary()
        {
            keyNameSubstitutionDictionary = new Dictionary<string, string>
                {
                    { "D0", "0" },
                    { "D1", "1" },
                    { "D2", "2" },
                    { "D3", "3" },
                    { "D4", "4" },
                    { "D5", "5" },
                    { "D6", "6" },
                    { "D7", "7" },
                    { "D8", "8" },
                    { "D9", "9" },
                    { "Add", "'NumPad +'" },
                    { "Subtract", "'NumPad -'" },
                    { "Multiply", "'NumPad *'" },
                    { "Divide", "'NumPad /'" },
                    { "Decimal", "'NumPad .'" },
                    { "Back", "Backspace" },
                    { "Next", "PageDown" },
                    { "Return", "Enter" },
                    { "Oem1", "OEM 1" },
                    { "Oem102", "OEM 102" },
                    { "Oem2", "OEM 2" },
                    { "Oem3", "OEM 3" },
                    { "Oem4", "OEM 4" },
                    { "Oem5", "OEM 5" },
                    { "Oem6", "OEM 6" },
                    { "Oem7", "OEM 7" },
                    { "Oem8", "OEM 8" },
                    { "OemBackslash", "OEM '\\'" },
                    { "OemCloseBrackets", "OEM ']'" },
                    { "OemMinus", "OEM '-'" },
                    { "OemOpenBrackets", "OEM '['" },
                    { "OemPeriod", "OEM '.'" },
                    { "OemPipe", "OEM '|'" },
                    { "OemQuotes", "OEM Quote" },
                    { "OemQuestion", "OEM '?'" },
                    { "OemSemicolon", "OEM ';'" },
                    { "Oemcomma", "OEM ','" },
                    { "Oemplus", "OEM '+'" },
                    { "Oemtilde", "OEM '~'" },
                };
        }
    }
}
