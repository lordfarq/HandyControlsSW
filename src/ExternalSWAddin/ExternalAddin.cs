using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using HandyControlsSWAPI;
using SolidWorks.Interop.sldworks;
using Xarial.XCad.UI.Commands;

namespace ExternalSWAddin
{
    [Guid("ADF969C4-9BD8-4363-B615-A2DEC2AC6250")]
    [ComVisible(true)]
    public class ExternalAddin : Xarial.XCad.SolidWorks.SwAddInEx
    {
        public enum Commands2_e
        {
            SayHelloToTheOtherAddin
        }
        public override void OnConnect()
        {
            var swApp = Application.Sw as SldWorks;
            SWApp = swApp;

            CommandManager.AddCommandGroup<Commands2_e>().CommandClick += ExternalAddin_CommandClick1;

        }

        private void ExternalAddin_CommandClick1(Commands2_e spec)
        {
            if (spec == Commands2_e.SayHelloToTheOtherAddin)
            {
                try
                {
                    object otherAddin = SWApp.GetAddInObject("{6E0DF6C5-AB67-412C-9F76-8BB7AEB7C2A3}");
                    var api = otherAddin as IHandyControlsSWAPI;

                    //dynamic addinDynamic = otherAddin;
                    //IHandyControlsSWAPI api = addinDynamic.API;

                    api.ShowMessage("Hello from the other add-in!");
                }
                catch (Exception ex)
                {

                    
                }

            }
        }
        
        SldWorks SWApp;
    }
}
