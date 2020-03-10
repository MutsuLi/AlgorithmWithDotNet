using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Algorithms
{
    public class ArrayProblems
    {

        //两数之和
        //hash表
        public int[] TwoSum(int[] nums, int target)
        {
            Dictionary<int, int> Dict = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                Dict[nums[i]] = i;
            }
            for (int i = 0; i < nums.Length; i++)
            {
                int complement = target - nums[i];
                if (Dict.ContainsKey(complement) && Dict[complement] != i)
                {
                    return new int[] { i, Dict[complement] };
                }
            }
            return null;
        }

        //三数之和
        //数组+双指针
        public IList<IList<int>> ThreeSum(int[] nums)
        {
            List<List<int>> result = new List<List<int>>();
            int length = nums.Length;
            if (nums == null || nums.Length < 3) return result.ToArray();
            Array.Sort(nums);
            for (int i = 0; i < length; i++)
            {
                if (nums[i] > 0) break;
                if (i > 0 && nums[i] == nums[i - 1]) continue;
                int start = i + 1;
                int end = length - 1;
                while (start < end)
                {
                    int sum = nums[start] + nums[i] + nums[end];
                    if (sum < 0) start++;
                    else if (sum == 0)
                    {
                        result.Add(new List<int>() { nums[i], nums[start], nums[end] });
                        while (start < end && nums[start] == nums[start + 1]) start++;
                        while (start < end && nums[end] == nums[end - 1]) end--;
                        start++;
                        end--;
                    }
                    else if (sum > 0)
                    {
                        end--;
                    }
                }
            }
            return result.ToArray();
        }

        //4Sum
        //数组+双指针
        public IList<IList<int>> FourSum(int[] nums, int target)
        {
            IList<IList<int>> result = new List<IList<int>>();
            int length = nums.Length;
            if (nums == null || nums.Length < 4) return result;
            Array.Sort(nums);
            for (int i = 0; i < length - 3; i++)
            {
                if (i > 0 && nums[i] == nums[i - 1]) continue;
                if (nums[i] + nums[i + 1] + nums[i + 2] + nums[i + 3] > target) break;
                if (nums[length - 4] + nums[length - 3] + nums[length - 2] + nums[length - 1] < target) continue;
                for (int j = i + 1; j < length - 2; j++)
                {
                    if (j > i + 1 && nums[j] == nums[j - 1]) continue;
                    int l = j + 1;
                    int r = length - 1;
                    int currMax = nums[j] + nums[j + 1] + nums[r - 1] + nums[r];
                    int currMin = nums[j] + nums[i] + nums[j + 1] + nums[j];
                    if (currMin > target) break;
                    if (currMax < target) continue;
                    while (l < r)
                    {
                        int sum = nums[i] + nums[j] + nums[l] + nums[r];
                        if (sum < target)
                        {
                            l++;
                        }
                        else if (sum == target)
                        {
                            result.Add(new List<int>() { nums[i], nums[j], nums[l], nums[r] });
                            while (l < r && nums[l] == nums[l + 1]) l++;
                            while (i < j && l < r && nums[r] == nums[r - 1]) r--;
                            l++;
                            r--;
                        }
                        else if (sum > target)
                        {
                            r--;
                        }
                    }
                }
            }
            return result;
        }

        //三数之和
        //数组+双指针
        public IList<IList<int>> ThreeSum2(int[] nums)
        {
            IList<IList<int>> result = new List<IList<int>>();
            int length = nums.Length;
            if (nums == null && nums.Length < 3) return result;
            Array.Sort(nums);
            for (int i = 0; i < length; i++)
            {
                if (nums[i] > 0) break;
                if (i > 0 && nums[i] == nums[i - 1]) continue;
                int l = i + 1;
                int r = length - 1;
                while (l < r)
                {
                    int sum = nums[i] + nums[l] + nums[r];
                    if (sum < 0)
                    {
                        l++;
                    }
                    else if (sum == 0)
                    {
                        result.Add(new List<int>() { nums[i], nums[l], nums[r] });
                        while (l < r && nums[l] == nums[l + 1]) l++;
                        while (l < r && nums[r] == nums[r - 1]) r--;
                        l++;
                        r--;
                    }
                    else if (sum > 0)
                    {
                        r--;
                    }
                }
            }
            return result;
        }

        public static string toString(IList<IList<int>> results)
        {
            StringBuilder str = new StringBuilder();
            str.Append("[");
            foreach (var result in results)
            {
                str.Append("[");
                str.Append(String.Join(",", result.ToArray()));
                str.Append("]");
            }
            str.Append("]");
            return str.ToString();
        }

        public static string toString(List<List<int>> results)
        {
            StringBuilder str = new StringBuilder();
            str.Append("[");
            foreach (var result in results)
            {
                str.Append("[");
                str.Append(String.Join(",", result.ToArray()));
                str.Append("]");
            }
            str.Append("]");
            return str.ToString();
        }

        public static string toString(List<int> results)
        {
            StringBuilder str = new StringBuilder();
            str.Append("[");
            str.Append(String.Join(",", results.ToArray()));
            str.Append("]");
            return str.ToString();
        }

        //public class CompareFirst : IComparer
        //{
        //    // Call CaseInsensitiveComparer.Compare with the parameters reversed.
        //    public int Compare( Object x, Object y)
        //    {
        //        int[] arr1 = ((IEnumerable)x).Cast<object>()
        //                    .Select(a => (int)a)
        //                    .ToArray();

        //        int[] arr2 = ((IEnumerable)y).Cast<object>()
        //          .Select(a => (int)a)
        //          .ToArray();

        //        return (arr1[0] - arr2[0] < 0) ? 1 : 0;
        //    }
        //}

        //56. 合并区间
        //输入: [[1,3],[2,6],[8,10],[15,18]]
        //输出: [[1,6],[8,10],[15,18]]
        public int[][] mergeIntervals(int[][] intervals)
        {
            List<int[]> result = new List<int[]>();
            int length = intervals.Length;
            Array.Sort(intervals, (a, b) => a[0] - b[0]);
            //int[] preIntervals =null;
            for (int i = 0; i < length; i++)
            {
                if ((result == null || result.Count == 0) || intervals[i][0] > result.Last()[1])
                {
                    result.Add(intervals[i]);
                }
                else
                {
                    result.Last()[1] = Math.Max(result.Last()[1], intervals[i][1]);
                }
            }
            return result.ToArray();
        }

        //16. 最接近的三数之和
        //nums = [-1，2，1，-4] target = 1
        //2
        public int ThreeSumClosest(int[] nums, int target)
        {
            int length = nums.Length;
            if (nums == null && nums.Length < 3) return 0;
            Array.Sort(nums);
            int result = nums[0] + nums[1] + nums[nums.Length - 1];
            for (int i = 0; i < nums.Length; i++)
            {
                int start = i;
                int end = nums.Length - 1;
                while (start < end)
                {
                    int sum = nums[i] + nums[start] + nums[end];
                    if (Math.Abs(sum - target) < Math.Abs(result - target)) result = sum;
                    if (sum == target)
                    {
                        return sum;
                    }
                    else if (sum < target)
                    {
                        start++;
                    }
                    else if (sum > target)
                    {
                        end--;
                    }
                }

            }
            return result;
        }

        #region 31 下一个排列(重要)
        /*
        *
        * 实现获取下一个排列的函数，算法需要将给定数字序列重新排列成字典序中下一个更大的排列。
        * 如果不存在下一个更大的排列，则将数字重新排列成最小的排列（即升序排列）。
        * 
        *        
        */
        // 1,2,3 → 1,3,2
        // 3,2,1 → 1,2,3
        // 1,1,5 → 1,5,1
        // 1,4,3,2 ->21
        // 1, 4, 3, 2 => 
        //Cantor expansion

        public void NextPermutation(int[] nums)
        {
            // The above is the principle of the next_permutation () function.
            // 1.找到最大索引k，以使a [k] <a [k + 1]。如果不存在这样的索引，则该排列为最后的排列，直接翻转。
            // 2.找出最大索引l，使a [k] <a [l]。由于k +1是这样的索引，因此l定义明确，并且满足k <l。
            // 3.将a [k]与a [l]交换。
            // 4.反转从a [k +1]到最后一个元素a [n]的序列。
            if (nums == null || nums.Length <= 1) return;
            int i = nums.Length - 1;
            int j = i - 1;
            while (j > 0 && (nums[j] >= nums[i]))
            {
                i--;
                j--;
            }
            int l = j + 1;
            if (nums[j] >= nums[i])
            {
                Array.Reverse(nums);
            }
            else
            {
                for (int k = j; k <= nums.Length - 1; k++)
                {
                    if (nums[k] <= nums[j])
                    {
                        continue;
                    }
                    l = k;
                }
                if (nums[l] > nums[j])
                {
                    int temp = nums[j];
                    nums[j] = nums[l];
                    nums[l] = temp;
                }
                Array.Reverse(nums, i, nums.Length - i);

            }
            Console.WriteLine(toString(new List<int>(nums)));
        }
        #endregion 31   

    }
}

