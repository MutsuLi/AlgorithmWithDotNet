using System;
using System.Collections.Generic;
namespace Algorithms
{
    public class RecursionProblems
    {
        #region 08.06. Hanota LCCI

        //  In the classic problem of the Towers of Hanoi, you have 3 towers and N disks of different sizes which can slide onto any tower. 
        //The puzzle starts with disks sorted in ascending order of size from top to bottom (i.e., each disk sits on top of an even larger one). 
        //You have the following constraints:
        // (1) Only one disk can be moved at a time.
        // (2) A disk is slid off the top of one tower onto another tower.
        // (3) A disk cannot be placed on top of a smaller disk.
        // Write a program to move the disks from the first tower to the last using stacks.

        // Input: A = [2, 1, 0], B = [], C = []
        //  Output: C = [2, 1, 0]
        // Example2:
        // Input: A = [1, 0], B = [], C = []
        // Output: C = [1, 0]
        public void Hanota(IList<int> A, IList<int> B, IList<int> C)
        {
            int num = A.Count;
            HanotaRecursion(num, A, B, C);
        }
        public void HanotaRecursion(int num, IList<int> original, IList<int> auxiliary, IList<int> target)
        {
            if (num == 1)
            {
                target.Add(original[original.Count - 1]);
                original.RemoveAt(original.Count - 1);
                return;
            }
            HanotaRecursion(num - 1, original, target, auxiliary);
            target.Add(original[original.Count - 1]);
            original.RemoveAt(original.Count - 1);
            HanotaRecursion(num - 1, auxiliary, original, target);
        }
        #endregion
    }
}