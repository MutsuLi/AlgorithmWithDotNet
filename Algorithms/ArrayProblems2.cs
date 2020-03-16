using System;

namespace Algorithms
{
    public class ArrayProblems2
    {
        #region Name
        // Given a non-empty array of integers, every element appears three times except for one, which appears exactly once. Find that single one.
        // Your algorithm should have a linear runtime complexity. Could you implement it without using extra memory?
        // Input: [0,1,0,1,0,1,99]
        // Output: 99
        // 0^n=n n^n=0 1^n=~n
        // not ~ and & or |
        // seenOnce = ~seenTwice & (seenOnce ^ num);
        // seenTwice = ~seenOnce & (seenTwice ^ num);
        public int SingleNumber(int[] nums)
        {
            int seenOnce = 0;
            int seenTwice = 0;
            foreach (int num in nums)
            {
                seenOnce = ~seenTwice & (seenOnce ^ num);
                seenTwice = ~seenOnce & (seenTwice ^ num);
                Console.WriteLine($"num:{num},seenOnce:{seenOnce},seenTwice:{seenTwice}");
            }
            return seenOnce;
        }
        #endregion



    }
}
