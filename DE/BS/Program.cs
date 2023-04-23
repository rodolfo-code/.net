namespace Search
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Funfou");
            int[] vetor;

            vetor = new int[50] { 54, 26, 93, 40, 19, 3, 68, 77, 13, 79, 16, 27, 51, 58, 52, 38, 65, 15, 200, 95, 56, 24, 11, 60, 44, 45, 34, 39, 71, 74, 12, 7, 9, 70, 50, 48, 20, 90, 84, 61, 43, 35, 69, 97, 1, 82, 63, 28, 64, 100 };

            Search(vetor);
        }

        private static void Search(int[] array)
        {
            Array.Sort(array);

            foreach (var n in array)
            {
                Console.WriteLine(n);

            }

        }

    }
}