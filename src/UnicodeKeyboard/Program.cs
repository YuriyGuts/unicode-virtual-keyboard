using System;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using YuriyGuts.UnicodeKeyboard.Settings;
using YuriyGuts.UnicodeKeyboard.UI;

namespace YuriyGuts.UnicodeKeyboard
{
    static class Program
    {
        private const string ApplicationMutexName = "UnicodeKeyboard-CFDD1D58-58AA-4B32-85D1-527EB2B5890F";

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            RunApplicationPreservingSingleInstance();
        }

        private static void RunApplicationPreservingSingleInstance()
        {
            Mutex mutex = AcquireMutex();
            if (mutex == null)
            {
                return;
            }

            try
            {
                RunApplication();
            }
            finally
            {
                mutex.ReleaseMutex();
            }
        }

        private static Mutex AcquireMutex()
        {
            Mutex appGlobalMutex = new Mutex(false, ApplicationMutexName);
            if (!appGlobalMutex.WaitOne(3000))
            {
                return null;
            }
            return appGlobalMutex;
        }

        private static void RunApplication()
        {
            LoadUserSettings();
            SetUILanguage(UserSettings.Instance.Language);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(MainForm.Instance);
        }

        private static void LoadUserSettings()
        {
            UserSettings.Instance.Load();
        }

        private static void SetUILanguage(string languageCode)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(languageCode);
        }
    }
}
