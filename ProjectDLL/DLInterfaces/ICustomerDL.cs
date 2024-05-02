using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDLL.DLInterfaces
{
    public interface ICustomerDL
    {
        bool Save();

        bool GiveFeedback(string newFeedback);

        bool DeleteAccount(string Name);

        bool BuyTicket(int quantity);

        DataTable ViewReceipt();

        DataTable GetCustomerCredentials();

        void GetCustomerInfo();

        List<string> GetCustomerUserNames();

        void SetCustomer(string name, string pass);


    }
}
