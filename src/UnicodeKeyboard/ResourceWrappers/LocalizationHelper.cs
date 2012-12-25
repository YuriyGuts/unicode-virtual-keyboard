using System;
using System.Collections.Generic;
using System.Windows.Forms;
using YuriyGuts.UnicodeKeyboard.Properties;

namespace YuriyGuts.UnicodeKeyboard.ResourceWrappers
{
    /// <summary>
    /// Provides common routines for UI localization.
    /// </summary>
    internal static class LocalizationHelper
    {
        private static SingleAssemblyComponentResourceManager globalResourceManager = new SingleAssemblyComponentResourceManager(typeof(Resources));
        private static Dictionary<Type, SingleAssemblyComponentResourceManager> resourceManagerCache = new Dictionary<Type, SingleAssemblyComponentResourceManager>();

        /// <summary>
        /// Loads the specified string resource from the resource storage.
        /// </summary>
        /// <param name="resourceNamespaceOwner">Owning object (typically, a form).</param>
        /// <param name="key">Resource key.</param>
        /// <returns>Localized string that corresponds to the given key.</returns>
        public static string GetResource(Control resourceNamespaceOwner, string key)
        {
            if (resourceNamespaceOwner == null)
            {
                return GetGlobalResource(key);
            }
            return GetGlobalResource(string.Concat(resourceNamespaceOwner.Name, "_", key));
        }

        public static string GetObjectInternalResource(Type componentType, string key)
        {
            if (!resourceManagerCache.ContainsKey(componentType))
            {
                resourceManagerCache.Add(componentType, new SingleAssemblyComponentResourceManager(componentType));
            }
            return resourceManagerCache[componentType].GetString(key);
        }

        /// <summary>
        /// Loads the specified string resource from the application-wide resource storage.
        /// </summary>
        /// <param name="key"></param>
        /// <returns>Localized string that corresponds to the given key.</returns>
        public static string GetGlobalResource(string key)
        {
            return globalResourceManager.GetString(key);
        }
    }
}
