using System;



namespace UnitTestLab
{

    public class BankAccount
    {
        private string sortCode;
        private string accountNumber;
        private double overdraftLimit;
        private double balance;
        private List<double> history;


        public BankAccount(string sortCode, string accountNumber, double overdraftLimit, double balance)
        {
            this.sortCode = sortCode;
            this.accountNumber = accountNumber;
            this.overdraftLimit = overdraftLimit;
            this.balance = 0;
            this.history = new List<double>();
        }

        public BankAccount(string sortCode, string accountNumber) : this(sortCode, accountNumber, 0, 0){ }

        public string SortCode { get { return sortCode; } }
        public string AccountNumber { get { return accountNumber; } }
        public double OverdraftLimit { get { return overdraftLimit; } }
        public double Balance {get { return balance; } }
        public List<double> History { get{ return history; } }



        public void Deposit(double amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException("Amount cannot be 0");
            }
            else
            {
                balance += amount;
                history.Add(amount);
            }

        }

        public void Withdraw(int amount)
        {
            if(amount <= balance + overdraftLimit)
            {
                balance -= amount;
                history.Add(-amount);
            }
            else
            {
                throw new ArgumentException("Insufficient balance");
            }
        }

        public override string ToString()
        {
            return $"SortCode: {sortCode}\nAccount Number: {accountNumber}\nOverdraft Limit: {overdraftLimit}\nBalance: {balance}\nHistory: {history}";
        }





    }








    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}