
namespace ValueReference
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] arr;
            arr = new string[2] { "sfd", "mbmb" };
            // arr[0] = "reee";

            var arr3 = arr;

            Console.WriteLine(arr[0]);

        }
    }
}