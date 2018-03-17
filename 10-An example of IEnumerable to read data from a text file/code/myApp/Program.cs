/*
 Mr Nguyen Duc Hoang
 https://www.youtube.com/c/nguyenduchoang
 Programming videos in .NET core, and many more....
*/
using System;
using System.Collections.Generic;
using System.IO;

namespace myApp
{    
    public class Point
    {
        public Double X { get; set; }
        public Double Y { get; set; }
        public Point(Double x, Double y)
        {
            this.X = x;
            this.Y = y;
        }
        public void ShowInfo()
        {
            Console.WriteLine($"x = {this.X}, y = {this.Y}");
        }
    }
    class Program
    {
        static IEnumerable<string> ReadFrom(string fileName)
        {
            var reader = File.OpenText(fileName);
            //Console.WriteLine($"Type of reader = {reader.GetType()}");
            string eachLine;
            while ((eachLine = reader.ReadLine()) != null)
            {
                yield return eachLine;
            }

        }
        static void Main(string[] args)
        {
            var lines = ReadFrom("textFile.txt");
            var points = new List<Point>();
            foreach (var line in lines)
            {
                //Console.WriteLine(line);
                var numbers = line.Split(new[] { ", " }, StringSplitOptions.None);
                var x = Convert.ToDouble(numbers[0]);
                var y = Convert.ToDouble(numbers[1]);
                var newPoint = new Point(x, y);
                points.Add(newPoint);
            }
            Console.WriteLine("List of points: ");
            foreach (var point in points)
            {
                point.ShowInfo();
            }
        }
    }
}
