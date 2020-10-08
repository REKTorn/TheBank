using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBank
{
    class Customer
    {
        public string Name { get; set; } // The method for the name of the customer.
        public float Balance() // The method for the balance of the customer.
        {
            float sum = 0;
            foreach (Transaction t in transactions) // The calculation of the balance made out of the transactions.
            {
                sum += t.value;
            }
            return sum;
        }
        public string ShowCustomer { get { return Name; } } // Method that returns the name when displaying all the customers available.
        public List<Transaction> transactions = new List<Transaction>(); // The list that will contain all the transactions.
        public void Deposit (float value) // The method that will add the deposits with time stamps to the transaction list.
        {
            Transaction t = new Transaction();
            t.value = value;
            t.timeStamp = DateTime.Now;
            transactions.Add(t);
        }
        public void Withdraw(float value) // The method that will add the withdrawals with time stamps to the transaction list.
        {
            Transaction t = new Transaction();
            t.value = -1 * value;
            t.timeStamp = DateTime.Now;
            transactions.Add(t);
        }
        public string ShowTransactions() // The method that will show all the transactions made on a customer.
        {
            string str = "";
            foreach(Transaction t in transactions)
            {
                str += (t.timeStamp + ": " + t.value) + Environment.NewLine;
            }
            return str;
        }
    }
}
