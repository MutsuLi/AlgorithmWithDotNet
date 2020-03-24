using System;
using System.Collections.Generic;

namespace Algorithms
{
    public class BreadthFirstSearch
    {
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }
        #region 113. Path Sum II

        //Given a binary tree and a sum, find all root-to-leaf paths where each path's sum equals the given sum.
        //sum=22
        // intput:
        //       5
        //      / \
        //     4   8
        //    /   / \
        //   11  13  4
        //  /  \    / \
        // 7    2  5   1
        // output:
        //[
        //    [5,4,11,2],
        //    [5,8,4,5]
        // ]
        public IList<IList<int>> PathSum(TreeNode root, int sum)
        {
            List<IList<int>> result = new List<IList<int>>();
            return result;
        }
        #endregion
    }
}
