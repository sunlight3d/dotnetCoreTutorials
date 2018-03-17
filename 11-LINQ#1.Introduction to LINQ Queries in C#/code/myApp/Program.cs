/*
 Mr Nguyen Duc Hoang
 https://www.youtube.com/c/nguyenduchoang
 Programming videos in .NET core, and many more....
*/
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace myApp
{        
    class LinQExample
    {
        public static void queryIntNumbers()
        {
            //  1. Data source.
            int[] numbers = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            // 2. Query creation 
            var queryResult =
                from number in numbers
                where (number % 2) == 0
                select number;
            // 3. Query execution.
            foreach(int number in queryResult) //IEnumerable<int>
            {
                Console.Write($"{number} ");
            }
            Console.WriteLine("Convert query's result to array");
            var arrayOfNumbers = queryResult.ToArray();
            foreach (int number in arrayOfNumbers) //This is an array
            {
                Console.Write($"{number} ");
            }
            Console.WriteLine("Convert query's result to list");
            var listOfNumbers = queryResult.ToList();
            foreach (int number in listOfNumbers) //This is a List
            {
                Console.Write($"{number} ");
            }
            Console.WriteLine("End of conversion !");
        }
    }
    class Program
    {
        
        static void Main(string[] args)
        {
            LinQExample.queryIntNumbers();
        }
    }
}
