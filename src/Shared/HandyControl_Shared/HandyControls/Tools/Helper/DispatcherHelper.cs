using System;
using System.Windows;
using System.Windows.Threading;

namespace HandyControl.Tools;

public static class DispatcherHelper
{
    internal static Dispatcher AppDispatcher;
    public static Dispatcher GetApplicationCurrentDispatcher()
    {
        if (Application.Current != null)
        {
            return Application.Current.Dispatcher;
        }
        else
        {
            if (AppDispatcher == null)
            {
                throw new NullReferenceException("AppDispatcher is not set. Please setup your theme resources to use this in a plugin.");
            }
            return AppDispatcher;
        }
    }
    public static void RunOnMainThread(Action action)
    {
        if (Application.Current == null)
        {
            RunOnUIThreadDispatcher(GetApplicationCurrentDispatcher(), action);
            return;
        }

        RunOnUIThread(Application.Current, action);
    }
    public static void RunOnUIThreadDispatcher(Dispatcher dispatcher, Action action)
    {
        if (dispatcher == null)
        {
            action();
            return;
        }
        if (dispatcher.CheckAccess())
        {
            action();
        }
        else
        {
            dispatcher.BeginInvoke(action);
        }
    }
    public static void RunOnUIThread(this DispatcherObject d, Action action)
    {
        var dispatcher = d?.Dispatcher;
        if (dispatcher!=null)
        {
            if (dispatcher.CheckAccess())
            {
                action();
            }
            else
            {
                dispatcher.BeginInvoke(action);
            }
        }
    }
}
