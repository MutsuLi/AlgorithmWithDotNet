using System;
using System.Collections.Generic;

public class TreeNode
{
    public int? val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int? x) { val = x; }
    public String toString()
    {
        return val.ToString();
    }

    // public static TreeNode int? mkTree(T[] arr)
    // {
    //     TreeNode int?[] nodes = new TreeNode int?[arr.Length + 1];
    //     Queue<TreeNode int?> assit = new Queue<TreeNode int?>();
    //     for (int i = 0; i < arr.Length; i++)
    //     {
    //         assit.Enqueue(new TreeNode int?(arr[i]));
    //         while (assit.Count != 0)
    //         {
    //             TreeNode int? curr = assit.Dequeue();
    //             if (curr == null)
    //             {
    //                 curr.left = null;
    //             }
    //             else
    //             {
    //                 curr.left = arr[i];
    //             }
    //         }
    //     }
    //     return nodes[0];
    // }


    public static TreeNode makeTree(int?[] trees)
    {
        if (trees.Length == 0)
            return null;
        TreeNode[] treeNodes = new TreeNode[trees.Length + 1];
        for (int i = 1; i < treeNodes.Length; i++)
        {
            if (trees[i - 1] == null)
            {
                treeNodes[i] = null;
            }
            else
            {
                treeNodes[i] = new TreeNode(trees[i - 1]);
            }
        }

        TreeNode treeNode = null;
        for (int i = 1, index = 2; i < treeNodes.Length && index < treeNodes.Length; i++)
        {
            treeNode = treeNodes[i];
            if (treeNode == null) continue;
            treeNode.left = treeNodes[index];
            if (index + 1 < treeNodes.Length)
                treeNode.right = treeNodes[index + 1];
            index += 2;
        }
        return treeNodes[1];
    }
}
