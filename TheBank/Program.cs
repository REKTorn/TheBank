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
            // Starts the program with this welcoming message.
            Console.WriteLine("Välkommen till banken!");
            Console.WriteLine();
            Console.WriteLine("Ange ett alternativ.");
            Console.WriteLine();

            int choice = 0;
            while ( choice != 7 ) // Looping the menu switch as long as the entered value is not "7".
            {
                choice = SelectMenuItem(); // Calls and puts the function "SelectMenuItem()"s return value into the variable "choise".

                switch (choice) // Starts the switch with the variable "choise" as a "key".
                {
                    case 1: // Case one will make the user add a customer to the customers list,
                        AddCustomer(); // with this function.
                        break;

                    case 2: // Case 2 will make the user remove a customer from the customers list,
                        RemoveCustomer(); // with this function.
                        break;

                    case 3: // Case 3 will display all the current customers existing,
                        ShowAllCustomers(); // with this function.
                        break;

                    case 4: // Case 4 will make the user choose a customer which balance will be displayed,
                        ShowBalance(); // with this function.
                        break;

                    case 5: // Case 5 will make a deposit into a chosen customers bank balance,
                        Deposit(); // with this function.
                        break;

                    case 6: // Case 6 will make a withdrawal from a chosen customers bank balance,
                        Withdraw(); // with this function.
                        break;

                    case 7: // Case 7, wich is when the loops break, the program will not continue anymore.
                        // And some farewell messages are being printed.
                        Console.WriteLine("Välkommen åter!");
                        Console.WriteLine("Tryck enter för att stänga fönstret...");
                        break;

                    default: // The default will run in case of a value that do not match the other cases.
                        Console.WriteLine("Ogiltigt svar."); // Printing an error message.
                        Console.WriteLine();
                        break;
                }
            }


            Console.ReadLine();
        }

        private static void Withdraw()
        {
            ShowAllCustomers(); // Runs a function that will display all the customers
            Console.WriteLine("Välj en användare att göra uttag på.");
            int i = int.Parse(Console.ReadLine()); // The program asks for the user to chose a customer with the help of integers
            Console.WriteLine();
            Console.WriteLine("Hur mycket vill du ta ut?");
            float transfer = int.Parse(Console.ReadLine()); // The program asks the user how much will be withdrawn from the customer

            if (customers[i].Balance() == 0) // If the customer do not have any money, it wont let you withdraw anything, followed by an error message.
            {
                Console.WriteLine("Du har inga pengar att ta ut.");
            }
            else if (transfer > customers[i].Balance()) // If the amount withdrawn is greater than the cusomers current balance, followed by an error message.
            {
                Console.WriteLine("Du kan inte ta ut på kredit.");
            }
            else // Else it will subtract the amount withdrawn with the current balance.
            {
                customers[i].Withdraw(transfer);
            }
            
            Console.WriteLine();
        }

        private static void Deposit()
        {
            ShowAllCustomers(); // Firsly runs a function to display all the customers.
            Console.WriteLine("Välj en användare att göra insättning på."); 
            int i = int.Parse(Console.ReadLine()); // Program asks to chose an integer which is assigned to a customer.
            Console.WriteLine();
            Console.WriteLine("Hur mycket vill du sätta in?"); // Asks how much the user wants to deposit.
            int transfer = int.Parse(Console.ReadLine()); // Adds the value into a variable.
            customers[i].Deposit(transfer); // The chosen customers balance is added with the deposit value.
            Console.WriteLine();
        }

        private static void ShowBalance()
        {
            ShowAllCustomers(); // Runs a function that will display all customers.
            Console.WriteLine();
            Console.WriteLine("Välj en användare för att se dess saldo.");
            Console.WriteLine();

            int i = int.Parse(Console.ReadLine()); // Program asks to chose an integer which is assigned to a customer.
            Console.WriteLine(customers[i].Name + " har" + customers[i].Balance() + "$." + Environment.NewLine + "Transaktioner: " + customers[i].ShowTransactions()); // Prints a message that shows the customers balance.
            Console.WriteLine();
        }

        private static void RemoveCustomer()
        {
            ShowAllCustomers(); // Runs a function that will display all customers.
            Console.WriteLine();
            Console.WriteLine("Välj en kund som du vill ta bort.");
            Console.WriteLine();

            int i = int.Parse(Console.ReadLine()); // Program asks to chose an integer which is assigned to a customer.
            customers.RemoveAt(i); // Removes a customer from the customers list.
            Console.WriteLine();
        }

        private static void AddCustomer()
        {
            Customer customer = new Customer(); // 
            Console.Write("Ange namn för användaren: ");
            customer.Name = Console.ReadLine(); // Program asks the user for the name of the customer that will be added
            customer.Balance = 0; // Pre-applies a balance of 0 to the customer
            Console.WriteLine("Du la till en användare.");
            customers.Add(customer); // Adds the new customer to the customers list.
            Console.WriteLine();
        }

        private static void ShowAllCustomers()
        {
            for (int i = 0; i < customers.Count; i++) // Looping through the customers list printing all the excisting customers.
            {
                Console.WriteLine(i + ": "  + customers[i].ShowCustomer);
            }

            /*foreach (Customer Name in customers)
            {
                Console.WriteLine(Name.ShowCustomer);
            }*/

            Console.WriteLine();
        }

        private static int SelectMenuItem() // Prints out all the main menu alternatives.
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
            int choice = int.Parse(Console.ReadLine()); // Program asks the user to input which alternative to be chosen.
            Console.WriteLine();
            return choice; // Sends back the result of the choice to the place where it was called on.
        }                                                   
    }
}
