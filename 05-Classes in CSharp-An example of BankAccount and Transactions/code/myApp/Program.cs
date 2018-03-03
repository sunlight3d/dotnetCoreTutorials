/*
 Mr Nguyen Duc Hoang
 https://www.youtube.com/c/nguyenduchoang
 Programming videos in .NET core, and many more....
*/
using System;

namespace myApp {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("Hello World!");
            var account = new BankAccount("Nguyen Duc Hoang", 1200);
            Console.WriteLine("Account has been created");
            account.Deposit(300, DateTime.Now, "Receive this month's salary.");
            account.Withdraw(100, DateTime.Now, "Buy a keyboard");
            account.Withdraw(120, DateTime.Now, "Buy a mouse");
            account.Withdraw(1500, DateTime.Now, "Buy a laptop");
            Console.WriteLine("Finish transactions");
        }
    }
}
