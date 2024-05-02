using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDLL.BL
{
    public class Ticket
    {
        private string TypeName;
        private double Price;
        private Match Match;

        public Ticket() { }

        //public Ticket(string typeName, double price, Match match)
        //{
        //    this.TypeName = typeName;
        //    this.Price = price;
        //    this.Match = match;
        //}

        public Ticket(string typeName, Match match)
        {
            this.TypeName = typeName;
            this.Match = match;
        }


        public Ticket(string typeName, double price)
        {
            this.TypeName = typeName;
            this.Price = price;
        }


        public void SetTypeName(string typeName)
        {
            this.TypeName = typeName;
        }

        public void SetPrice(double price)
        {
            this.Price = price;
        }

        public double GetPrice()
        {
            return this.Price;
        }

        public string GetTypeName()
        {
            return this.TypeName;
        }

        public void SetMatch(Match match)
        {
            this.Match = match;
        }

        public Match GetMatch()
        {
            return this.Match;
        }

    }
}
