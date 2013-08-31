using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Text.RegularExpressions;
using YuriyGuts.UnicodeKeyboard.Properties;

namespace YuriyGuts.UnicodeKeyboard.ResourceWrappers
{
    /// <summary>
    /// Represents the memory-cached Unicode character database.
    /// </summary>
    public static class UnicodeCharacterDatabase
    {
        private static bool isInitialized;
        private static Dictionary<ushort, string> characterNames;

        private static void EnsureInitialized()
        {
            if (isInitialized)
            {
                return;
            }
            Initialize();
            isInitialized = true;
        }

        private static void Initialize()
        {
            characterNames = new Dictionary<ushort, string>(16000);

            // Decompressing the character name list.
            using (MemoryStream compressedStream = new MemoryStream(Resources.CharacterNamesCompressed))
            {
                // Creating a memory stream for decompressed text.
                using (MemoryStream decompressedStream = new MemoryStream())
                {
                    // Creating inflater.
                    using (DeflateStream decompressor = new DeflateStream(compressedStream, CompressionMode.Decompress))
                    {
                        byte[] buffer = new byte[4096];
                        int bytesRead;
                        while ((bytesRead = decompressor.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            decompressedStream.Write(buffer, 0, bytesRead);
                        }
                    }

                    // Reading character names and storing them into a dictionary.
                    decompressedStream.Position = 0;
                    using (StreamReader reader = new StreamReader(decompressedStream))
                    {
                        while (!reader.EndOfStream)
                        {
                            string entry = reader.ReadLine();
                            if (entry != null)
                            {
                                characterNames.Add
                                  (
                                    ushort.Parse(entry.Substring(0, 4), NumberStyles.HexNumber),
                                    entry.Substring(5)
                                  );
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Gets the name of the Unicode character by its code.
        /// </summary>
        /// <param name="charCode">Character code.</param>
        /// <returns>The name of the character.</returns>
        public static string GetCharacterName(ushort charCode)
        {
            EnsureInitialized();
            string characterName;
            return characterNames.TryGetValue(charCode, out characterName) ? characterName : null;
        }

        /// <summary>
        /// Searches for Unicode characters by a string representation of the character code.
        /// </summary>
        /// <param name="codeString">String representation of the character code.</param>
        /// <returns>The list of all found items.</returns>
        public static List<KeyValuePair<ushort, string>> FindCharactersByCodeString(string codeString)
        {
            if (codeString.Length != 4)
            {
                return null;
            }

            ushort charCode;
            bool isParseSuccessful = ushort.TryParse(codeString, NumberStyles.HexNumber, CultureInfo.CurrentCulture, out charCode);

            if (isParseSuccessful && characterNames.ContainsKey(charCode))
            {
                return new List<KeyValuePair<ushort, string>>
                {
                    new KeyValuePair<ushort, string>(charCode, characterNames[charCode])
                };
            }
            return null;
        }

        /// <summary>
        /// Searches for Unicode characters whose names match the specified filter.
        /// </summary>
        /// <param name="nameFilter">Character name filter.</param>
        /// <param name="matchBeginningOnly">Whether to match only the beginning of the name.</param>
        /// <returns>The list of all found items.</returns>
        public static List<KeyValuePair<ushort, string>> FindCharactersByName(string nameFilter, bool matchBeginningOnly)
        {
            EnsureInitialized();
            List<KeyValuePair<ushort, string>> result = new List<KeyValuePair<ushort, string>>();
            foreach (KeyValuePair<ushort, string> pair in characterNames)
            {
                bool pairMatches =
                    string.IsNullOrEmpty(nameFilter)
                        || (matchBeginningOnly && pair.Value.StartsWith(nameFilter))
                        || (!matchBeginningOnly && pair.Value.Contains(nameFilter));

                if (pairMatches)
                {
                    result.Add(pair);
                }
            }
            return result;
        }

        /// <summary>
        /// Searches for Unicode characters whose names match the specified regex.
        /// </summary>
        /// <param name="regexPattern">Regex pattern.</param>
        /// <returns>The list of all found items.</returns>
        public static List<KeyValuePair<ushort, string>> FindCharactersByNameRegex(string regexPattern)
        {
            EnsureInitialized();
            List<KeyValuePair<ushort, string>> result = new List<KeyValuePair<ushort, string>>();
            Regex matchRegex = new Regex(regexPattern);

            foreach (KeyValuePair<ushort, string> pair in characterNames)
            {
                if (matchRegex.IsMatch(pair.Value))
                {
                    result.Add(pair);
                }
            }
            return result;
        }
    }
}
