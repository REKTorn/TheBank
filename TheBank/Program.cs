using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TheBank
{
    class Program
    {

        static List<Customer> customers = new List<Customer>();
        static void Main(string[] args)
        {
            Console.WriteLine("Välkommen till banken!");
            Console.WriteLine();
            Console.WriteLine("Ange ett alternativ.");
            Console.WriteLine();

            int choice = 0;
            while ( choice != 7 )
            {
                choice = SelectMenuItem();

                switch (choice)
                {
                    case 1:
                        AddCustomer(); 
                        break;

                    case 2:
                        RemoveCustomer();
                        break;

                    case 3:
                        ShowAllCustomers();
                        Console.WriteLine();
                        break;

                    case 4:
                        ShowBalance();
                        break;

                    case 5:
                        Deposit();
                        break;

                    case 6:
                        Withdraw();
                        break;

                    case 7:
                        Console.WriteLine("Välkommen åter!");
                        Console.WriteLine("Tryck enter för att stänga fönstret...");
                        break;

                    default:
                        Console.WriteLine("Ogiltigt svar.");
                        Console.WriteLine();
                        break;
                }
            }


            Console.ReadLine();
        }

        private static void Withdraw()
        {
            ShowAllCustomers();
            Console.WriteLine("Välj en användare att göra uttag på.");
            int i = int.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine("Hur mycket vill du ta ut?");
            int transfer = int.Parse(Console.ReadLine());

            if (customers[i].Balance == 0)
            {
                Console.WriteLine("Du har inga pengar att ta ut.");
            }
            else if (transfer > customers[i].Balance)
            {
                Console.WriteLine("Du kan inte ta ut på kredit.");
            }
            else
            {
                customers[i].Balance = customers[i].Balance - transfer;
            }
            
            Console.WriteLine();
        }

        private static void Deposit()
        {
            ShowAllCustomers();
            Console.WriteLine("Välj en användare att göra insättning på.");
            int i = int.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine("Hur mycket vill du sätta in?");
            int addBalance = int.Parse(Console.ReadLine());
            customers[i].Balance = customers[i].Balance + addBalance;
            Console.WriteLine();
        }

        private static void ShowBalance()
        {
            ShowAllCustomers();
            Console.WriteLine();
            Console.WriteLine("Välj en användare för att se dess saldo.");
            Console.WriteLine();

            int i = int.Parse(Console.ReadLine());
            Console.WriteLine("Mr. " + customers[i].Name + ", you have " + customers[i].Balance + "$");
            Console.WriteLine();
        }

        private static void RemoveCustomer()
        {
            ShowAllCustomers();
            Console.WriteLine();
            Console.WriteLine("Välj en kund som du vill ta bort.");
            Console.WriteLine();

            int i = int.Parse(Console.ReadLine());
            customers.RemoveAt(i);
            Console.WriteLine();
        }

        private static void AddCustomer()
        {
            Customer customer = new Customer();
            Console.Write("Ange namn för användaren: ");
            customer.Name = Console.ReadLine();
            customer.Balance = 0;
            Console.WriteLine("Du la till en användare.");
            customers.Add(customer);
            Console.WriteLine();
        }

        private static void ShowAllCustomers()
        {
            for (int i = 0; i < customers.Count; i++)
            {
                Console.WriteLine(i + ": "  + customers[i].ShowCustomer);
            }

            /*foreach (Customer Name in customers)
            {
                Console.WriteLine(Name.ShowCustomer);
            }*/
        }

        private static int SelectMenuItem()
        {

            Console.WriteLine("1 : Lägg till en användare");
            Console.WriteLine("2 : Ta bort en användare");
            Console.WriteLine("3 : Visa alla befintliga användare");
            Console.WriteLine("4 : Visa saldo för en användare");
            Console.WriteLine("5 : Gör en insättning för en användare");
            Console.WriteLine("6 : Gör ett uttag för en användare");
            Console.WriteLine("7 : Avsluta programmet");
            Console.WriteLine();
            Console.WriteLine("Skriv ditt val:");
            int choice = int.Parse(Console.ReadLine());
            Console.WriteLine();
            return choice;
        }                                                   
    }
}
