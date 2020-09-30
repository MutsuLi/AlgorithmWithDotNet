using System;
using System.Text;
using System.Collections.Generic;

namespace Algorithms
{
    public class DynamicProgramming
    {
        //Maximum Subarray
        //53. 最大子序和
        //[-2,1,-3,4,-1,2,1,-5,4]
        public int MaxSubArraySum(int[] nums)
        {
            if (nums.Length == 0 || nums == null) return 0;
            int length = nums.Length;
            int[] Dip = new int[length];
            Dip[0] = nums[0];
            int max = Dip[0];
            for (int i = 1; i < length; i++)
            {
                Dip[i] = Math.Max(nums[i], Dip[i - 1] + nums[i]);
                max = Math.Max(Dip[i], max);
            }
            return max;
        }

        // 70. Climbing Stairs
        // You are climbing a stair case. It takes n steps to reach to the top.
        // Each time you can either climb 1 or 2 steps. In how many distinct ways can you climb to the top?
        // Note: Given n will be a positive integer.

        // Input: 3
        // Output: 3
        // Explanation: There are three ways to climb to the top.
        // 1. 1 step + 1 step + 1 step
        // 2. 1 step + 2 steps
        // 3. 2 steps + 1 step


        public int climbStair(int n)
        {
            if (n == 1) return 1;
            if (n == 2) return 2;
            if (n == 3) return 4;
            /*
            *
            * 大数阶乘，大数的排列组合等，一般都要求将输出结果对1000000007取模 为什么总是1000000007呢= =大概≖‿≖✧是因为：（我猜的，不服你打我呀~） 
            *1. 1000000007是一个质数
            *2. int32位的最大值为2147483647，所以对于int32位来说1000000007足够大
            *3. int64位的最大值为2^63-1，对于1000000007来说它的平方不会在int64中溢出 所以在大数相乘的时候，因为(a∗b)%c=((a%c)∗(b%c))%c，所以相乘时两边都对1000000007取模，再保存在int64里面不会溢出
            * 
            */
            int mod = 1000000007;
            int[] dp = new int[n + 1];
            dp[1] = 1;
            dp[2] = 2;
            dp[3] = 4;
            for (int i = 4; i <= n; i++)
            {
                //取余公式 (a+b)%m=a%m+b%m
                dp[i] = ((dp[i - 2] % mod + dp[i - 1] % mod) % mod + dp[i - 3] % mod) % mod;
            }
            return dp[n];
        }

        //746. 使用最小花费爬楼梯
        public int MinCostClimbingStairs(int[] cost)
        {
            int length = cost.Length;
            if (length == 0) return 0;
            int[] dp = new int[length];
            dp[0] = cost[0];
            dp[1] = cost[1];
            if (length == 1) return dp[0];
            for (int i = 2; i < length; i++)
            {
                dp[i] = Math.Min(cost[i] + dp[i - 1], cost[i] + dp[i - 2]);
            }
            //dp[i]=min(nums[i+1]+dp[i-1],nums[i+2]+dp[i-1])
            return dp[length - 1] > dp[length - 2] ? dp[length - 2] : dp[length - 1];
        }

        //面试题 16.17. 连续数列
        //给定一个整数数组（有正数有负数），找出总和最大的连续数列，并返回总和
        //input [-2,1,-3,4,-1,2,1,-5,4]
        //output 6
        public int MaxSeqSubArray(int[] nums)
        {
            int length = nums.Length;
            if (length == 0) return 0;
            //List<int> dp = new List<int>();
            //dp.Add(nums[0]);
            //int max = dp[0];
            //for (int i = 1; i < length; i++)
            //{
            //    dp.Add(Math.Max(nums[i], dp.Last() + nums[i]));
            //    max = Math.Max(max, dp.Last());
            //}
            //return max;
            int sum = nums[0];
            int max = sum;
            for (int i = 1; i < length; i++)
            {
                if (sum < 0)
                {
                    sum = nums[i];
                }
                else
                {
                    sum += nums[i];
                }

                if (sum > max)
                {
                    max = sum;
                }

            }
            return max;
        }


        #region 64
        // Given a m x n grid filled with non-negative numbers, find a path from top left to bottom right which minimizes the sum of all numbers along its path.
        // Note: You can only move either down or right at any point in time.
        // Input:
        // [
        //   [1,3,1],
        //   [1,5,1],
        //   [4,2,1]    
        // ]
        // Output: 7
        // Explanation: Because the path 1→3→1→1→1 minimizes the sum.
        //dp[i][j]=Min(d[i-1][j],d[i][j-1])+grid[i][j];
        public int MinPathSum(int[][] grid)
        {
            int rowNum = grid.Length; //n
            int columnNum = grid[0].Length; //m
            int[][] dp = new int[rowNum][];
            for (int i = 0; i < rowNum; i++)
            {
                dp[i] = new int[columnNum];
                for (int j = 0; j < columnNum; j++)
                {
                    if (i == 0 && j == 0)
                    {
                        dp[i][j] = grid[i][j];
                    }
                    else if (i == 0)
                    {
                        dp[i][j] = dp[i][j - 1] + grid[i][j];
                    }
                    else if (j == 0)
                    {
                        dp[i][j] = dp[i - 1][j] + grid[i][j];
                    }
                    else
                    {
                        dp[i][j] = Math.Min(dp[i - 1][j], dp[i][j - 1]) + grid[i][j];
                    }
                }
            }
            return dp[rowNum - 1][columnNum - 1];
        }

        #endregion

        #region 62. Unique Paths

        // A robot is located at the top-left corner of a m x n grid (marked 'Start' in the diagram below).
        // The robot can only move either down or right at any point in time. 
        // The robot is trying to reach the bottom-right corner of the grid (marked 'Finish' in the diagram below).
        // How many possible unique paths are there?

        // Input: m = 3, n = 2
        // Output: 3
        //1---1---1
        //1---1---1
        //1---1---1
        //dp[i][j]=d[i-1]d[j]+d[i]d[j-1]

        public int UniquePaths(int m, int n)
        {
            int rowNum = m;
            int columnNum = n;
            int[][] dp = new int[rowNum][];
            for (int i = 0; i < rowNum; i++)
            {
                dp[i] = new int[columnNum];
                for (int j = 0; j < columnNum; j++)
                {
                    if (i == 0 || j == 0)
                    {
                        dp[i][j] = 1;
                    }
                    else
                    {
                        dp[i][j] = dp[i - 1][j] + dp[i][j - 1];
                    }
                }
            }
            return dp[rowNum - 1][columnNum - 1];
        }
        #endregion

        #region 63. Unique Paths II
        // A robot is located at the top-left corner of a m x n grid (marked 'Start' in the diagram below).
        // The robot can only move either down or right at any point in time. 
        // The robot is trying to reach the bottom-right corner of the grid (marked 'Finish' in the diagram below).
        // Now consider if some obstacles are added to the grids. How many unique paths would there be?
        // Input:
        // [
        //   [0,1,0,0,0],
        //   [1,0,0,0,0],
        //   [0,0,0,0,0],
        //   [0,0,0,0,0]
        // ]
        // Output: 2

        public int UniquePathsWithObstacles(int[][] obstacleGrid)
        {
            if (null == obstacleGrid || obstacleGrid.Length == 0 || obstacleGrid[0][0] == 1) return 0;

            int rowNum = obstacleGrid.Length;
            int columnNum = obstacleGrid[0].Length;
            int[][] dp = new int[rowNum][];

            for (int i = 0; i < rowNum; i++)
            {
                dp[i] = new int[columnNum];

                for (int j = 0; j < columnNum; j++)
                {
                    if (i == 0 && j == 0)
                    {
                        dp[i][j] = 1;
                    }
                    else if (obstacleGrid[i][j] == 1)
                    {
                        dp[i][j] = 0;
                    }
                    else if (i == 0)
                    {
                        dp[i][j] = dp[i][j - 1];
                    }
                    else if (j == 0)
                    {
                        dp[i][j] = dp[i - 1][j];
                    }
                    else
                    {
                        dp[i][j] = dp[i - 1][j] + dp[i][j - 1];
                    }
                }
            }
            return dp[rowNum - 1][columnNum - 1];
        }
        #endregion

        #region 152. Maximum Product Subarray
        // Given an integer array nums, find the contiguous subarray within an array (containing at least one number) which has the largest product.
        // Example 1:
        // Input: [2,3,-2,4]
        // Output: 6
        // Explanation: [2,3] has the largest product 6.
        // dp[i]=max(nums[i],dp[i-1]*nums[i])
        public int MaxProduct(int[] nums)
        {
            int dpMax = 1, dpMin = 1;
            int max = int.MinValue;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] < 0)
                {
                    int temp = dpMax;
                    dpMax = dpMin;
                    dpMin = temp;
                }
                dpMax = Math.Max(nums[i], nums[i] * dpMax);
                dpMin = Math.Min(nums[i], nums[i] * dpMin);
                max = Math.Max(dpMax, max);
            }
            return max;
        }

        #endregion
        #region 300. Longest Increasing Subsequence

        // Given an unsorted array of integers, find the length of longest increasing subsequence.
        // Input: [10,9,2,5,3,7,101,18]
        // Output: 4 
        // Explanation: The longest increasing subsequence is [2,3,7,101], therefore the length is 4.
        // Note:
        // There may be more than one LIS combination, it is only necessary for you to return the length.
        // Your algorithm should run in O(n2) complexity.
        // Follow up: Could you improve it to O(n log n) time complexity?

        public int LengthOfLIS(int[] nums)
        {
            #region first try
            //  int maxLength = 0;
            // if (nums.Length == 0 && nums == null) return maxLength;
            // if (nums.Length == 1) return 1;
            // for (int i = 0; i < nums.Length; i++)
            // {
            //     int tempMax = 1;
            //     int currentMax = nums[i];
            //     int currentSecMax = nums[i];
            //     for (int j = i + 1; j < nums.Length; j++)
            //     {
            //         if (nums[j] > currentMax)
            //         {
            //             tempMax++;
            //             currentSecMax = currentMax;
            //             currentMax = nums[j];
            //         }
            //         else if (nums[j] < currentMax && nums[j] > currentSecMax)
            //         {
            //             currentMax = nums[j];
            //         }
            //         maxLength = Math.Max(maxLength, tempMax);
            //     }
            // }
            // return maxLength;
            #endregion first try
            if (nums.Length == 0 || nums == null) return 0;
            if (nums.Length == 1) return 1;
            int[] dp = new int[nums.Length];
            dp[0] = 1;
            int maxlength = 1;
            for (int i = 1; i < nums.Length; i++)
            {
                int currentlength = 0;
                for (int j = 0; j < i; j++)
                {
                    if (nums[j] < nums[i])
                    {
                        currentlength = Math.Max(currentlength, dp[j]);
                    }
                    // maxLength = Math.Max(maxLength, tempMax);
                }
                dp[i] = currentlength + 1;
                maxlength = Math.Max(dp[i], maxlength);
            }
            return maxlength;
        }

        #endregion

        #region 120. Triangle

        // Given a triangle, find the minimum path sum from top to bottom.
        // Each step you may move to adjacent numbers on the row below.
        // For example, given the following triangle
        // [
        //      [2],
        //     [3,4],
        //    [6,5,7],
        //   [4,1,8,3]
        // ]
        // The minimum path sum from top to bottom is 11 (i.e., 2 + 3 + 5 + 1 = 11).
        // Note:Bonus point if you are able to do this using only O(n) extra space, where n is the total number of rows in the triangle.
        // dp[i][j]=min(dp[i-1][j-1],dp[i-1][j])+triangle[i][j]
        public int MinimumTotal(IList<IList<int>> triangle)
        {
            int rowNum = triangle.Count;
            int[] dp = new int[rowNum];
            int prev = 0;
            for (int i = 0; i < rowNum; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    int curr = dp[j];
                    if (i == 0 && j == 0) dp[j] = triangle[i][j];
                    else if (j == 0) dp[j] = curr + triangle[i][j];
                    else if (j == i) dp[j] = prev + triangle[i][j];
                    else
                    {
                        dp[j] = Math.Min(prev, curr) + triangle[i][j];
                    }
                    prev = curr;
                }
            }
            int minValue = dp[0];
            for (int j = 1; j < rowNum; j++)
            {
                minValue = Math.Min(dp[j], minValue);
            }
            return minValue;
            #region space O(n^2)
            // int rowNum = triangle.Count;
            // int[][] dp = new int[rowNum][];
            // for (int i = 0; i < rowNum; i++)
            // {
            //     int columnNum = triangle[i].Count;
            //     dp[i] = new int[columnNum];
            //     for (int j = 0; j < columnNum; j++)
            //     {
            //         if (i == 0 && j == 0) dp[i][j] = triangle[i][j];
            //         else if (j == 0) dp[i][j] = dp[i - 1][j] + triangle[i][j];
            //         else if (j == columnNum - 1) dp[i][j] = dp[i - 1][j - 1] + triangle[i][j];
            //         else if (j > 0 && j < columnNum - 1) dp[i][j] = Math.Min(dp[i - 1][j - 1], dp[i - 1][j]) + triangle[i][j];
            //     }
            // }
            // int minValue = dp[rowNum - 1][0];
            // for (int j = 1; j < rowNum; j++)
            // {
            //     minValue = Math.Min(dp[rowNum - 1][j], minValue);
            // }
            // return minValue;
            #endregion O(n^2)

        }
        #endregion

        #region 113. Path Sum II
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }
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

        #region 221. Maximal Square
        // Given a 2D binary matrix filled with 0's and 1's, find the largest square containing only 1's and return its area.
        // Input: 
        // 1 0 1 0 0
        // 1 0 1 1 1
        // 1 1 1 1 1
        // 1 0 0 1 0

        // Output: 4
        // dp[i,j]=min(dp[i-1][j-1],dp[i-1][j],dp[i][j])+1 //dp[i][j] 以(i,j)右下顶点的正方形边长 i>1 j>1
        /*   
        *  0 1 1 1 1 
        *  1 1 1 1 1 
        *  1 1 1 1 1 
        *  1 1 1 1 1 
        *  1 1 1 1 ?
        *  ?=min(4,4,3)
        */
        public int MaximalSquare(char[][] matrix)
        {
            if (matrix.Length == 0 || matrix == null) return 0;
            int width = matrix[0].Length;
            int length = matrix.Length;
            int[][] dp = new int[length][];
            int maxsqlen = 0;
            for (int i = 0; i < length; i++)
            {
                dp[i] = new int[width];
                for (int j = 0; j < width; j++)
                {
                    if (i == 0 || j == 0)
                    {
                        if (matrix[i][j] == '1')
                        {
                            dp[i][j] = 1;
                            maxsqlen = Math.Max(maxsqlen, dp[i][j]);
                        }
                    }
                    else if (matrix[i][j] == '1')
                    {
                        dp[i][j] = Math.Min(Math.Min(dp[i - 1][j - 1], dp[i - 1][j]), dp[i][j - 1]) + 1;
                        maxsqlen = Math.Max(maxsqlen, dp[i][j]);
                    }

                }
            }
            return maxsqlen * maxsqlen;
        }
        #endregion
        #region  85. Maximal Rectangle
        // Given a 2D binary matrix filled with 0's and 1's, find the largest rectangle containing only 1's and return its area.
        // Input:
        // [
        //   ["1","0","1","0","0"],
        //   ["1","0","1","1","1"],
        //   ["1","1","1","1","1"],
        //   ["1","0","0","1","0"]
        // ]
        // Output: 6
        public int MaximalRectangle(char[][] matrix)
        {
            return 0;
        }
        #endregion
        #region 279. Perfect Squares
        // Given a positive integer n, find the least number of perfect square numbers (for example, 1, 4, 9, 16, ...) which sum to n.
        // Input: n = 12
        // Output: 3 
        // Explanation: 12 = 4 + 4 + 4.
        // dp[i]=dp[i-1]+max(...)
        public int NumSquares(int n)
        {

            // for square in square_nums:
            //     if k < square:
            //         break
            //     new_num = minNumSquares(k - square) + 1
            //     min_num = min(min_num, new_num)
            // return min_num

            int num = (int)Math.Sqrt(n) + 1;
            int[] SquareDict = new int[num];
            for (int i = 0; i < num; i++)
            {
                SquareDict[i] = i * i;
            }
            int[] dp = new int[n + 1];
            for (int i = 0; i < n + 1; i++)
            {
                dp[i] = i;
            }
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j < num; j++)
                {
                    if (i < SquareDict[j]) break;
                    dp[i] = Math.Min(dp[i], dp[i - SquareDict[j]] + 1);
                    // Console.WriteLine($"lastValue:{lastValue + SquareDict[j]} count:{count + 1}");
                }
            }
            return dp[n];
        }
        #endregion
        #region 264. Ugly Number II
        // Write a program to find the n-th ugly number.
        // Ugly numbers are positive numbers whose prime factors only include 2, 3, 5. 

        // Input: n = 10
        // Output: 12
        // Explanation: 1, 2, 3, 4, 5, 6, 8, 9, 10, 12 is the sequence of the first 10 ugly numbers.
        // 1,2,3,5
        // dp[i]=min(d[i-1]*2,dp[i-1]*3,dp[i-1]*5)
        // 2^x * 3^y * 5^z
        //dp[i]=2^x+1*3
        public int NthUglyNumber(int n)
        {
            int[] dp = new int[n + 1];
            int index1 = 0;
            int index2 = 0;
            int index3 = 0;
            dp[0] = 1;
            for (int i = 1; i < n + 1; i++)
            {
                dp[i] = Math.Min(Math.Min(dp[index1] * 2, dp[index2] * 3), dp[index3] * 5);
                if (dp[i] == dp[index1] * 2) { index1++; }
                if (dp[i] == dp[index2] * 3) { index2++; }
                if (dp[i] == dp[index3] * 5) { index3++; }
            }
            return dp[n - 1];
        }
        #endregion

        #region 139. Word Break
        //Given a non-empty string s and a dictionary wordDict containing a list of non-empty words,
        //determine if s can be segmented into a space-separated sequence of one or more dictionary words.
        //Note:
        //1.The same word in the dictionary may be reused multiple times in the segmentation.
        //2.You may assume the dictionary does not contain duplicate words.

        // Input: s = "applepenapple", wordDict = ["apple", "pen"]
        // Output: true

        // Input: s = "catsandog", wordDict = ["cats", "dog", "sand", "and", "cat"]
        // Output: false
        #region recursion
        // public bool WordBreak(string s, IList<string> wordDict)
        // {
        //     HashSet<string> wordDicts = new HashSet<string>(wordDict);
        //     Dictionary<int, bool> temp = new Dictionary<int, bool>();
        //     if (s.Length == 0 || wordDict.Count == 0)
        //     {
        //         return false;
        //     }
        //     return RecursiveWordBreak(s, wordDicts, 0, temp);
        // }
        // public bool RecursiveWordBreak(string s, HashSet<string> wordDicts, int recurIndex, Dictionary<int, bool> temp)
        // {
        //     if (s.Length == recurIndex) return true;
        //     if (temp.ContainsKey(recurIndex)) return temp[recurIndex];
        //     for (int currIndex = recurIndex + 1; currIndex <= s.Length; currIndex++)
        //     {
        //         if (wordDicts.Contains(s.Substring(recurIndex, currIndex - recurIndex)))
        //         {
        //             if (RecursiveWordBreak(s, wordDicts, currIndex, temp))
        //             {
        //                 return temp[recurIndex] = true;
        //             }
        //         }
        //     }
        //     return temp[recurIndex] = false;
        // }
        #endregion recursion
        public bool WordBreak(string s, IList<string> wordDict)
        {
            HashSet<string> wordDictSet = new HashSet<string>(wordDict);
            bool[] dp = new bool[s.Length + 1];
            dp[0] = true;
            for (int i = 1; i <= s.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    //Console.WriteLine(s.Substring(j, i - j));
                    if (dp[j] && wordDictSet.Contains(s.Substring(j, i - j)))
                    {
                        dp[i] = true;
                        break;
                    }
                }
            }
            return dp[s.Length];
        }
        #endregion


        #region 5. Longest Palindromic Substring
        // Input: "babad"
        // Output: "bab"
        // Note: "aba" is also a valid answer.
        public string LongestPalindrome(string s)
        {

            if (s.Length == 0) return s;
            Dictionary<int, int> dp = new Dictionary<int, int>();
            int maxLength = 1;
            dp.Add(1, 0);
            for (int i = 0; i < s.Length - 1; i++)
            {
                i = findMiddle(s, i, dp);
            }
            foreach (var each in dp)
            {
                maxLength = Math.Max(maxLength, each.Key);
            }
            return s.Substring(dp[maxLength], maxLength);
        }
        public int findMiddle(string s, int low, Dictionary<int, int> dp)
        {
            int high = low;
            while (high < s.Length - 1 && s[high + 1] == s[low])
            {
                high++;
            }
            int middle = high;
            while (low > 0 && high < s.Length - 1 && s[low - 1] == s[high + 1])
            {
                low--;
                high++;
            }
            dp[high - low + 1] = low;
            return middle;
        }

        #endregion

        #region  55. Jump Game
        // Input: [2,3,1,1,4]
        // Output: true
        // dp[i]=Math.max(dp[i-1]+1,dp[i-1]+nums[dp[i-1]]])
        // 3 1 3 2 7
        public bool CanJump(int[] nums)
        {
            if (nums.Length == 0 && nums[0] == 0) return false;
            bool?[] memo = new bool?[nums.Length];
            memo[nums.Length - 1] = true;
            return RecursiveCanJump(nums, 0, memo);
        }
        public bool RecursiveCanJump(int[] nums, int sum, bool?[] memo)
        {
            if (memo[sum] != null)
            {
                return memo[sum] == true ? true : false;
            }
            int maxLength = Math.Min(sum + nums[sum], nums.Length - 1);
            for (int i = sum + 1; i <= maxLength; i++)
            {
                if (RecursiveCanJump(nums, i, memo))
                {
                    memo[sum] = true;
                    return true;
                }
            }
            memo[sum] = false;
            return false;
        }
        #endregion

        #region 121. Best Time to Buy and Sell Stock
        // Say you have an array for which the ith element is the price of a given stock on day i.
        // If you were only permitted to complete at most one transaction (i.e., buy one and sell one share of the stock), design an algorithm to find the maximum profit.
        // Note that you cannot sell a stock before you buy one.

        // Input: [7,1,5,3,6,4]
        // Output: 5
        // Explanation: Buy on day 2 (price = 1) and sell on day 5 (price = 6), profit = 6-1 = 5.
        // Not 7-1 = 6, as selling price needs to be larger than buying price.

        // Input: [7,6,4,3,1]
        // Output: 0
        // Explanation: In this case, no transaction is done, i.e. max profit = 0.

        // public int MaxProfit(int[] prices)
        // {
        //     int[] dp = new int[prices.Length];
        //     dp[0] = 0;
        //     int max = 0;
        //     for (int i = 0; i < prices.Length; i++)
        //     {
        //         for (int j = i; j < prices.Length; j++)
        //         {
        //             int temp = prices[j] - prices[i];
        //             dp[i] = Math.Max(temp > 0 ? temp : 0, dp[i]);
        //         }
        //         max = Math.Max(dp[i], max);
        //     }
        //     return max;
        // }
        public int MaxProfit(int[] prices)
        {
            if (prices.Length == 0) return 0;
            int[] dp = new int[prices.Length];
            dp[0] = 0;
            int min = prices[0];
            for (int i = 1; i < prices.Length; i++)
            {
                min = Math.Min(min, prices[i]);
                dp[i] = dp[i] = Math.Max(prices[i] - min > 0 ? prices[i] - min : 0, dp[i - 1]);
            }
            return dp[prices.Length - 1];
        }
        #endregion

    }

}
