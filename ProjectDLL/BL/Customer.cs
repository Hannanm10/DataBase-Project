using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDLL.BL
{
    public class Customer : MUser
    {
        private string Name;
        private string Address;
        private string Contact;

        private Ticket BoughtTicket;

        public Customer() { }

        public Customer(string name, string pass) : base(name, pass) { }

        public Customer(string name, string pass, string role) : base(name, pass, role) { }


        public void SetName(string name)
        {
            this.Name = name;
        }

        public void SetAddress(string address)
        {
            this.Address = address;
        }

        public void SetContact(string contact)
        {
            this.Contact = contact;
        }

        public string GetName()
        {
            return this.Name;
        }

        public string GetAddress()
        {
            return this.Address;
        }

        public string GetContact()
        {
            return this.Contact;
        }


        public void BuyTicket(Ticket ticket)
        {
            this.BoughtTicket = ticket;
        }

        public void RemoveTicket()
        {
            this.BoughtTicket = null;
        }

        public Ticket GetTicket()
        {
            return this.BoughtTicket;
        }
    }
}
