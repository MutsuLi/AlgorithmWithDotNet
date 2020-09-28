using System;
using System.Collections.Generic;

namespace Algorithms
{
    public class LinkListProblems
    {
        public string name;
        public IList<List<int>> paramList;
        public enum Methods
        {
            SwapNodesInPairs = 24,
            //RotateList = 61,
            RemoveDuplicatesfromSortedListII = 82,
            //ReverseLinkedListII = 92,
            LinkedListCycle = 141,
            LinkedListCycleII = 142,
            //InsertionSortList = 147
        }
        public static string handler(string name, IList<List<int>> paramList)
        {
            Methods method = (Methods)Enum.Parse(typeof(Methods), name);
            ListNode head = ListNode.arrayToListNode(paramList[0]);
            switch (method)
            {
                case Methods.SwapNodesInPairs:
                    return SwapPairs(head).toString();
                // case Methods.RotateList:
                //     return RotateRight(head, paramList[1][0]).toString();
                case Methods.RemoveDuplicatesfromSortedListII:
                    return DeleteDuplicates(head).toString();
                // case Methods.ReverseLinkedListII:
                //     return ReverseBetween(head, paramList[1][0], paramList[1][1]).toString();
                case Methods.LinkedListCycle:
                    HasCycle(head);
                    return head.toString();
                case Methods.LinkedListCycleII:
                    DetectCycle(head);
                    return head.toString();
                    // case Methods.InsertionSortList:
                    //     return InsertionSortList(head).toString();
            }
            return "";
        }

        // Definition for singly-linked list
        #region 24. Swap Nodes in Pairs
        // Given a linked list, swap every two adjacent nodes and return its head.
        // You may not modify the values in the list's nodes, only nodes itself may be changed.
        // Given 1->2->3->4, you should return the list as 2->1->4->3.
        public static ListNode SwapPairs(ListNode head)
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
        #region 61. Rotate List
        // Given a linked list, rotate the list to the right by k places, where k is non-negative.
        // Input: 1->2->3->4->5->NULL, k = 2
        // Output: 4->5->1->2->3->NULL
        // Input: 0->1->2->NULL, k = 4
        // Output: 2->0->1->NUL
        public static ListNode RotateRight(ListNode head, int k)
        {
            if (head == null || head.next == null) return head;
            ListNode dummy = new ListNode(-1);
            dummy.next = head;
            ListNode curr = head;
            ListNode pre = head;
            ListNode lengthPoint = head;
            int length = 1;
            while (lengthPoint.next != null)
            {
                lengthPoint = lengthPoint.next;
                length++;
            }
            int count = 1;
            while (curr.next != null)
            {
                if (count - 1 >= k % length)
                {
                    pre = pre.next;
                }
                curr = curr.next;
                count++;
            }
            if (k % length > 0)
            {
                ListNode first = pre.next;
                pre.next = null;
                curr.next = dummy.next;
                dummy.next = first;
            }
            return dummy.next;
        }
        #endregion

        #region 92. Reverse Linked List II
        // Input: 1->2->3->4->5->NULL, m = 2, n = 4
        // Output: 1->4->3->2->5->NULL
        // Input: 1->2->3->4->5->NULL m=1 n=5
        public static ListNode ReverseBetween(ListNode head, int m, int n)
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
        #region 147. Insertion Sort List
        // Sort a linked list using insertion sort.
        // Input: 4->2->1->3
        // Output: 1->2->3->4
        // Input: -1->5->3->4->0
        // Output: -1->0->3->4->5
        public static ListNode InsertionSortList(ListNode head)
        {
            return head;
        }
        #endregion

        #region 141. Linked List Cycle
        //Given a linked list, determine if it has a cycle in it.
        //To represent a cycle in the given linked list, we use an integer pos which represents the position (0-indexed) in the linked list where tail connects to. 
        //If pos is -1, then there is no cycle in the linked list.
        //Input: head = [3,2,0,-4], pos = 1
        //Output: true
        public static bool HasCycle(ListNode head)
        {
            if (head == null || head.next == null) return false;
            ListNode slowPointer = head;
            ListNode fastPointer = head;
            do
            {
                slowPointer = slowPointer.next;
                fastPointer = fastPointer.next.next;
            } while (slowPointer != fastPointer && slowPointer != null && fastPointer != null && slowPointer.next != null && fastPointer.next != null);
            return (slowPointer == fastPointer);
        }
        #endregion

        #region 142. Linked List Cycle II

        // Given a linked list, return the node where the cycle begins. If there is no cycle, return null.
        // Input: head = [3,2,0,-4], pos = 1
        // Output: tail connects to node index 1
        // Explanation: There is a cycle in the linked list, where tail connects to the second node.

        // Input: head = [1], pos = -1
        // Output: no cycle
        // Explanation: There is no cycle in the linked list.
        public static ListNode DetectCycle(ListNode head)
        {
            if (head == null || head.next == null) return null;
            ListNode slowPointer = head;
            ListNode fastPointer = head;
            do
            {
                slowPointer = slowPointer.next;
                fastPointer = fastPointer.next.next;
            } while (slowPointer != fastPointer && slowPointer != null && fastPointer != null && slowPointer.next != null && fastPointer.next != null);

            if (slowPointer != fastPointer) return null;
            ListNode result = head;
            // Find the "entrance" to the cycle.
            while (result != slowPointer)
            {
                result = result.next;
                slowPointer = slowPointer.next;
            }
            return result;
        }
        #endregion

        #region 82. Remove Duplicates from Sorted List II
        // Given a sorted linked list, delete all nodes that have duplicate numbers, leaving only distinct numbers from the original list.
        // Return the linked list sorted as well.
        // Input: 1->2->3->3->4->4->5
        // Output: 1->2->5
        // Input: 1->1->1->2->3
        // Output: 2->3
        public static ListNode DeleteDuplicates(ListNode head)
        {
            if (head == null || head.next == null) return head;
            ListNode dummy = new ListNode(int.MinValue);
            ListNode former = dummy;
            ListNode end = null;
            ListNode pre = head;
            ListNode next = head.next;
            dummy.next = head;
            bool hasDuplicate = false;
            while (pre != null && next != null)
            {
                if (pre.val == next.val)
                {
                    end = next.next;
                    hasDuplicate = true;
                }
                else
                {
                    if (hasDuplicate)
                    {
                        former.next = end;
                        hasDuplicate = false;
                    }
                    else
                    {
                        former = pre;
                    }
                }
                pre = pre.next;
                next = next.next;
                if (pre == null || next == null) break;
            }
            if (hasDuplicate) former.next = end;
            return dummy.next;
        }
        #endregion
    }
}
