using System;

namespace Alglorithms
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
                else {
                    sum += nums[i];
                }

                if (sum>max)
                {
                    max = sum;               
                }

            }
            return max;
        }

    }
}
