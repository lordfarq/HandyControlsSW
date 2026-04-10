using HandyControl.Themes;
using HandyControlsSWAPI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using Xarial.XCad.SolidWorks;
using Xarial.XCad.UI.Commands;
using Xarial.XToolkit.Helpers;
using Xarial.XToolkit.Reflection;

namespace HandyControlSW
{
    //[Guid("10EE01EE-9151-4268-82AE-0CC868855001")]
    //[ComVisible(true)]
    //[InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    //public interface IAddIn
    //{
    //    IHandyControlsSWAPI API { get; }
    //}

    [ComVisible(true)]
    [Guid("6E0DF6C5-AB67-412C-9F76-8BB7AEB7C2A3")]
    [ClassInterface(ClassInterfaceType.AutoDual)]
    public class AddIn : Xarial.XCad.SolidWorks.SwAddInEx, IHandyControlsSWAPI
    {
        public AddIn()
        {
            _api = new HandyControlsSWAPI(this);
        }
        public enum Commands_e
        {
            OpenWindow
        }
        public override void OnConnect()
        {
            GlobalObjects.AddIn = this;
            var resolver = new AssemblyResolver(AppDomain.CurrentDomain);
            resolver.RegisterAssemblyReferenceResolver(new LocalFolderReferencesResolver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)));

            //HandyControl.Controls.SimpleText simpleText = new HandyControl.Controls.SimpleText();

            //ThemeManager.Current.UsingWindowsAppTheme = true;
            ThemeManager.Current.ApplicationTheme = ApplicationTheme.Light;
            ThemeManager.Current.AccentColor = new SolidColorBrush(Colors.Purple);

            CommandManager.AddCommandGroup<Commands_e>().CommandClick += AddIn_CommandClick;

            this.CreateTaskPaneWpf<TaskPaneControl>();
        }

        private void AddIn_CommandClick(Commands_e spec)
        {
            switch (spec)
            {
                case Commands_e.OpenWindow:
                    Window1 window1 = new Window1();
                    window1.ShowDialog();
                    break;
                default:
                    break;
            }
        }

        [ComVisible(true)]
        public void ShowMessage(string message)
        {
            Application.ShowMessageBox(message);
        }

        private readonly HandyControlsSWAPI _api;
        //[ComVisible(true)]
        //public IHandyControlsSWAPI Api => _api;
        //[ComVisible(true)]
        //public IHandyControlsSWAPI API => _api;
    }

}
