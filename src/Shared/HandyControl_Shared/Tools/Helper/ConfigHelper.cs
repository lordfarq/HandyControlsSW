using System;
using System.ComponentModel;
using System.Globalization;
#if !NET40
using System.Runtime.CompilerServices;
#endif
using System.Windows;
using System.Windows.Markup;
using System.Windows.Navigation;
using HandyControl.Data;
using HandyControl.Properties.Langs;
using Timeline = System.Windows.Media.Animation.Timeline;
namespace HandyControl.Tools;

public class ConfigHelper : INotifyPropertyChanged
{
    private ConfigHelper()
    {
        
    }

    private static readonly Lazy<ConfigHelper> InstanceInternal = new(() => new ConfigHelper(), isThreadSafe: true);

    public static ConfigHelper Instance => InstanceInternal.Value;

    private XmlLanguage _lang = XmlLanguage.GetLanguage("en");

    public XmlLanguage Lang
    {
        get => _lang;
        set
        {
            if (!_lang.IetfLanguageTag.Equals(value.IetfLanguageTag))
            {
                _lang = value;
                OnPropertyChanged(nameof(Lang));
            }
        }
    }

    public void SetLang(string lang)
    {
        LangProvider.Culture = new CultureInfo(lang);
        DispatcherHelper.GetApplicationCurrentDispatcher().Thread.CurrentCulture = new CultureInfo(lang);
        Lang = XmlLanguage.GetLanguage(lang);
        LocalizationManager.Instance.OnCultureChanged(new CultureInfo(lang));
    }

    public void SetConfig(HandyControlConfig config)
    {
        SetLang(config.Lang);
        SetTimelineFrameRate(config.TimelineFrameRate);
    }

    public void SetTimelineFrameRate(int rate) =>
        Timeline.DesiredFrameRateProperty.OverrideMetadata(typeof(Timeline), new FrameworkPropertyMetadata(rate));

    public void SetWindowDefaultStyle(object resourceKey = null)
    {
        var metadata = resourceKey == null
            ? new FrameworkPropertyMetadata(ResourceHelper.GetResource(typeof(Window)))
            : new FrameworkPropertyMetadata(ResourceHelper.GetResource(resourceKey));

        FrameworkElement.StyleProperty.OverrideMetadata(typeof(Window), metadata);
    }

    public void SetNavigationWindowDefaultStyle(object resourceKey = null)
    {
        var metadata = resourceKey == null
            ? new FrameworkPropertyMetadata(ResourceHelper.GetResource(typeof(NavigationWindow)))
            : new FrameworkPropertyMetadata(ResourceHelper.GetResource(resourceKey));

        FrameworkElement.StyleProperty.OverrideMetadata(typeof(NavigationWindow), metadata);
    }

    public event PropertyChangedEventHandler PropertyChanged;

#if NET40
    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
#else
    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
#endif
}
