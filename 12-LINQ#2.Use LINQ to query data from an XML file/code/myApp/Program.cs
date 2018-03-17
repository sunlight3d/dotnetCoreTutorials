/*
 Mr Nguyen Duc Hoang
 https://www.youtube.com/c/nguyenduchoang
 Programming videos in .NET core, and many more....
*/
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace myApp
{        
    class LinQExample
    {
        public static void queryXMLFile(string fileName)
        {
            //  1. Data source.
            var xmlDocument = XDocument.Load(@fileName);
            // 2. Query creation
            IEnumerable<string> filmNames = from film in xmlDocument.Descendants("film")
                                                 //where (int)film.Element("releaseYear") == 1977
                                                 //where (int)film.Element("releaseYear") > 1900
                                                 select film.Element("name").Value;
            //Query result => object => contain name, releaseYear => how to do this ?
            var foundedFilms = from film in xmlDocument.Descendants("film")
                               //where (int)film.Element("releaseYear") > 1900
                               select new
                               {
                                   Name = film.Element("name").Value,
                                   ReleaseYear = film.Element("releaseYear").Value
                               };

            // 3. Query execution.
            /*
            foreach (var filmName in filmNames)
            {
                Console.WriteLine($"{filmName}");
            }
            */
            foreach (var foundedFilm in foundedFilms)
            {
                Console.WriteLine($"Name: {foundedFilm.Name}, ReleaseYear: {foundedFilm.ReleaseYear}");
            }
        }
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
            //LinQExample.queryIntNumbers();
            LinQExample.queryXMLFile("films.xml");
        }
    }
}
