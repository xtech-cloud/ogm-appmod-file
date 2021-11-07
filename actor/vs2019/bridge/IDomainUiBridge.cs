
using System.Collections.Generic;
using XTC.oelMVCS;
namespace ogm.actor
{
    public interface IDomainUiBridge : View.Facade.Bridge
    {
        object getRootPanel();
        void Alert(string _message);
        void UpdatePermission(Dictionary<string,string> _permission);

        void ReceiveCreate(string _json);
        void ReceiveUpdate(string _json);
        void RefreshList(string _json);
        void RefreshFetchDevice(string _json);
    }
}
