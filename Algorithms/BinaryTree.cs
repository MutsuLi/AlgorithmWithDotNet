using System;
using System.Collections.Generic;

namespace Algorithms
{
    public class BinaryTree
    {
        #region 144. Binary Tree Preorder Traversal
        //Given a binary tree, return the preorder traversal of its nodes' values.
        //Input: [1,null,2,3]
        //Output: [1,2,3]
        public IList<int> PreorderTraversal(TreeNode root)
        {
            List<int> result = new List<int>();
            if (root == null) return result;
            Stack<TreeNode> assist = new Stack<TreeNode>();
            assist.Push(root);
            TreeNode curr = root;
            while (assist.Count != 0)
            {
                curr = assist.Pop();
                result.Add((int)curr.val);
                if (curr.right != null)
                {
                    assist.Push(curr.right);
                }
                if (curr.left != null)
                {
                    assist.Push(curr.left);
                }
            }
            return result;
        }
        #endregion

        #region 94. Binary Tree Inorder Traversal
        // Input: [1,null,2,3]
        // Output: [1,3,2]
        public List<int> InorderTraversal(TreeNode root)
        {
            List<int> result = new List<int>();
            if (root == null) return result;
            Stack<TreeNode> assit = new Stack<TreeNode>();
            TreeNode curr = root;
            while (assit.Count != 0 || curr != null)
            {
                while (curr != null)
                {
                    assit.Push(curr);
                    curr = curr.left;
                }
                curr = assit.Pop();
                result.Add((int)curr.val);
                curr = curr.right;
            }
            return result;
        }
        #endregion

        #region 145. Binary Tree Postorder Traversal
        public IList<int> PostorderTraversal(TreeNode root)
        {
            List<int> result = new List<int>();
            if (root == null) return result;
            Stack<TreeNode> assist = new Stack<TreeNode>();
            Stack<TreeNode> output = new Stack<TreeNode>();
            assist.Push(root);
            TreeNode curr = null;
            while (assist.Count != 0)
            {
                curr = assist.Pop();
                output.Push(curr);
                if (curr.left != null) assist.Push(curr.left);
                if (curr.right != null) assist.Push(curr.right);
            }
            while (output.Count != 0)
            {
                result.Add((int)output.Pop().val);
            }
            return result;
        }
        #endregion

        #region 102. Binary Tree Level Order Traversal
        // Given binary tree [3,9,20,null,null,15,7]
        // [
        //   [3],
        //   [9,20],
        //   [15,7]
        // ]
        public IList<IList<int>> LevelOrder(TreeNode root)
        {
            List<IList<int>> result = new List<IList<int>>();
            if (root == null) return result;
            Queue<TreeNode> assist = new Queue<TreeNode>();
            assist.Enqueue(root);
            while (assist.Count != 0)
            {
                List<int> temp = new List<int>();
                int levelCount = assist.Count;     //notice be used to record quantity of nodes in current level
                for (int i = 0; i < levelCount; i++)
                {
                    TreeNode curr = assist.Dequeue();
                    temp.Add((int)curr.val);
                    if (curr.left != null)
                    {
                        assist.Enqueue(curr.left);
                    }
                    if (curr.right != null)
                    {
                        assist.Enqueue(curr.right);
                    }
                }
                result.Add(temp);
            }
            return result;
        }
        #endregion

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

        #region 96. Unique Binary Search Trees
        //Given n, how many structurally unique BST's (binary search trees) that store values 1 ... n?
        public int NumTrees(int n)
        {
            return 0;
        }
        #endregion


    }
}
