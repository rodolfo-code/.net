namespace dataStructure
{
    public class SumBST
    {
        public int totalSum;

        public int RangeSumBST(TreeNode root, int low, int high)
        {
            if (root == null) return 0;

            if (root.val >= low && root.val <= high)
            {
                this.totalSum += root.val;
            }

            RangeSumBST(root.left, low, high);
            RangeSumBST(root.right, low, high);


            return totalSum;

        }

    }
}