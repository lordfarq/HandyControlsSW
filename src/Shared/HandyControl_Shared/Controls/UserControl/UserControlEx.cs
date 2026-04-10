using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using HandyControl.Tools;

namespace HandyControl.Controls
{
    public partial class UserControlEx : System.Windows.Controls.UserControl
    {
        public UserControlEx()
        {
            if (Application.Current == null)
            {
                var themeDict = ResourceHelper.GetTheme();
                if (!Resources.MergedDictionaries.Contains(themeDict))
                {
                    Resources.MergedDictionaries.Add(themeDict);
                }
            }
        }
    }
}
