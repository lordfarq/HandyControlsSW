using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using HandyControlsSWAPI;

namespace HandyControlSW
{
    [ComVisible(true)]
    [Guid("B2C3D4E5-F6A7-48B9-0C1D-2345678901BC")]
    [ClassInterface(ClassInterfaceType.None)]
    internal class HandyControlsSWAPI : IHandyControlsSWAPI
    {
        private readonly AddIn _addin;
        internal HandyControlsSWAPI(AddIn addin)
        {
            _addin = addin;
        }
        public void ShowMessage(string message)
        {
            _addin.Application.ShowMessageBox(message);
        }
    }
}
