using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace HandyControlsSWAPI
{
    [ComVisible(true)]
    [Guid("A1B2C3D4-E5F6-47A8-9B0C-1234567890AB")]
    [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    public interface IHandyControlsSWAPI
    {
        void ShowMessage(string message);
    }
}
