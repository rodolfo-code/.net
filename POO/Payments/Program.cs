namespace Payments
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var pagamentoBoleto = new PagamentoBoleto();
            pagamentoBoleto.Pagar();
            pagamentoBoleto.numeroBoleto = "1234";
        }
    }

    class Pagamento
    {
        public DateTime Vencimento;
        public void Pagar()
        {

        }

    }

    class PagamentoBoleto : Pagamento
    {
        public string numeroBoleto;
    }
}