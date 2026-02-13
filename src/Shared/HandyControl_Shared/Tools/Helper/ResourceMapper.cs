using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows;

namespace HandyControl.Tools.Helper
{
    public static class ResourceMapper
    {
        internal static ResourceDictionary AppResources { get; set; }
        public static void ReadAppResources()
        {
            foreach (var resource in AppResources.MergedDictionaries)
            {
                Debug.Print(resource.Source.AbsolutePath);
            }
        }
        /// <summary>
        /// Resources to be added for custom styling and themes.
        /// </summary>
        /// <param name="resourceURI">Use absolute references, using pack
        /// "pack://application:,,,/CS.WPF.PluginHost;component/Styles/Mapping.xaml"</param>
        /// <returns>true if ResourceDictionary is successfully merged</returns>
		public static bool AddDictionaryToResources(Uri resourceURI)
        {
            AppResources ??= new ResourceDictionary();

            ResourceDictionary rd = new ResourceDictionary
            {
                Source = resourceURI
            };


            if (AppResources.MergedDictionaries.Contains(rd))
            {
                return false;
            }

            AppResources.MergedDictionaries.Add(rd);

            return true;
        }
        /// <summary>
        /// Resources to be added for custom styling and themes.
        /// </summary>
        /// <param name="resourceDictionary">Use absolute references, using pack
        /// "pack://application:,,,/CS.WPF.PluginHost;component/Styles/Mapping.xaml"</param>
        /// <returns>true if ResourceDictionary is successfully merged</returns>
        public static bool AddDictionaryToResources(ResourceDictionary resourceDictionary)
        {
            AppResources ??= new ResourceDictionary();

            if (AppResources.MergedDictionaries.Contains(resourceDictionary))
            {
                return false;
            }

            AppResources.MergedDictionaries.Add(resourceDictionary);

            return true;
        }
        public static ResourceDictionary GetThemeResources()
        {
            AppResources ??= new ResourceDictionary();
            Uri resourceUri = new Uri("pack://application:,,,/HandyControl_Net_GE45;component/Themes/Theme.xaml", UriKind.Absolute);

            var rd = new ResourceDictionary();

            try
            {
                rd.Source = resourceUri;
            }
            catch (Exception ex)
            {
                Debug.Print($"Failed to load resource dictionary: {ex.Message}");
                return AppResources;
            }

            bool foundResource = false;

            foreach (var item in AppResources.MergedDictionaries)
            {
                if (item.Source == rd.Source)
                {
                    foundResource = true;
                    break;
                }
            }

            if (foundResource)
            {
                return AppResources;
            }

            AppResources.MergedDictionaries.Add(rd);

            return AppResources;
        }
    }
}
