namespace Exceptions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Erros sao Exceptions

            var arr = new int[3];


            try
            {
                Cadastrar("");
                // for (var index = 0; index < 10; index++)
                // {
                //     Console.WriteLine(arr[index]);
                // }
            }

            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine(ex.InnerException);
                Console.WriteLine(ex.Message);
                Console.WriteLine("Não encontrei o índice na lista");
            }

            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.InnerException);
                Console.WriteLine(ex.Message);
                Console.WriteLine("Falha ao cadastrar texto");
            }

            catch (MinhaException ex)
            {
                // IndexOutOfRangeException
                Console.WriteLine(ex.InnerException);
                Console.WriteLine(ex.QuandoAconteceu);
                Console.WriteLine("Erro customizado");
            }

            catch (Exception ex)
            {
                // IndexOutOfRangeException
                Console.WriteLine(ex.InnerException);
                Console.WriteLine(ex.Message);
                Console.WriteLine("Algo deu errado");
            }

            finally
            {
                Console.WriteLine("Chegou ao fim");
            }
        }

        private static void Cadastrar(string texto)
        {
            if (string.IsNullOrEmpty(texto))
                // throw new Exception("O texto nao pode ser lido pois é nulo!");
                // throw new ArgumentNullException("Não pode ser nulo");
                throw new MinhaException(DateTime.Now);
        }

        public class MinhaException : Exception
        {
            public MinhaException(DateTime date)
            {
                QuandoAconteceu = date;
            }
            public DateTime QuandoAconteceu { get; set; }
        }
    }
}