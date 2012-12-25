using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace YuriyGuts.UnicodeKeyboard.UI
{
    public class KeyboardShortcutEditor : TextBox
    {
        protected Keys value;

        public KeyboardShortcutEditor()
        {
            ReadOnly = true;
            ValidShortcutColor = Color.Green;
            InvalidShortcutColor = Color.Red;
        }

        [Category("Appearance")]
        public Color ValidShortcutColor { get; set; }

        [Category("Appearance")]
        public Color InvalidShortcutColor { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual Keys Value
        {
            get
            {
                return value;
            }
            set
            {
                if (this.value != value)
                {
                    this.value = value;
                    Text = GetKeystrokeDisplayText(value);
                    bool isValid = OnValidateShortcut(value);
                    ForeColor = isValid ? ValidShortcutColor : InvalidShortcutColor;
                    OnValueChanged();
                }
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public IKeyboardShortcutTranscriber Transcriber { get; set; }

        protected override void OnReadOnlyChanged(EventArgs e)
        {
            base.OnReadOnlyChanged(e);

            // Do not allow the TextBox to become editable because we always supply our own Text.
            ReadOnly = true;
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            Keys keys = e.KeyData;
            Keys preProcessedKey = PreProcessKeystroke(keys);
            Value = preProcessedKey;

            e.Handled = true;
            e.SuppressKeyPress = true;
        }

        private bool IsModifierSourceKey(Keys keys)
        {
            bool isAltKey = (keys & Keys.Menu) == Keys.Menu && (keys & ~Keys.Modifiers) == Keys.Menu;
            bool isControlKey = (keys & Keys.ControlKey) == Keys.ControlKey && (keys & ~Keys.Modifiers) == Keys.ControlKey;
            bool isShiftKey = (keys & Keys.ShiftKey) == Keys.ShiftKey && (keys & ~Keys.Modifiers) == Keys.ShiftKey;

            bool result = isAltKey || isControlKey || isShiftKey;
            return result;
        }

        protected virtual Keys PreProcessKeystroke(Keys keys)
        {
            Keys result = keys;

            // Do not allow the Menu, ControlKey and ShiftKey keys to show up.
            if (IsModifierSourceKey(keys))
            {
                // Leave modifiers only (for better visual feedback) and clear the actual keys.
                result = keys & Keys.Modifiers;
            }
            return result;
        }

        private string GetKeystrokeDisplayText(Keys keys)
        {
            string result;
            if (Transcriber != null)
            {
                result = Transcriber.GetKeyboardShortcutDisplayText(keys);
            }
            else
            {
                result = keys.ToString();
            }
            return result;
        }

        #region Events

        public event EventHandler ValueChanged;
        public event EventHandler<KeyboardShortcutValidationEventArgs> ValidateShortcut;

        protected virtual void OnValueChanged()
        {
            EventHandler handler = ValueChanged;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }

        protected virtual bool OnValidateShortcut(Keys shortcut)
        {
            bool result = true;

            EventHandler<KeyboardShortcutValidationEventArgs> handler = ValidateShortcut;
            if (handler != null)
            {
                foreach (Delegate currentHandler in handler.GetInvocationList())
                {
                    KeyboardShortcutValidationEventArgs args = new KeyboardShortcutValidationEventArgs(shortcut);
                    currentHandler.DynamicInvoke(this, args);

                    result &= args.IsValid;
                    if (!result)
                    {
                        break;
                    }
                }
            }

            return result;
        }

        #endregion Events
    }

    public class KeyboardShortcutValidationEventArgs : EventArgs
    {
        public Keys Keys { get; set; }
        public bool IsValid { get; set; }

        public KeyboardShortcutValidationEventArgs(Keys keys)
        {
            Keys = keys;
            IsValid = true;
        }
    }
}
