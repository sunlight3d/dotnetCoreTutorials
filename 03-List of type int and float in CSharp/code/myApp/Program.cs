/*
 Mr Nguyen Duc Hoang
 https://www.youtube.com/c/nguyenduchoang
 Programming videos in .NET core, and many more....
*/
using System;
using System.Collections.Generic;

namespace myApp {
    class Program {
        static void Main(string[] args) {
            //Console.WriteLine("Hello World!");
            var fibonacciNumbers = new List<float> { 1, 1 };
            var level = 0;
            while(level < 100) {
                var lastNumber = fibonacciNumbers[fibonacciNumbers.Count - 1];
                var previousNumber = fibonacciNumbers[fibonacciNumbers.Count - 2];
                fibonacciNumbers.Add(lastNumber + previousNumber);
                level++;
            }
            foreach (var fibonacciNumber in fibonacciNumbers) { //press F5 to debug
                Console.Write($"{fibonacciNumber} ");
            }
        }
    }
}
