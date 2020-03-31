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
        public ListNode ReverseBetween(ListNode head, int m, int n)
        {
            if (head.next == null || head == null || m == n) return head;
            ListNode curr = head;
            ListNode pre = null;
            ListNode end = null;
            for (int i = 1; curr != null && i <= n; i++)
            {
                if (i < m)
                {
                    ListNode temp = new ListNode(curr.val);
                    pre = temp;
                    temp.next = null;
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
            end.next = curr;
            return pre;
        }
        #endregion
    }
}
