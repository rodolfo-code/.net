// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");

// int someInt = 51;
// long longNumberCast = someInt;

// Console.WriteLine(longNumberCast);





namespace Casting
{

    public class Programa

    {

        static void Main(string[] args)
        {
            // int intResult = 5 / 2;
            // decimal someDecimal = Convert.ToDecimal(intResult);

            // Console.WriteLine(intResult);


            // string someString = "42rodolfo";
            // // int convertInt = Convert.ToInt32(someString);
            // // Console.WriteLine(convertInt);
            // int valueConverted;

            // bool canConvert = Int32.TryParse(someString, out valueConverted);

            // if (canConvert)
            // {
            //     Console.WriteLine("pode converter");
            // }
            // else
            // {
            //     Console.WriteLine("nao pode converter");
            // }

            MinhaClass.MinhaFuncao();


        }
    }

    class MinhaClass
    {
        public static string MinhaFuncao()
        {
            Console.WriteLine("Informe um número entre -100 e 100:");
            string? someNumber = Console.ReadLine();

            bool success = int.TryParse(someNumber, out int userValue);

            if (!success)
            {

                Console.WriteLine("Entrada inválida! Não é um número.");
                return "Entrada invalida";
            }

            if (userValue > 100 || userValue < -100)
            {
                Console.WriteLine("Entrada inválida! Valor não está no range.");
                return "Entrada inválida! Valor não está no range.";
            }
            else
            {
                Console.WriteLine("Número escolhido!");
                return "Número escolhido!";

            }
        }
    }
}