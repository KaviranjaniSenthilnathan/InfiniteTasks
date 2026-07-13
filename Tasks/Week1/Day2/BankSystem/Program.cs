using System;

namespace BankSystem
{
    // Base Class
    public class Account
    {
        private string accountNumber;
        protected double balance;

        public Account(string accNo, double initialBalance)
        {
            accountNumber = accNo;
            balance = initialBalance;
        }

        public double GetBalance()   //bal = 1000
        {
            return balance;
        }
      
        public virtual void Deposit(double amount)    //depamt=500
            //1000=1000+500
            //1500
        {
            if (amount > 0)
            {
                balance += amount;
                Console.WriteLine($"Deposited: {amount}");
            }
        }

        public virtual void Withdraw(double amount) //bal=1500
        {//1 and 1499


            //400
            if (amount > 0 && amount <= balance)
            {
                balance -= amount;
                //1500=1500-400
                //1100
                Console.WriteLine($"Withdrawn: {amount}");
            }
            else
            {//1501
                Console.WriteLine("Insufficient balance.");
            }
        }

        public void CheckBalance()
        {
            Console.WriteLine($"Current Balance: {balance}");
        }
    }

    //getbal
    //    dep
    //        withdraw
    //    checkbal


    public class SavingsAccount : Account  
        //save
       //                                  current
    {
        public SavingsAccount(string accNo, double balance)
            : base(accNo, balance) { }
    }

   
    public class CurrentAccount : Account
    {
        private double overdraftLimit = 500;

        public CurrentAccount(string accNo, double balance)
            : base(accNo, balance) { }
      

        public override void Withdraw(double amount)
        {
            if (amount <= balance + overdraftLimit)
            {
                balance -= amount;
                Console.WriteLine($"Withdrawn: {amount}");
            }
            else
            {
                Console.WriteLine("Overdraft limit exceeded.");
            }
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Select Account Type:");
            Console.WriteLine("1. Savings Account");
            Console.WriteLine("2. Current Account");
            int choice = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Account Number: ");
            string accNo = Console.ReadLine();

            Console.Write("Enter Initial Balance: ");
            double initialBalance = Convert.ToDouble(Console.ReadLine());

            Account account = null;

            if (choice == 1)
                account = new SavingsAccount(accNo, initialBalance);
            else if (choice == 2)
                account = new CurrentAccount(accNo, initialBalance);
            else
            {
                Console.WriteLine("Invalid choice.");
                return;

            }

            while (true)
            {
                Console.WriteLine("\n--- MENU ---");
                Console.WriteLine("1. Deposit");
                Console.WriteLine("2. Withdraw");
                Console.WriteLine("3. Check Balance");
                Console.WriteLine("4. Exit");

                int option = Convert.ToInt32(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        Console.Write("Enter amount to deposit: ");
                        double dep = Convert.ToDouble(Console.ReadLine());
                        account.Deposit(dep);
                        break;

                    case 2:
                        Console.Write("Enter amount to withdraw: ");
                        double wit = Convert.ToDouble(Console.ReadLine());
                        account.Withdraw(wit);
                        break;

                    case 3:
                        account.CheckBalance();
                        break;

                    case 4:
                        return;

                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }
    }
}