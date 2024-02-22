using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoapApp.Client.ServiceReference1;

namespace SoapApp.Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AtmServicesSoapClient atm = new AtmServicesSoapClient();

            Guid customer1 = Guid.NewGuid();
            Guid customer2 = Guid.NewGuid();

            Console.WriteLine(atm.SaveCustomer(customer1.ToString(), "AA", "BB"));
            Console.WriteLine(atm.SaveCustomer(customer2.ToString(), "CC", "DD"));

            Console.WriteLine("Customer registered.");
            Console.WriteLine();

            string iban1 = "123456";
            string iban2 = "789456";

            Console.WriteLine(atm.OpenAnAccount(Guid.NewGuid().ToString(),customer1.ToString(),iban1,10));
            Console.WriteLine(atm.OpenAnAccount(Guid.NewGuid().ToString(),customer2.ToString(),iban2,100));

            Console.WriteLine("Accounts have been created.");
            Console.WriteLine();


            Console.WriteLine(atm.WithDrawMoney(iban1,100));
            Console.WriteLine(atm.WithDrawMoney(iban2,100));

            Console.WriteLine("The withdrawal process is completed.");
            Console.WriteLine();


            Console.WriteLine(atm.DepositMoney(iban1,1000));
            Console.WriteLine(atm.DepositMoney(iban2,2000));

            Console.WriteLine("The deposit has been completed.");
            Console.WriteLine();

            Console.WriteLine(atm.EFT(iban1,iban2,10000));
            Console.WriteLine(atm.EFT(iban1,iban2,100));

            Console.WriteLine("EFT transactions have been completed.");
            Console.WriteLine();

            Console.Read();
        }
    }
}
