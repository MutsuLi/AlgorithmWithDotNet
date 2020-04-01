using System;
using System.Collections.Generic;

namespace Algorithms
{
    public class DataStructProblems
    {

        //Definition for singly-linked list


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
