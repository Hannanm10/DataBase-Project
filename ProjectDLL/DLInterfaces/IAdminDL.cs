using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDLL.DLInterfaces
{
    public interface IAdminDL
    {
        void SetAdmin(string name, string pass);

        DataTable ViewOrders();

        DataTable ViewFeedBacks();
    }
}
