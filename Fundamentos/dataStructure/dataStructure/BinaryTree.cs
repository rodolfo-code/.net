// namespace dataStructure
// {
//     public class BinaryTree
//     {
//         public static void Tree(int[] sortedList)
//         {
//             int middle = sortedList.Length / 2;
//             TreeNode head = new TreeNode(sortedList[middle]);

//             foreach (int val in sortedList)
//             {
//                 TreeNode newNod = new TreeNode(val);

//                 head.SetBranch(newNode);
//             }
//             // Console.WriteLine(head.right?.right?.value);
//         }
//     }


//     public class TreeNode
//     {
//         public int value;
//         public TreeNode? left;
//         public TreeNode? right;

//         public TreeNode(int val)
//         {
//             this.value = val;
//             this.left = null;
//             this.right = null;
//         }


//     }
// }