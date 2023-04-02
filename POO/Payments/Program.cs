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

    // Modificadores: private, protected, internal e public
    class Pagamento
    {
        public int Documento { get; set; }
        public DateTime _dataPagamento;
        private string _Nome;
        protected int Idade;
        internal double Altura;
        public DateTime DataPagamento
        {
            get { return _dataPagamento; }
            set { _dataPagamento = value; }
        }
        public virtual void Pagar()
        {

        }

        public void Pagar(string numero, DateTime dataPagamente)
        {

        }

    }

    class PagamentoBoleto : Pagamento
    {
        public string numeroBoleto;

        public override void Pagar()
        {

        }
    }
}