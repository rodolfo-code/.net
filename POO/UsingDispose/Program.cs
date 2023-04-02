namespace UsingDispose
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var pagamento = new Pagamento())
            {
                Console.WriteLine("Processando pagamente");
            }
        }


    };

    public class Pagamento : IDisposable
    {
        public Pagamento()
        {

        }

        public void Dispose()
        {
            Console.WriteLine("Finalizand pagamento");
        }
    }

}