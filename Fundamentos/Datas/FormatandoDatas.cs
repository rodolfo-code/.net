namespace Datas
{
    internal class FormatandoDatas
    {
        public static void Format()
        {
            var data = DateTime.Now;

            var formatada = String.Format("{0:yyyy/MM/dd hh:mm:ss ff zzz}", data);
            var padrao = String.Format("{0:t}", data);
            var padrao2 = String.Format("{0:d}", data);
            var padrao3 = String.Format("{0:D}", data);
            Console.WriteLine(formatada);
            Console.WriteLine(padrao);
            Console.WriteLine(padrao2);
            Console.WriteLine(padrao3);

            // Incrementando valores

            Console.WriteLine(data.AddDays(12));
            Console.WriteLine(data.AddMonths(1));
            Console.WriteLine(data.AddYears(1));
        }
    }
}