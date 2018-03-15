/*
 Mr Nguyen Duc Hoang
 https://www.youtube.com/c/nguyenduchoang
 Programming videos in .NET core, and many more....
*/
using System;

namespace myApp
{    
    interface IAnimal 
    {
        void Move();
        void Eat();
    }
    interface IMammal
    {
        void Feed();
        bool HasBreast { get; set; }
    }
    class Animal
    {
        protected int Height { get; set; }
    }
    class Dog: Animal, IAnimal, IMammal {
        private bool hasBreast; //backing store
        public void Move()
        {
            this.Height = 100;
            Console.WriteLine($"Dog is moving, Height = {this.Height}");
        }
        public void Eat()
        {
            Console.WriteLine("Dog is eating");
        }
        //Implement for IMammal
        public void Feed()
        {
            Console.WriteLine("Dog is feeding");
        }
        public bool HasBreast 
        { 
            get
            {
                Console.WriteLine("Calling getter...");
                return this.hasBreast;
            }
            set
            {
                Console.WriteLine("Calling setter...");
                this.hasBreast = value;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            var dog = new Dog();
            dog.Move();
            dog.Eat();
            dog.Feed();
            dog.HasBreast = true;
            //Console.WriteLine($"dog.HasBreast = {dog.HasBreast}");
        }
    }
}
