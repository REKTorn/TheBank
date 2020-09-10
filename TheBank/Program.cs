using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBank
{
    class Program
    {
        static List<Customer> Customer = new List<Customer>();
        static void Main(string[] args)
        {
            SelectMenuItem();
        }

        private static void SelectMenuItem()
        {
            Console.WriteLine("Välkommen till banken!");
            Console.WriteLine();
            Console.WriteLine("Ange ett alternativ.");
            Console.WriteLine();
            Console.WriteLine("1 : Lägg till en användare");
            Console.WriteLine("2 : Ta bort en användare");
            Console.WriteLine("3 : Visa alla befintliga användare");
            Console.WriteLine("4 : Visa saldo för en användare");
            Console.WriteLine("5 : Gör en insättning för en användare");
            Console.WriteLine("6 : Gör ett uttag för en användare");
            Console.WriteLine("7 : Avsluta programmet");
            Console.WriteLine();
            Console.WriteLine("Skriv ditt val: " + Console.Read() );
        }                                                   
    }
}
