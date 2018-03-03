/*
 Mr Nguyen Duc Hoang
 https://www.youtube.com/c/nguyenduchoang
 Programming videos in .NET core, and many more....
*/
using System;
using System.Collections.Generic;

namespace myApp {
    public class BankAccount { //One BankAccount has many Transactions
        public long AccountNumber { get; }
        public string Owner { get; set; } //Can read / write value
        private List<Transaction> transactions = new List<Transaction>();
        public decimal Balance { 
            get {
                decimal balance = 0;
                foreach (var transaction in transactions)
                {
                    balance += transaction.Amount;
                }
                return balance;
            }
        } //remain money in your Bank account. Can only read !

        public void Deposit(decimal amount, DateTime date, string note) {
            //Money send to Bank account
            var deposit = new Transaction(amount, date, note);
            transactions.Add(deposit);
        }
        public void Withdraw(decimal amount, DateTime date, string note) {
            //Eg: withdraw money to buy a car
            var withdrawal = new Transaction(-amount, date, note);
            transactions.Add(withdrawal);
        }
        private long GenerateAccountNumber() {
            return ((DateTimeOffset)DateTime.Now).ToUnixTimeMilliseconds();
        }
        //constructor
        public BankAccount(string owner, decimal initialBalance) {//function's name = class' name
            this.Owner = owner;
            this.AccountNumber = GenerateAccountNumber();
            //this.Balance = initialBalance;
            this.Deposit(initialBalance, DateTime.Now, "Initial balance");
            Console.WriteLine("Object initialized with \n" +
                              $"Account Number = {this.AccountNumber} \n" +
                              $"Owner = {this.Owner}\n" +
                              $"Balance={this.Balance}\n");
        }
    }
}
