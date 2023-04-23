namespace Search
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Funfou");
            int[] vetor = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };

            Console.WriteLine(vetor.Length - 1);

            var numero = Search(vetor, 0, vetor.Length - 1, 20);
            Console.WriteLine($"Numero encontrado: {numero}");
        }

        static public int Search(int[] array, int first, int last, int num)
        {
            var indice = (last + first) / 2;

            if (array[indice] == num)
            {
                return array[indice];
            }
            if (array[indice] > num)
            {
                return Search(array, first, indice - 1, num);
            }
            return Search(array, indice + 1, last, num);
        }

    }
}