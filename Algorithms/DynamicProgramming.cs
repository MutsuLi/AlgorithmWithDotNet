using System;
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

        //70. 爬楼梯
        //面试题 08.01. 三步问题
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

        //A robot is located at the top-left corner of a m x n grid (marked 'Start' in the diagram below).
        // The robot can only move either down or right at any point in time. 
        //The robot is trying to reach the bottom-right corner of the grid (marked 'Finish' in the diagram below).
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
                dpMax = Math.Max(dpMax * nums[i], nums[i]);
                dpMin = Math.Min(dpMin * nums[i], nums[i]);
                max = Math.Max(dpMax, max);
                // Console.WriteLine($"{i}----dpMax:{dpMax} dpMin:{dpMin} max:{max}");
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
            #endregion first try
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
                int columnNum = triangle[i].Count;
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
        // dp[i,j]=max(dp[i-1][j-1],dp[i-1][j],dp[i][j])+1 //dp[i][j] 以(i,j)右下顶点的正方形边长 i>1 j>1
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
                        Console.WriteLine(maxsqlen);
                    }

                }
            }
            return maxsqlen * maxsqlen;
        }
        #endregion
    }
}
