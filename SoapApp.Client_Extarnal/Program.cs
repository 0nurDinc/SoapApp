using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoapApp.Client_Extarnal.IdentityValidation;

namespace SoapApp.Client_Extarnal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            KPSPublicSoapClient identityService = new KPSPublicSoapClient();
            Person person = new Person();

            Console.WriteLine("Enter your ID number");
            person.identity = long.Parse(Console.ReadLine());

            Console.WriteLine("Enter your name");
            person.firstName = Console.ReadLine();

            Console.WriteLine("Enter your surname");
            person.lastName = Console.ReadLine();

            Console.WriteLine("Enter year of birth");
            person.yearOfBirth = ushort.Parse(Console.ReadLine());

            Console.WriteLine($"Result : {identityService.TCKimlikNoDogrula(person.identity,person.firstName,person.lastName,person.yearOfBirth)}");

            Console.ReadLine();

        }
    }

    class Person
    {
        public long identity { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public ushort yearOfBirth { get; set; }
    }
}

 