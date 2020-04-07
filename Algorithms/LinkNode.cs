using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Algorithms
{

    public class ListNode
    {
        public int val;
        public ListNode next;

        //    public int length=0;
        public ListNode(int x)
        {
            this.val = x;
            //        length++;
        }
        public static ListNode arrayToListNode(int[] arr)
        {
            ListNode[] nodes = new ListNode[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] != int.MaxValue)
                {
                    nodes[i] = new ListNode(arr[i]);
                }
                else
                {
                    nodes[i] = null;
                }
            }
            ListNode node;
            for (int i = 0; i < nodes.Length - 1; i++)
            {
                node = nodes[i];
                node.next = nodes[i + 1];
            }
            return nodes[0];
        }

        public static ListNode arrayToListNode(int[] arr, int index)
        {
            ListNode[] nodes = new ListNode[arr.Length];
            ListNode next = null;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] != int.MaxValue)
                {
                    nodes[i] = new ListNode(arr[i]);
                    if (i == index) next = nodes[i];
                }
                else
                {
                    nodes[i] = null;
                }
            }
            ListNode node;
            for (int i = 0; i < nodes.Length - 1; i++)
            {
                node = nodes[i];
                node.next = nodes[i + 1];
            }
            if (index > -1) nodes[nodes.Length - 1].next = next;
            return nodes[0];
        }

        public static int[] ListNodeToArray(ListNode headNode)
        {
            List<int> result = new List<int>();
            while (headNode != null)
            {
                result.Add(headNode.val);
                headNode = headNode.next;
            }
            return result.ToArray();
        }




        public String toString()
        {
            int[] temp = ListNodeToArray(this);
            return toString(new List<int>(temp));
        }

        public ListNode deleteDuplicates(ListNode head)
        {
            ListNode curr = head;
            while (curr != null && curr.next != null)
            {
                if (curr.val == curr.next.val)
                {
                    ListNode node = curr.next;
                    curr.next = node.next;
                    node.next = null;
                }
                else
                {
                    curr = curr.next;
                }
            }
            return head;
        }
        public static string toString(IList<IList<int>> results)
        {
            StringBuilder str = new StringBuilder();
            str.Append("[");
            foreach (var result in results)
            {
                str.Append("[");
                str.Append(String.Join(",", result.ToArray()));
                str.Append("]");
            }
            str.Append("]");
            return str.ToString();
        }

        public static string toString(List<List<int>> results)
        {
            StringBuilder str = new StringBuilder();
            str.Append("[");
            foreach (var result in results)
            {
                str.Append("[");
                str.Append(String.Join(",", result.ToArray()));
                str.Append("]");
            }
            str.Append("]");
            return str.ToString();
        }

        public static string toString(List<int> results)
        {
            StringBuilder str = new StringBuilder();
            str.Append("[");
            str.Append(String.Join(",", results.ToArray()));
            str.Append("]");
            return str.ToString();
        }
    }
}
