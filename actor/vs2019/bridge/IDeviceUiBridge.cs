
using System.Collections.Generic;
using XTC.oelMVCS;
namespace ogm.actor
{
    public interface IDeviceUiBridge : View.Facade.Bridge
    {
        object getRootPanel();
        void Alert(string _message);
        void UpdatePermission(Dictionary<string,string> _permission);

        void RefreshList(string _json);
    }
}
