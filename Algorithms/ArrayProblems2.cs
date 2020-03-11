using System;

namespace Algorithms
{
    public class ArrayProblems2
    {
        //Given an array nums containing n + 1 integers where each integer is between 1 and n(inclusive), prove that at least one duplicate number must exist.
        //Assume that there is only one duplicate number, find the duplicate one. 
        //Input: [1,3,4,2,2]
        //Output: 2  
        //Input: [3,1,6,5,3,4,2]
        // Output: 3

        #region 287. Find the Duplicate Number
        //Floyd's Tortoise and Hare
        // tag:low&&quick pointer 
        public int FindDuplicate(int[] nums)
        {
            int length = nums.Length;
            if (null == nums || length == 0) return 0;
            int tortoise = nums[0], hare = nums[0];

            do
            {
                //(motivate linkedlist)
                tortoise = nums[tortoise];
                hare = nums[nums[hare]];
            } while (hare != tortoise);

            int ptr1 = nums[0];
            int ptr2 = tortoise;

            // Find the "entrance" to the cycle.
            while (ptr1 != ptr2)
            {
                ptr1 = nums[ptr1];
                ptr2 = nums[ptr2];
            }
            return ptr1;
        }

        #endregion
    }
}
