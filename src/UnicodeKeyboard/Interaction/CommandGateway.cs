using System;
using System.Diagnostics;
using System.Windows.Forms;
using Gma.UserActivityMonitor;
using YuriyGuts.UnicodeKeyboard.Settings;

namespace YuriyGuts.UnicodeKeyboard.Interaction
{
    /// <summary>
    /// Represents a preprocessor for global keyboard commands.
    /// </summary>
    public class CommandGateway : IDisposable
    {
        private int altKeysCount, controlKeysCount, shiftKeysCount;
        private bool isWaitingForSecondChordKey;
        private KeyEventArgs lastKeyDownArgs, lastKeyUpArgs;

        private bool shouldSendSilentKeyOnKeyUp;
        private ushort silentKeyCode;

        private readonly Timer stickyModifierResetTimer;

        private bool isDisposed;

        private bool isEnabled;

        // Indicates whether the command gateway should notify the application about the received commands.
        public bool IsEnabled
        {
            get { return isEnabled; }
            set
            {
                isEnabled = value;
                ResetHotkeyStateMemory();
            }
        }

        /// <summary>
        /// Initializes a new instance of CommandGateway.
        /// </summary>
        public CommandGateway()
        {
            stickyModifierResetTimer = new Timer { Enabled = false, Interval = 10000 };
            stickyModifierResetTimer.Tick += stickyModifierResetTimer_Tick;

            ResetHotkeyStateMemory();
            isEnabled = true;

            HookManager.KeyDown += HookManager_KeyDown;
            HookManager.KeyUp += HookManager_KeyUp;
        }

        private void HookManager_KeyDown(object sender, KeyEventArgs e)
        {
            if (!IsEnabled)
            {
                return;
            }

            // Do nothing if the key has not changed.
            if (e.KeyCode == lastKeyDownArgs.KeyCode)
            {
                return;
            }

            OnBeforeKeystrokeProcessed(this, e);

            // Remembering the new keystroke.
            lastKeyDownArgs = e;
            lastKeyUpArgs = new KeyEventArgs(Keys.None);

            do
            {
                // If the first key of a chord has been already pressed...
                if (isWaitingForSecondChordKey)
                {
                    bool isHexModeInvoke = IsSecondaryApplicationShortcut(e.KeyCode);
                    bool isFavoriteDigit = TryExtractDigitFromKeyCode(e.KeyCode) >= 0;
                    bool isValidSecondKey = isHexModeInvoke || isFavoriteDigit;

                    if (isValidSecondKey)
                    {
                        e.Handled = e.SuppressKeyPress = true;

                        if (isHexModeInvoke)
                        {
                            OnShowApplicationCommandReceived(this, EventArgs.Empty);
                        }
                        if (isFavoriteDigit)
                        {
                            int favoriteNumber = TryExtractDigitFromKeyCode(e.KeyCode);
                            shouldSendSilentKeyOnKeyUp = true;
                            silentKeyCode = UserSettings.Instance.Favorites[favoriteNumber];

                            Trace.WriteLine(string.Format("Favorite character chord pressed:  Index = {0}  Code = {1}.", favoriteNumber, silentKeyCode));
                        }
                    }
                    isWaitingForSecondChordKey = false;
                }

                if (!e.Handled)
                {
                    if (e.KeyCode == Keys.LMenu || e.KeyCode == Keys.RMenu)
                    {
                        altKeysCount = altKeysCount < 2 ? altKeysCount + 1 : 2;
                        isWaitingForSecondChordKey = false;
                        RestartStickyModifierTimer();
                        break;
                    }
                    if (e.KeyCode == Keys.LControlKey || e.KeyCode == Keys.RControlKey)
                    {
                        controlKeysCount = controlKeysCount < 2 ? controlKeysCount + 1 : 2;
                        isWaitingForSecondChordKey = false;
                        RestartStickyModifierTimer();
                        break;
                    }
                    if (e.KeyCode == Keys.LShiftKey || e.KeyCode == Keys.RShiftKey)
                    {
                        shiftKeysCount = shiftKeysCount < 2 ? shiftKeysCount + 1 : 2;
                        isWaitingForSecondChordKey = false;
                        RestartStickyModifierTimer();
                        break;
                    }

                    if (IsSecondaryApplicationShortcut(e.KeyCode))
                    {
                        Trace.WriteLine("First key of the chord pressed.");
                        isWaitingForSecondChordKey = true;
                        e.Handled = e.SuppressKeyPress = true;
                    }

                    if (IsPrimaryApplicationShortcut(e.KeyCode))
                    {
                        e.Handled = e.SuppressKeyPress = true;
                        isWaitingForSecondChordKey = false;
                        OnShowApplicationCommandReceived(this, EventArgs.Empty);
                    }
                }
            }
            while (false);
        }

        private void HookManager_KeyUp(object sender, KeyEventArgs e)
        {
            if (!IsEnabled)
            {
                return;
            }

            if (shouldSendSilentKeyOnKeyUp)
            {
                if (silentKeyCode >= 0)
                {
                    OnSendCharacterCommandReceivedEventArgs(this, new SendCharacterCommandEventArgs(silentKeyCode));
                }
                shouldSendSilentKeyOnKeyUp = false;
                silentKeyCode = 0;
            }

            if (e.KeyCode == lastKeyUpArgs.KeyCode)
            {
                return;
            }

            lastKeyUpArgs = e;
            lastKeyDownArgs = new KeyEventArgs(Keys.None);

            do
            {
                if (e.KeyCode == Keys.LMenu || e.KeyCode == Keys.RMenu)
                {
                    altKeysCount = altKeysCount > 0 ? altKeysCount - 1 : 0;
                }
                if (e.KeyCode == Keys.LControlKey || e.KeyCode == Keys.RControlKey)
                {
                    controlKeysCount = controlKeysCount > 0 ? controlKeysCount - 1 : 0;
                    break;
                }
                if (e.KeyCode == Keys.LShiftKey || e.KeyCode == Keys.RShiftKey)
                {
                    shiftKeysCount = shiftKeysCount > 0 ? shiftKeysCount - 1 : 0;
                    break;
                }
            }
            while (false);
        }

        private int TryExtractDigitFromKeyCode(Keys key)
        {
            // I don't feel completely secure about the >= and <= comparisons.
            // Maybe I should explicitly compare meaningfulKey with D0, D1, D2, D3 and so on.
            // However, it is very unlikely that Microsoft will ever alter the order of these items in the Keys enum.
            if (key >= Keys.D0 && key <= Keys.D9)
            {
                return key - Keys.D0;
            }
            if (key >= Keys.NumPad0 && key <= Keys.NumPad9)
            {
                return key - Keys.NumPad0;
            }

            return -1;
        }

        private bool IsPrimaryApplicationShortcut(Keys key)
        {
            return MatchCapturedKeyWithExpectedKey(key, UserSettings.Instance.PrimaryApplicationShortcut);
        }

        private bool IsSecondaryApplicationShortcut(Keys key)
        {
            return MatchCapturedKeyWithExpectedKey(key, UserSettings.Instance.SecondaryApplicationShortcut);
        }

        private bool MatchCapturedKeyWithExpectedKey(Keys capturedKey, Keys expectedKey)
        {
            // Captured key has no modifiers, instead we check our modifier state memory.
            bool altsMatch = (altKeysCount == 1 && (expectedKey & Keys.Alt) == Keys.Alt) || (altKeysCount == 0 && (expectedKey & Keys.Alt) == Keys.None);
            bool controlsMatch = (controlKeysCount == 1 && (expectedKey & Keys.Control) == Keys.Control) || (controlKeysCount == 0 && (expectedKey & Keys.Control) == Keys.None);
            bool shiftsMatch = (shiftKeysCount == 1 && (expectedKey & Keys.Shift) == Keys.Shift) || (shiftKeysCount == 0 && (expectedKey & Keys.Shift) == Keys.None);
            bool meaningfulKeysMatch = (capturedKey == (expectedKey & ~Keys.Modifiers));

            bool result = altsMatch & controlsMatch & shiftsMatch & meaningfulKeysMatch;
            return result;
        }

        private void ResetHotkeyStateMemory()
        {
            stickyModifierResetTimer.Enabled = false;
            altKeysCount = controlKeysCount = shiftKeysCount = 0;
            lastKeyDownArgs = new KeyEventArgs(Keys.None);
            lastKeyUpArgs = new KeyEventArgs(Keys.None);

            Trace.WriteLine("Hotkey state memory reset.");
        }

        private void RestartStickyModifierTimer()
        {
            stickyModifierResetTimer.Enabled = false;
            stickyModifierResetTimer.Enabled = true;
        }

        private void stickyModifierResetTimer_Tick(object sender, EventArgs e)
        {
            if (altKeysCount > 0 || controlKeysCount > 0 || shiftKeysCount > 0)
            {
                ResetHotkeyStateMemory();
            }
        }

        /// <summary>
        /// Performs the application-specific cleanup for this instance.
        /// </summary>
        public void Dispose()
        {
            if (isDisposed)
            {
                return;
            }

            stickyModifierResetTimer.Dispose();
            HookManager.KeyDown -= HookManager_KeyDown;
            HookManager.KeyUp -= HookManager_KeyUp;
            isDisposed = true;
        }

        #region Events

        /// <summary>
        /// Occurs before a global keypress is processed.
        /// </summary>
        public event EventHandler<KeyEventArgs> BeforeKeystrokeProcessed;

        /// <summary>
        /// Occurs when the application activation keystroke has been received.
        /// </summary>
        public event EventHandler ShowApplicationCommandReceived;

        /// <summary>
        /// Occurs when the favorite character insertion keystroke has been received.
        /// </summary>
        public event EventHandler<SendCharacterCommandEventArgs> SendCharacterCommandReceived;

        protected virtual void OnBeforeKeystrokeProcessed(object sender, KeyEventArgs args)
        {
            EventHandler<KeyEventArgs> handler = BeforeKeystrokeProcessed;
            if (handler != null)
            {
                handler(sender, args);
            }
        }

        protected virtual void OnShowApplicationCommandReceived(object sender, EventArgs args)
        {
            EventHandler handler = ShowApplicationCommandReceived;
            if (handler != null)
            {
                handler(sender, args);
            }
        }

        protected virtual void OnSendCharacterCommandReceivedEventArgs(object sender, SendCharacterCommandEventArgs args)
        {
            EventHandler<SendCharacterCommandEventArgs> handler = SendCharacterCommandReceived;
            if (handler != null)
            {
                handler(sender, args);
            }
        }

        #endregion Events
    }

    /// <summary>
    /// Represents the event arguments for the SendCharacterCommandReceived event.
    /// </summary>
    public class SendCharacterCommandEventArgs : EventArgs
    {
        /// <summary>
        /// Character code.
        /// </summary>
        public ushort CharacterCode { get; private set; }

        /// <summary>
        /// Initializes a new instance of SendCharacterCommandEventArgs.
        /// </summary>
        /// <param name="characterCode">Character code.</param>
        public SendCharacterCommandEventArgs(ushort characterCode)
        {
            CharacterCode = characterCode;
        }
    }
}
