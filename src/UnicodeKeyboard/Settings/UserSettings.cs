using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.Xml.Serialization;
using Microsoft.Win32;

namespace YuriyGuts.UnicodeKeyboard.Settings
{
    /// <summary>
    /// Represents the user-specific application settings manager.
    /// </summary>
    [Serializable]
    [XmlRoot("UnicodeKeyboard")]
    public class UserSettings
    {
        private static UserSettings instance;

        private string language;
        private Keys primaryApplicationShortcut;
        private Keys secondaryApplicationShortcut;
        private bool showIconInSystemTray;
        private bool minimizeOnFocusLost;
        private bool terminateOnClose;
        private bool launchOnWindowsStartup;
        private ushort[] favorites;

        /// <summary>
        /// Initializes a new instance of the UserSettings class and fills it with default values.
        /// </summary>
        public UserSettings()
        {
            language = "en";
            primaryApplicationShortcut = Keys.Alt | Keys.Add;
            secondaryApplicationShortcut = Keys.Alt | Keys.Subtract;
            showIconInSystemTray = true;
            minimizeOnFocusLost = false;
            terminateOnClose = false;
            launchOnWindowsStartup = false;
            favorites = new ushort[] { 0x2014, 0x00A9, 0x00AB, 0x00BB, 0x2122, 0x00D7, 0x00B0, 0x2022, 0x2248, 0x2260 };
        }

        /// <summary>
        /// Singleton pattern implementation.
        /// </summary>
        [XmlIgnore]
        public static UserSettings Instance
        {
            get { return instance ?? (instance = new UserSettings()); }
        }

        /// <summary>
        /// User interface language code.
        /// </summary>
        public string Language
        {
            get { return language; }
            set { language = value; }
        }

        /// <summary>
        /// Application's primary magic keystroke.
        /// </summary>
        [XmlIgnore]
        public Keys PrimaryApplicationShortcut
        {
            get { return primaryApplicationShortcut; }
            set { primaryApplicationShortcut = value; }
        }

        /// <summary>
        /// Application's primary magic keystroke represented as integer (for internal use).
        /// </summary>
        [XmlElement("PrimaryApplicationShortcut")]
        public int PrimaryApplicationShortcutInt
        {
            get { return (int)primaryApplicationShortcut; }
            set { primaryApplicationShortcut = (Keys)value; }
        }

        /// <summary>
        /// Application's secondary magic keystroke.
        /// </summary>
        [XmlIgnore]
        public Keys SecondaryApplicationShortcut
        {
            get { return secondaryApplicationShortcut; }
            set { secondaryApplicationShortcut = value; }
        }

        /// <summary>
        /// Application's secondary magic keystroke represented as integer (for internal use).
        /// </summary>
        [XmlElement("SecondaryApplicationShortcut")]
        public int SecondaryApplicationShortcutInt
        {
            get { return (int)SecondaryApplicationShortcut; }
            set { SecondaryApplicationShortcut = (Keys)value; }
        }

        /// <summary>
        /// Whether to show the application icon in Windows system tray.
        /// </summary>
        public bool ShowIconInSystemTray
        {
            get { return showIconInSystemTray; }
            set { showIconInSystemTray = value; }
        }

        /// <summary>
        /// Whether to minimize the main window after it loses focus.
        /// </summary>
        public bool MinimizeOnFocusLost
        {
            get { return minimizeOnFocusLost; }
            set { minimizeOnFocusLost = value; }
        }

        /// <summary>
        /// Whether to terminate the application whenthe main window is closed.
        /// </summary>
        public bool TerminateOnClose
        {
            get { return terminateOnClose; }
            set { terminateOnClose = value; }
        }

        /// <summary>
        /// Whether to launch the application automatically after user logon.
        /// </summary>
        public bool LaunchOnWindowsStartup
        {
            get { return launchOnWindowsStartup; }
            set { launchOnWindowsStartup = value; }
        }

        /// <summary>
        /// Codes of all Favorite characters.
        /// </summary>
        public ushort[] Favorites
        {
            get { return favorites; }
            set { favorites = value; }
        }

        private XmlSerializer CreateSerializer()
        {
            XmlSerializer result = new XmlSerializer(GetType());
            return result;
        }

        private string GetSettingsFileName()
        {
            string globalAppDataDirectoryName = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string appSettingsDirectoryName = Path.Combine(globalAppDataDirectoryName, "UnicodeKeyboard");
            if (!Directory.Exists(appSettingsDirectoryName))
            {
                Directory.CreateDirectory(appSettingsDirectoryName);
            }
            return Path.Combine(appSettingsDirectoryName, "UserSettings.xml");
        }

        private void SerializeToFile(string fileName)
        {
            using (FileStream serializationStream = new FileStream(fileName, FileMode.Create))
            {
                CreateSerializer().Serialize(serializationStream, this);
            }
        }

        private void DeserializeFromFile(string fileName)
        {
            using (FileStream serializationStream = new FileStream(fileName, FileMode.Open))
            {
                UserSettings deserializedSettings;
                try
                {
                    deserializedSettings = (UserSettings)CreateSerializer().Deserialize(serializationStream);
                }
                catch (Exception ex)
                {
                    Trace.WriteLine("Unable to deserialize user settings: " + ex);
                    deserializedSettings = new UserSettings();
                }
                instance = deserializedSettings;
            }
        }

        private void SaveExtendedOptions()
        {
            RegisterAppInWindowsStartup(LaunchOnWindowsStartup);
        }

        private void RegisterAppInWindowsStartup(bool autorun)
        {
            try
            {
                RegistryKey runKey = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true);
                if (runKey != null)
                {
                    if (!autorun)
                    {
                        runKey.DeleteValue("Unicode Virtual Keyboard", false);
                    }
                    else
                    {
                        runKey.SetValue
                          (
                            "Unicode Virtual Keyboard",
                            string.Format("\"{0}\"", Assembly.GetExecutingAssembly().Location),
                            RegistryValueKind.String
                          );
                    }
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine("Failed to set app startup mode in Windows Registry: " + ex);
            }
        }

        /// <summary>
        /// Saves the user settings into default location.
        /// </summary>
        /// <param name="saveExtendedOptions">Whether to save the parameters that include heavyweight or uncommon tasks.</param>
        public void Save(bool saveExtendedOptions)
        {
            try
            {
                Save(GetSettingsFileName(), saveExtendedOptions);
            }
            catch (Exception ex)
            {
                Trace.WriteLine("Failed to save user settings!" + Environment.NewLine + ex, "Error");
            }
        }

        /// <summary>
        /// Saves the user settings into a specific file.
        /// </summary>
        /// <param name="fileName">Settings file name.</param>
        /// <param name="saveExtendedOptions">Whether to save the options that involve some heavyweight or uncommon operations while saving.</param>
        public void Save(string fileName, bool saveExtendedOptions)
        {
            try
            {
                // This is a dirty solution but I really don't want to invoke the Windows Registry
                // every time the user saves his Favorites or closes the application.
                if (saveExtendedOptions)
                {
                    SaveExtendedOptions();
                }
                SerializeToFile(fileName);
            }
            catch (Exception ex)
            {
                Trace.WriteLine("Failed to save user settings!" + Environment.NewLine + ex, "Error");
            }
        }

        /// <summary>
        /// Loads the user settings from default location.
        /// </summary>
        public void Load()
        {
            try
            {
                Load(GetSettingsFileName());
            }
            catch (Exception ex)
            {
                Trace.WriteLine("Failed to load user settings!" + Environment.NewLine + ex, "Error");
            }
        }

        /// <summary>
        /// Loads the user settings from a specific file
        /// </summary>
        /// <param name="fileName">Settings file name.</param>
        public void Load(string fileName)
        {
            try
            {
                DeserializeFromFile(fileName);
            }
            catch (Exception ex)
            {
                Trace.WriteLine("Failed to load user settings!" + Environment.NewLine + ex, "Error");
            }
        }
    }
}
