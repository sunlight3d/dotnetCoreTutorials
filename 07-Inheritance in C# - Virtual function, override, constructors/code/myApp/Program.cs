/*
 Mr Nguyen Duc Hoang
 https://www.youtube.com/c/nguyenduchoang
 Programming videos in .NET core, and many more....
*/
using System;

namespace myApp
{
    public class Vehicle 
    {
        public string Color;
        protected int Miles;
        protected int Year;
        public virtual void Greet() 
        {
            Console.WriteLine("Hello, This is a Vehicle");           
        }
        //Constructor
        public Vehicle(string color, int miles, int year)
        {
            this.Color = color;
            this.Miles = miles;
            this.Year = year;
            Console.WriteLine("Instance Constructor of Vehicle, " +
                              $"color={this.Color}, " +
                              $"miles={this.Miles}, " +
                              $"year={this.Year}");
        }
        public static long productionDate;
        static Vehicle() 
        {
            Console.WriteLine("This is a Static Constructor");
            //this.Miles = 100;//Cannot access instance property from static constructor
            productionDate = DateTime.Now.Ticks;
        }
    }
    public class Bus: Vehicle 
    {
        protected int BusNumber;
        public override void Greet(){
            base.Greet();
            Console.WriteLine("Hello, This is a Bus");
        }
        //override constructor
        public Bus(string color, int miles, int year, int busNumber) : base(color, miles, year)
        {
            this.BusNumber = busNumber;
            Console.WriteLine("Instance Constructor of Bus, " +
                              $"busNumber={this.BusNumber}");
        }
    }
    public class MiniBus: Bus
    {
        public MiniBus(string color, int miles, int year, int busNumber) : base(color, miles, year, busNumber)
        {
            Console.WriteLine("Initialize MiniBus object");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            //var vehicle = new Vehicle("red", 1200, 2017);
            //vehicle.Color = "Red";
            //vehicle.Miles = 120;
            //vehicle.Greet();
            var bus = new Bus("green", 1300, 2018, 20);
            Console.WriteLine($"Bus.productionDate = {Bus.productionDate}");
            //bus.Greet();
        }
    }
}
