

namespace Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu()
        {
            Console.Clear();
            Console.WriteLine("Selecione a operação: \n 1 - soma, \n 2 - subtração, \n 3 - multiplicação, \n 4 - divisão");

            Console.WriteLine("------------------------");

            short operador = short.Parse(Console.ReadLine());

            Operators operadores = new Operators();

            switch (operador)
            {
                case 1: operadores.Soma(); break;
                case 2: operadores.Subtracao(); break;
                case 3: operadores.Multiplicacao(); break;
                case 4: operadores.Divisao(); break;
                default: Menu(); break;
            }

            Console.ReadKey();
            Menu();
        }

    }
}