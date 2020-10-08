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
        public string Name { get; set; }
        public float Balance()
        {
            float sum = 0;
            foreach (Transaction t in transactions)
            {
                sum += t.value;
            }
            return sum;
        }
        public string ShowCustomer { get { return Name; } }
        public List<Transaction> transactions = new List<Transaction>();
        public void Deposit (int value)
        {
            Transaction t = new Transaction();
            t.value = value;
            t.timeStamp = DateTime.Now;
            transactions.Add(t);
        }
        public void Withdraw(float value)
        {
            Transaction t = new Transaction();
            t.value = -1 * value;
            t.timeStamp = DateTime.Now;
            transactions.Add(t);
        }
        public string ShowTransactions()
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
