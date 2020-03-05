using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Alglorithms
{
    public class BacktrackProblems
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

        /// <summary>
        ///40. 组合总和 II
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
                if (i > layer && candidates[i] == candidates[i - 1]) continue;
                recursionList.Add(candidates[i]);
                combination2BackTrack(candidates, recursionList, result, target, i + 1);
                recursionList.RemoveAt(recursionList.Count - 1);
            }
        }
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
    }

}
