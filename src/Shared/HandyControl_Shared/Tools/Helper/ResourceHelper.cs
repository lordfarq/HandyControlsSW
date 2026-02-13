using System.Windows;
using HandyControl.Tools.Helper;

namespace HandyControl.Tools;

/// <summary>
///     Resource help class
/// </summary>
public class ResourceHelper
{
    //private static ResourceDictionary _theme;

    ///// <summary>
    /////     Get Resource
    ///// </summary>
    ///// <param name="key"></param>
    ///// <returns></returns>
    //public static T GetResource<T>(string key)
    //{
    //    if (Application.Current.TryFindResource(key) is T resource)
    //    {
    //        return resource;
    //    }

    //    return default;
    //}

    //internal static T GetResourceInternal<T>(string key)
    //{
    //    if (GetTheme()[key] is T resource)
    //    {
    //        return resource;
    //    }

    //    return default;
    //}

    ///// <summary>
    /////     get HandyControl theme
    ///// </summary>
    //public static ResourceDictionary GetTheme() => _theme ??= GetStandaloneTheme();

    //public static ResourceDictionary GetStandaloneTheme()
    //{
    //    return new()
    //    {
    //        Source = ApplicationHelper.GetAbsoluteUri("Themes/Theme.xaml")
    //    };
    //}
    private static ResourceDictionary _theme;

    public static object GetResource(object key)
    {
        if (TryFindResource(key) is object resource)
        {
            return resource;
        }
        return default;
    }

    /// <summary>
    ///     Get Resource
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    public static T GetResource<T>(string key)
    {
        if (TryFindResource(key) is T resource)
        {
            return resource;
        }

        return default;
    }

    internal static T GetResourceInternal<T>(string key)
    {
        if (GetTheme()[key] is T resource)
        {
            return resource;
        }

        return default;
    }

    /// <summary>
    ///     get HandyControl theme
    /// </summary>
    public static ResourceDictionary GetTheme() => _theme ??= GetStandaloneTheme();

    public static ResourceDictionary GetStandaloneTheme()
    {
        return new()
        {
            Source = ApplicationHelper.GetAbsoluteUri("Themes/Theme.xaml")
        };
    }

    //
    // Summary:
    //     Searches for the specified resource.
    //
    // Parameters:
    //   resourceKey:
    //     The name of the resource to find.
    //
    // Returns:
    //     The requested resource object. If the requested resource is not found, a null
    //     reference is returned.
    private static object TryFindResource(object resourceKey)
    {
        //ResourceMapper.AppResources ??= ResourceMapper.GetThemeResources();

        ResourceDictionary resources = SystemResources;
        object obj = null;
        if (resources != null)
        {
            obj = resources[resourceKey];
        }

        if (obj == DependencyProperty.UnsetValue || obj == null)
        {
            //obj = SystemResources.FindResourceInternal(resourceKey);
        }

        return obj;
    }
    private static ResourceDictionary SystemResources
    {
        get
        {
            ResourceDictionary systemResources = Application.Current?.Resources;
            if (systemResources == null)
            {
                systemResources = new ResourceDictionary();
            }
            return systemResources;
        }
    }
}
