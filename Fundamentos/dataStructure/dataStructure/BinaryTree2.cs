namespace dataStructure
{

    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

    public class Solution
    {
        public TreeNode SortedArrayToBST(int[] nums)
        {
            if (nums.Length == 0) return null;

            int middle = nums.Length / 2;
            TreeNode node = new TreeNode(nums[middle]);
            node.left = SortedArrayToBST(nums.Take(middle).ToArray());
            node.right = SortedArrayToBST(nums.Skip(middle + 1).ToArray());

            return node;
        }
    }

}