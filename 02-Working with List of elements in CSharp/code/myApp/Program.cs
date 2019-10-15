/*
 Mr Nguyen Duc Hoang
 https://www.youtube.com/c/nguyenduchoang
 Programming videos in .NET core, and many more....
*/
using System;
using System.Collections.Generic;

namespace myApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            var animals = new List<string> { "cat", "dog", "dinosaur", "tiger" };
            animals.Add("lion");
            foreach(var animal in animals) 
            {
                Console.WriteLine($"Hello {animal.ToUpper()}");
            }
            Console.WriteLine($"animal[1] = {animals[1]}");
            var indexOfLion = animals.IndexOf("lion");
            Console.WriteLine($"indexOfLion = {indexOfLion}");
            if (indexOfLion < 0) {
                Console.WriteLine("Cannot find \"lion\" in the list !");
            } else {
                Console.WriteLine($"Found lion at index = {indexOfLion}");
            }
            animals.Reverse();
            Console.WriteLine("Array after sort");
            foreach (var animal in animals) {
                Console.WriteLine($"{animal}"); //interpolated strings
            }
            Console.WriteLine($"animals has {animals.Count} elements");
        }
    }
}
