using System;

namespace Struct
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Product mouse = new Product(4, "HP", 5.8);

            Console.WriteLine(mouse.Id);
            Console.WriteLine(mouse.Name);
        }
    }
}