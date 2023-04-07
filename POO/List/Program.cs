using System.Linq;

namespace List
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // IList<Payment> payments = new List<Payment>();
            var payments = new List<Payment>();
            payments.Add(new Payment(1));
            payments.Add(new Payment(2));
            payments.Add(new Payment(3));
            payments.Add(new Payment(4));
            payments.Add(new Payment(5));

            foreach (var item in payments)
            {
                Console.WriteLine(item.Id);
            }

            var paidPayments = new List<Payment>();

            paidPayments.AddRange(payments);

            var paymentWhere = payments.Where(x => x.Id == 3); // Retorna lista
            var paymentFirst = payments.First(x => x.Id == 3); // Retorna um item apenas
            // var payment = payments.Count(x => x.Id == 3); 
            // var payment = payments.Skip(); 
            // var payment = payments.tAKE(); 


            Console.WriteLine(paymentFirst.Id);

            payments.Remove(paymentFirst);

            foreach (var item in payments)
            {
                Console.WriteLine(item.Id);
            }
        }
    }

    public class Payment
    {
        public int Id { get; set; }

        public Payment(int id)
        {
            Id = id;
        }
    }
}