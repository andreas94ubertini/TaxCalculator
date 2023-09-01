using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxCalculator
{
    internal class Taxpayer
    {
        public string Name { get; set; }
        public string Surame { get; set; }
        public string Birthday { get; set; }
        public string TaxCode { get; set; }
        public string Gender { get; set; }
        public string Municipality { get; set; }
        public double Income { get; set; }

        public Taxpayer() { }
        public Taxpayer(string name, string surame, string birthday, string taxCode, string gender, string municipality, double income)
        {
            Name = name;
            Surame = surame;
            Birthday = birthday;
            TaxCode = taxCode;
            Gender = gender;
            Municipality = municipality;
            Income = income;
        }
        public double TaxToPay()
        {
            double toPay = 0;
            if(Income > 0 && Income <= 15000)
            {
                toPay = (Income * 23)/100;
            }
            else if(Income > 15000 &&  Income <= 28000)
            {
                toPay = (((Income - 15000) * 27) / 100) + 3450;
            }
            else if (Income > 28000 && Income <= 55000)
            {
                toPay = (((Income - 28000) * 38) / 100) + 6960;
            }
            else if (Income > 55000 && Income <= 75000)
            {
                toPay = (((Income - 55000) * 41) / 100) + 17220;
            }
            else if (Income > 75000)
            {
                toPay = (((Income - 75000) * 43) / 100) + 25420;
            }
            return toPay;
        }
    }
}
