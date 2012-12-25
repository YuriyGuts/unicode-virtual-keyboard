using System;
using System.Collections;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Resources;

namespace YuriyGuts.UnicodeKeyboard.ResourceWrappers
{
    /// <summary>
    /// Enables the standard resource fallback mechanisms for ILMerge'd satellite resource assemblies.
    /// Code taken from http://stackoverflow.com/questions/1952638/
    /// </summary>
    internal class SingleAssemblyComponentResourceManager : ComponentResourceManager
    {
        private Type contextTypeInfo;
        private CultureInfo neutralResourcesCulture;

        public SingleAssemblyComponentResourceManager(Type type)
            : base(type)
        {
            contextTypeInfo = type;
        }

        protected override ResourceSet InternalGetResourceSet(CultureInfo culture, bool createIfNotExists, bool tryParents)
        {
            ResourceSet resourceSet = (ResourceSet)ResourceSets[culture];
            if (resourceSet == null)
            {
                // Lazy-load default language (without caring about duplicate assignment in race conditions, no harm done);
                if (neutralResourcesCulture == null)
                {
                    neutralResourcesCulture = GetNeutralResourcesLanguage(MainAssembly);
                }

                // If we're asking for the default language, then ask for the invariant (non-specific) resources.
                if (neutralResourcesCulture.Equals(culture))
                {
                    culture = CultureInfo.InvariantCulture;
                }

                string resourceFileName = GetResourceFileName(culture);
                Stream store = MainAssembly.GetManifestResourceStream(contextTypeInfo, resourceFileName);

                // If we found the appropriate resources in the local assembly...
                if (store != null)
                {
                    resourceSet = new ResourceSet(store);
                    // Save for later.
                    AddResourceSet(ResourceSets, culture, ref resourceSet);
                }
                else
                {
                    resourceSet = base.InternalGetResourceSet(culture, createIfNotExists, tryParents);
                }
            }
            return resourceSet;
        }

        // Private method in framework, had to be re-implemented here.
        private static void AddResourceSet(Hashtable localResourceSets, CultureInfo culture, ref ResourceSet resourceSet)
        {
            lock (localResourceSets)
            {
                ResourceSet localResourceSet = (ResourceSet)localResourceSets[culture];
                if (localResourceSet != null)
                {
                    if (!Equals(localResourceSet, resourceSet))
                    {
                        resourceSet.Dispose();
                        resourceSet = localResourceSet;
                    }
                }
                else
                {
                    localResourceSets.Add(culture, resourceSet);
                }
            }
        }
    }
}
