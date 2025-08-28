using System.Xml.Linq;
using static Task_1.Program;

namespace Task_1
{
    internal class Program
    {
        public class Account
        {
            protected string name;
            protected double balance;

            public Account(string name = "Unnamed Account", double balance = 0.0)
            {
                this.name = name;
                this.balance = balance;
            }

            public virtual bool Deposit(double amount)
            {
                if (amount < 0)
                    return false;
                else
                {
                    balance += amount;
                    return true;
                }
            }

            public virtual bool Withdraw(double amount)
            {
                if (balance - amount >= 0)
                {
                    balance -= amount;
                    return true;
                }
                else
                {
                    return false;
                }
            }

            public double GetBalance()
            {
                return balance;
            }

            public override string ToString()
            {
                return $"[Account: {name}: {balance}]";
            }
        }

        public class SavingsAccount : Account
        {
            public double Intsrate { get; set; }
            public SavingsAccount(string name = "Unnamed Saving Account", double balance = 0.0, double intsrate = 0.02) : base(name, balance)
            {
                Intsrate = intsrate;
            }

            public override bool Deposit(double amount)
            {
                return base.Deposit(amount + (amount * Intsrate));
            }

            public override string ToString()
            {
                return $"[SavingsAccount: {name}, Balance: {GetBalance()}, Interest Rate: {Intsrate}]";
            }





        }

        class CheckingAccount : Account
        {
            public double Fee { get; set; }
            public CheckingAccount(string name = "Unnamed Checking Account", double balance = 0.0, double fee = 1.5) : base(name, balance)
            {
                this.Fee = fee;
            }
            public override bool Withdraw(double amount)
            {
                return base.Withdraw(amount + Fee);

            }
            public override string ToString()
            {
                return $"[CheckingAccount: {name}, Balance: {GetBalance()}, Fee: {Fee}]";

            }


            class TrustAccount : SavingsAccount
            {
                public int count { get; set; }
                public TrustAccount(string name = "Unnamed Trust Account", double balance = 0.0, double intsrate = 0.02) : base(name, balance, intsrate)
                {
                    count = 0;
                }

                public override bool Deposit(double amount)
                {

                    if (amount >= 5000)
                    {
                        amount += 50;

                    }


                    return base.Deposit(amount);

                }


                public override bool Withdraw(double amount)
                {

                    if (count < 3 && amount < GetBalance() * 0.2)
                    {
                        count++;
                        return base.Withdraw(amount);

                    }


                    else
                        return false;

                }
            }
            public static class AccountUtil
            {
                // Utility helper functions for Account class

                public static void Display(List<Account> accounts)
                {
                    Console.WriteLine("\n=== Accounts ==========================================");
                    foreach (var acc in accounts)
                    {
                        Console.WriteLine(acc);
                    }
                }

                public static void Deposit(List<Account> accounts, double amount)
                {
                    Console.WriteLine("\n=== Depositing to Accounts =================================");
                    foreach (var acc in accounts)
                    {
                        if (acc.Deposit(amount))
                            Console.WriteLine($"Deposited {amount} to {acc}");
                        else
                            Console.WriteLine($"Failed Deposit of {amount} to {acc}");
                    }
                }

                public static void Withdraw(List<Account> accounts, double amount)
                {
                    Console.WriteLine("\n=== Withdrawing from Accounts ==============================");
                    foreach (var acc in accounts)
                    {
                        if (acc.Withdraw(amount))
                            Console.WriteLine($"Withdrew {amount} from {acc}");
                        else
                            Console.WriteLine($"Failed Withdrawal of {amount} from {acc}");
                    }
                }

                // Helper functions for Savings Account class

                // Helper functions for Checking Account class

                // Helper functions for Trust account class
            }




            static void Main(string[] args)
            {
                //Console.WriteLine("Hello, World!");

                // Accounts
                var accounts = new List<Account>();
                accounts.Add(new Account());
                accounts.Add(new Account("Larry"));
                accounts.Add(new Account("Moe", 2000));
                accounts.Add(new Account("Curly", 5000));

                AccountUtil.Display(accounts);
                AccountUtil.Deposit(accounts, 1000);
                AccountUtil.Withdraw(accounts, 2000);

                // Savings
                var savAccounts = new List<Account>();
                savAccounts.Add(new SavingsAccount());
                savAccounts.Add(new SavingsAccount("Superman"));
                savAccounts.Add(new SavingsAccount("Batman", 2000));
                savAccounts.Add(new SavingsAccount("Wonderwoman", 5000, 5.0));

                AccountUtil.Display(savAccounts);
                AccountUtil.Deposit(savAccounts, 1000);
                AccountUtil.Withdraw(savAccounts, 2000);

                // Checking
                var checAccounts = new List<Account>();
                checAccounts.Add(new CheckingAccount());
                checAccounts.Add(new CheckingAccount("Larry2"));
                checAccounts.Add(new CheckingAccount("Moe2", 2000));
                checAccounts.Add(new CheckingAccount("Curly2", 5000));

                AccountUtil.Display(checAccounts);
                AccountUtil.Deposit(checAccounts, 1000);
                AccountUtil.Withdraw(checAccounts, 2000);
                AccountUtil.Withdraw(checAccounts, 2000);

                // Trust
                var trustAccounts = new List<Account>();
                trustAccounts.Add(new TrustAccount());
                trustAccounts.Add(new TrustAccount("Superman2"));
                trustAccounts.Add(new TrustAccount("Batman2", 2000));
                trustAccounts.Add(new TrustAccount("Wonderwoman2", 5000, 5.0));

                AccountUtil.Display(trustAccounts);
                AccountUtil.Deposit(trustAccounts, 1000);
                AccountUtil.Deposit(trustAccounts, 6000);
                AccountUtil.Withdraw(trustAccounts, 2000);
                AccountUtil.Withdraw(trustAccounts, 3000);
                AccountUtil.Withdraw(trustAccounts, 500);

                Console.WriteLine();


            }
        }
    }
}
