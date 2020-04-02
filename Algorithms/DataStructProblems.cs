using System;
using System.Collections.Generic;

namespace Algorithms
{
    public class DataStructProblems
    {

        //Definition for singly-linked list

        #region 24. Swap Nodes in Pairs
        // Given a linked list, swap every two adjacent nodes and return its head.
        // You may not modify the values in the list's nodes, only nodes itself may be changed.
        // Given 1->2->3->4, you should return the list as 2->1->4->3.
        public ListNode SwapPairs(ListNode head)
        {
            if (head == null || head.next == null) return head;
            ListNode first = new ListNode(int.MinValue);
            first.next = head;
            ListNode pre = head;
            ListNode next = head.next;
            ListNode result = head.next;
            while (next != null)
            {
                pre.next = next.next;
                next.next = pre;
                first.next = next;
                if (pre.next == null) break;
                first = pre;
                pre = pre.next;
                next = pre.next;
            }
            return result;
        }

        #endregion

        #region 92. Reverse Linked List II
        // Input: 1->2->3->4->5->NULL, m = 2, n = 4
        // Output: 1->4->3->2->5->NULL
        // Input: 1->2->3->4->5->NULL m=1 n=5
        public ListNode ReverseBetween(ListNode head, int m, int n)
        {
            if (head.next == null || head == null || m == n) return head;
            ListNode curr = head;
            ListNode result = new ListNode(int.MinValue);
            ListNode pre = result;
            ListNode end = null;
            for (int i = 1; curr != null && i <= n; i++)
            {
                if (m == 1 && i == m)
                {
                    result.next = new ListNode(head.val);
                    end = result.next;
                    result.next.next = null;
                }
                else if (i < m)
                {
                    pre.next = new ListNode(curr.val);
                    pre = pre.next;
                }
                else if (i >= m && i <= n)
                {
                    ListNode assist = new ListNode(curr.val);
                    if (i == m) end = assist;
                    assist.next = pre.next;
                    pre.next = assist;
                }
                curr = curr.next;
            }
            if (m == 1)
            {
                result = result.next;
                if (curr != null) end.next = curr;
            }
            else
            {
                result = result.next;
                end.next = curr;
            }
            return result;
        }
        #endregion
    }
}
