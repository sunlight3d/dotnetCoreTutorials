/*
 Mr Nguyen Duc Hoang
 https://www.youtube.com/c/nguyenduchoang
 Programming videos in .NET core, and many more....
*/
using System;

namespace myApp
{    
    public abstract class Animal 
    {
        protected abstract string Name { get; set; }
        public abstract void MakeNoise();
    }
    public class Cat: Animal 
    {
        private string name;//This is a field, "backing store"
        public override void MakeNoise()
        {
            Console.WriteLine($"{this.Name} says: Meao meao");
        }
        public Cat(string aName)
        {
            this.name = aName;
        }
        //public abstract void Eat();
        protected sealed override string Name
        {
            get
            {
                return this.name.ToUpper();
            }
            set
            {
                this.name = value;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //var animal = new Animal();//Cannot initialize an Abstract class
            //Animal animal = new Animal();//Cannot initialize an Abstract class
            Cat cat = new Cat("Mimi");
            cat.MakeNoise();
        }
    }
}
