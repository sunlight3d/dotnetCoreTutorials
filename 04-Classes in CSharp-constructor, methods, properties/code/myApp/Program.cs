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
        }
    }
}
