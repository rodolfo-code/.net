namespace Strings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /* ========== ID UNICO ========== */
            var id = Guid.NewGuid();

            // OU

            id = new Guid("3c610723-573a-4aca-aee8-a11e809dac6b");
            Console.WriteLine(id);

            /* ========== INTERPOLAÇÃO de STRING ========== */
            var price = 10.2;
            var texto = "O preço é: " + price;
            Console.WriteLine(texto);
            // OU
            var texto2 = string.Format("O preço do produto é {0}", price);
            Console.WriteLine(texto2);
            //ou
            var texto3 = $"O preço é {price}";

            /* ========== COMPARAÇÃO de STRING ========== */

            var palavra = "Testando";
            Console.WriteLine(palavra.CompareTo("Testando"));

            //Retorna 0 se for igual e 1 se for diferente

            var palavra2 = "Testando o contains";
            //Ignora o case sensitive
            Console.WriteLine(palavra2.Contains("estando", StringComparison.OrdinalIgnoreCase));



        }
    }
}