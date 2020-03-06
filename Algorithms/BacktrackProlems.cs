
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms
{


    public class BacktrackProlems
    {
        /// <summary>
        ///39. 组合总和
        /// 给定一个无重复元素的数组 candidates 和一个目标数 target ，找出 candidates 中所有可以使数字和为 target 的组合。
        /// 输入:candidates = [2,3,6,7], target = 7
        /// 输出:[[7],[2,2,3]]
        /// </summary>
        /// <param name="candidates"></param>
        /// <param name="target"></param>
        /// <returns></returns>

        public IList<IList<int>> CombinationSum(int[] candidates, int target)
        {
            List<IList<int>> result = new List<IList<int>>();
            List<int> recursionList = new List<int>();
            Array.Sort(candidates);
            combinationBackTrack(candidates, recursionList, result, target, 0);
            return result;
        }

        public void combinationBackTrack(int[] candidates, List<int> recursionList, List<IList<int>> result, int target, int layer)
        {

            if (target < recursionList.Sum()) return;
            if (target == recursionList.Sum())
            {
                result.Add(new List<int>(recursionList));
                return;
            }

            for (int i = layer; i < candidates.Length; i++)
            {
                recursionList.Add(candidates[i]);
                combinationBackTrack(candidates, recursionList, result, target, i);
                recursionList.RemoveAt(recursionList.Count - 1);
            }
        }
        #region leetcode 40
        /// <summary>
        ///组合总和 II
        /// 给定一个数组 candidates 和一个目标数 target ，找出 candidates 中所有可以使数字和为 target 的组合。
        /// candidates 中的每个数字在每个组合中只能使用一次。
        /// 输入:candidates = [10,1,2,7,6,1,5], target = 8
        /// [
        /// [1, 7],
        /// [1, 2, 5],
        /// [2, 6],
        /// [1, 1, 6]
        /// ]
        /// 输出:[[7],[2,2,3]]
        /// </summary>
        /// <param name="candidates"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public IList<IList<int>> CombinationSum2(int[] candidates, int target)
        {
            List<IList<int>> result = new List<IList<int>>();
            List<int> recursionList = new List<int>();
            Array.Sort(candidates);
            combination2BackTrack(candidates, recursionList, result, target, 0);
            return result;
        }
        public void combination2BackTrack(int[] candidates, List<int> recursionList, List<IList<int>> result, int target, int layer)
        {

            if (target < recursionList.Sum()) return;
            if (target == recursionList.Sum())
            {
                result.Add(new List<int>(recursionList));
                return;
            }

            for (int i = layer; i < candidates.Length; i++)
            {
                if (candidates[i] == candidates[i - 1]) continue;
                recursionList.Add(candidates[i]);
                combination2BackTrack(candidates, recursionList, result, target, i + 1);
                recursionList.RemoveAt(recursionList.Count - 1);
            }
        }

        #endregion
        #region leetcode 216
        /// <summary>
        ///组合总和 II
        /// 给定一个数组 candidates 和一个目标数 target ，找出 candidates 中所有可以使数字和为 target 的组合。
        /// candidates 中的每个数字在每个组合中只能使用一次。
        /// 输入:candidates = [10,1,2,7,6,1,5], target = 8
        /// [
        /// [1, 7],
        /// [1, 2, 5],
        /// [2, 6],
        /// [1, 1, 6]
        /// ]
        /// 输出:[[7],[2,2,3]]
        /// </summary>
        /// <param name="k"></param>
        /// <param name="n"></param>
        /// <returns></returns>

        public IList<IList<int>> CombinationSum3(int k, int n)
        {
            List<IList<int>> result = new List<IList<int>>();
            List<int> recursionList = new List<int>();
            int[] nums = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            combination3BackTrack(nums, recursionList, result, n, 0, k);
            return result;
        }
        public void combination3BackTrack(int[] candidates, List<int> recursionList, List<IList<int>> result, int target, int layer, int num)
        {

            if (target < recursionList.Sum()) return;
            if (recursionList.Count == num && target == recursionList.Sum())
            {
                result.Add(new List<int>(recursionList));
                return;
            }

            for (int i = layer; i < candidates.Length; i++)
            {
                recursionList.Add(candidates[i]);
                combination3BackTrack(candidates, recursionList, result, target, i + 1, num);
                recursionList.RemoveAt(recursionList.Count - 1);
            }
        }
        #endregion
        #region 
        /// <summary>
        /// 给定一个没有重复数字的序列，返回其所有可能的全排列。
        /// 输入: [1,2,3]
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        /// 
        public IList<IList<int>> Permute(int[] nums)
        {
            List<IList<int>> result = new List<IList<int>>();
            List<int> recursionList = new List<int>(nums);
            permuteBacktrack(nums, 0, result, recursionList);
            return result;
        }

        public void permuteBacktrack(int[] nums, int layer, List<IList<int>> result, List<int> recursionList)
        {
            if (layer == nums.Length) { result.Add(new List<int>(recursionList)); }


            for (int i = layer; i < nums.Length; i++)
            {
                swap(recursionList, i, layer);
                permuteBacktrack(nums, layer + 1, result, recursionList);
                swap(recursionList, i, layer);
            }
        }

        public void swap(List<int> recursionList, int i, int j)
        {
            int temp = recursionList[i];
            recursionList[i] = recursionList[j];
            recursionList[j] = temp;
        }

        #endregion


        //401. 二进制手表
        public IList<String> ReadBinaryWatch(int num)
        {
            List<String> result = new List<String>();
            int[] nums = new int[10];
            binaryTrackBack(result, nums, 0, num);
            return result;
        }
        public void binaryTrackBack(List<String> result, int[] nums, int layer, int count)
        {
            if (count <= 0)
            {
                String time = caculate(nums);
                if (time.Length != 0 && time != null)
                {
                    result.Add(caculate(nums));
                }
                return;
            }
            for (int i = layer; i < nums.Length; i++)
            {
                nums[i] = 1;
                count--;
                binaryTrackBack(result, nums, i + 1, count);
                nums[i] = 0;
                count++;
            }

        }

        public string caculate(int[] nums)
        {
            string result = "";
            if (nums.Length == 0 && nums == null)
            {
                return result;
            }
            int hour = nums[3] + nums[2] * 2 + nums[1] * 4 + nums[0] * 8;
            if (hour >= 12) return result;
            int minute = nums[9] + nums[8] * 2 + nums[7] * 4 + nums[6] * 8 + nums[5] * 16 + nums[4] * 32;
            if (minute > 59) return result;
            return (minute < 10) ? hour + ":0" + minute : hour + ":" + minute;
        }
        #region 78
        // 78. 子集     
        // 输入: nums = [1,2,3]  
        public IList<IList<int>> Subsets(int[] nums)
        {
            List<IList<int>> result = new List<IList<int>>();
            List<int> recursionList = new List<int>(nums);
            subsetBackTrack(nums, recursionList, result, 0);
            return result;
        }
        public void subsetBackTrack(int[] nums, List<int> recursionList, List<IList<int>> result, int layer)
        {
            if (!result.Contains(recursionList))
            {
                result.Add(new List<int>(recursionList));
            }

            for (int i = layer; i < nums.Length; i++)
            {
                recursionList.Add(nums[i]);
                subsetBackTrack(nums, recursionList, result, i + 1);
                recursionList.RemoveAt(recursionList.Count - 1);
            }

        }
        #endregion

        #region 90
        public IList<IList<int>> SubsetsWithDup(int[] nums)
        {
            List<IList<int>> result = new List<IList<int>>();
            List<int> recursionList = new List<int>();
            Array.Sort(nums);
            SubsetsWithDupBackTrack(nums, recursionList, result, 0);
            return result;
        }

        public void SubsetsWithDupBackTrack(int[] nums, List<int> recursionList, List<IList<int>> result, int layer)
        {
            if (recursionList.Count <= nums.Length)
            {
                result.Add(new List<int>(recursionList));
            }

            for (int i = layer; i < nums.Length; i++)
            {
                if (i > layer && nums[i] == nums[i - 1]) continue;
                recursionList.Add(nums[i]);
                SubsetsWithDupBackTrack(nums, recursionList, result, i + 1);
                recursionList.RemoveAt(recursionList.Count - 1);
            }

        }
        #endregion

        //77. 组合
        public IList<IList<int>> Combine(int n, int k)
        {
            List<IList<int>> result = new List<IList<int>>();
            List<int> recursionList = new List<int>();
            int[] nums = new int[n];
            for (int i = 0; i < n; i++)
            {
                nums[i] = i + 1;
            }
            combineBackTrack(nums, recursionList, result, k, 0);
            return result;
        }


        public void combineBackTrack(int[] nums, List<int> recursionList, List<IList<int>> result, int k, int layer)
        {
            if (layer > nums.Length || recursionList.Count > k) return;
            if (recursionList.Count == k && !result.Contains(recursionList))
            {
                result.Add(new List<int>(recursionList));
            }

            for (int i = layer; i < nums.Length; i++)
            {
                recursionList.Add(nums[i]);
                combineBackTrack(nums, recursionList, result, k, i + 1);
                recursionList.RemoveAt(recursionList.Count - 1);
            }
        }

        #region 60
        /*
        *
        * 给出集合 [1,2,3,…,n]，其所有元素共有 n! 种排列。
        * 按大小顺序列出所有排列情况，并一一标记.给定 n 和 k，返回第 k 个排列。
        *
        *
        *
        *        
        */
        public List<IList<int>> GetPermutation(int n, int k)
        {
            List<IList<int>> result = new List<IList<int>>();
            List<int> recursionList = new List<int>();
            int[] nums = new int[n];
            for (int i = 0; i < n; i++)
            {
                nums[i] = i + 1;
            }
            GetPermutationBackTrack(nums, recursionList, result, k, n, 0);
            return result;
        }

        public void GetPermutationBackTrack(int[] nums, List<int> recursionList, List<IList<int>> result, int k, int n, int layer)
        {
            if (recursionList.Count > n) return;
            if (recursionList.Count == n)
            {
                result.Add(new List<int>(recursionList));
                return;
            }

            for (int i = layer; i < nums.Length; i++)
            {
                if (recursionList.Contains(nums[i])) continue;
                recursionList.Add(nums[i]);
                GetPermutationBackTrack(nums, recursionList, result, k, n, layer);
                recursionList.RemoveAt(recursionList.Count - 1);
            }
        }


        #endregion
    }
}
