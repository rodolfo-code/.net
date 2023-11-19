// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");

// int someInt = 51;
// long longNumberCast = someInt;

// Console.WriteLine(longNumberCast);

namespace Casting
{

    public class Programa
    {
        public static void Main()
        {
            int intResult = 5 / 2;
            decimal someDecimal = Convert.ToDecimal(intResult);

            Console.WriteLine(intResult);


            string someString = "42rodolfo";
            // int convertInt = Convert.ToInt32(someString);
            // Console.WriteLine(convertInt);
            int valueConverted;

            bool canConvert = Int32.TryParse(someString, out valueConverted);

            if (canConvert)
            {
                Console.WriteLine("pode converter");
            }
            else
            {
                Console.WriteLine("nao pode converter");
            }

        }
    }
}