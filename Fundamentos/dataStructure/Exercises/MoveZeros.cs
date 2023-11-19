using dataStructure;

namespace Exercises
{
    public class MoveZeros
    {
        public int[] Solution(int[] list)
        {
            for (int i = 0; i < list.Length; i++)
            {
                list[1] = 0;
                if (list[i] == 0 && (i + 1) != list.Length)
                {
                    list[i] = list[i + 1];
                    // list[i + 1] = 0;
                    Console.WriteLine("teste: " + list[i + 1]);
                }
            }


            return list;
        }
    }
}