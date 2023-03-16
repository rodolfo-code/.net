

using System.Globalization;

namespace Currency
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();

            decimal valor = 10.25m;

            Console.WriteLine(valor.ToString("C", CultureInfo.CreateSpecificCulture("pt-BR")));
            Console.WriteLine(valor.ToString("C", CultureInfo.CreateSpecificCulture("es-ES")));
            Console.WriteLine(valor.ToString("C", CultureInfo.CreateSpecificCulture("en-GB")));
        }
    }
}