using System;
using System.Windows;
using System.Windows.Input;
using HandyControl.Tools;

namespace HandyControl.Interactivity;

public class PushMainWindow2TopCommand : ICommand
{
    public bool CanExecute(object parameter) => true;

    public void Execute(object parameter)
    {
        if (WindowHelper.MainWindow() != null && WindowHelper.MainWindow().Visibility != Visibility.Visible)
        {
            WindowHelper.MainWindow().Show();
            WindowHelper.SetWindowToForeground(WindowHelper.MainWindow());
        }
    }

    public event EventHandler CanExecuteChanged;
}
