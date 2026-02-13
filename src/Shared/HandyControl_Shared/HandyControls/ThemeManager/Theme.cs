// http://github.com/kinnara/ModernWpf

using System.Windows;
using System.Windows.Threading;
using HandyControl.Tools;

namespace HandyControl.Themes;

/// <summary>
/// Default styles for controls.
/// </summary>
public class Theme : ResourceDictionary
{
    /// <summary>
    /// Initializes a new instance of the Theme class.
    /// </summary>
    public Theme()
    {
        DispatcherHelper.AppDispatcher = Dispatcher.CurrentDispatcher;
        MergedDictionaries.Add(ControlsResources);
    }

    public static ResourceDictionary ControlsResources
    {
        get
        {
            if (_controlsResources == null)
            {
                _controlsResources = new ResourceDictionary { Source = ApplicationHelper.GetAbsoluteUri("Themes/Theme.xaml") };
            }
            return _controlsResources;
        }
    }

    private static ResourceDictionary _controlsResources;
}
