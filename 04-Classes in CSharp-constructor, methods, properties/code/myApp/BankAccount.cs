/*
 Mr Nguyen Duc Hoang
 https://www.youtube.com/c/nguyenduchoang
 Programming videos in .NET core, and many more....
*/
using System;
namespace myApp {
    public class BankAccount {
        public long AccountNumber { get; }
        public string Owner { get; set; } //Can read / write value
        public decimal Balance { get; } //remain money in your Bank account. Can only read !

        public void Deposit(decimal amount, DateTime date, string note) {
            //Money send to Bank account
        }
        public void Withdraw(decimal amount, DateTime date, string note) {
            //Eg: withdraw money to buy a car
        }
        private long GenerateAccountNumber() {
            return ((DateTimeOffset)DateTime.Now).ToUnixTimeMilliseconds();
        }
        //constructor
        public BankAccount(string owner, decimal initialBalance) {//function's name = class' name
            this.Owner = owner;
            this.AccountNumber = GenerateAccountNumber();
            this.Balance = initialBalance;
            Console.WriteLine("Object initialized with \n" +
                              $"Account Number = {this.AccountNumber} \n" +
                              $"Owner = {this.Owner}\n" +
                              $"Balance={this.Balance}\n");
        }
    }
}
