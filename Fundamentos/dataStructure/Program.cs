using dataStructure;
using Exercises;

public class DataStructure
{
    public static void Main()
    {
        // Lists.Linked();

        int[] sortedList = { 3, 5, 7, 10, 15, 18 };
        Solution newSolution = new Solution();
        TreeNode newTree = newSolution.SortedArrayToBST(sortedList);

        SumBST newSumRange = new SumBST();

        newSumRange.RangeSumBST(newTree, 7, 15);
        Console.WriteLine(newSumRange.totalSum);

        // MoveZeros moveZeros = new();

        // int[] newList = moveZeros.Solution(sortedList);

        // foreach (int num in newList)
        // {
        //     Console.WriteLine(num);
        // }

        // int[] listOfIndexes = { 3, 2, 4 };
        // int target = 6;

        // TwoSum twoSum = new TwoSum();
        // int[] result = twoSum.FindIndexes(listOfIndexes, target);

        // foreach (int num in result)
        // {
        //     Console.WriteLine(num);

        // }

    }
}