using System;
using System.Collections.Generic;

namespace Algorithms
{
    public class BinarySearch
    {
        #region 704. Binary Search
        //Given n, how many structurally unique BST's (binary search trees) that store values 1 ... n?
        public int Search(int[] nums, int target)
        {
            if (nums.Length == 0) return -1;
            int start = 0;
            int end = nums.Length - 1;
            while (start < end)
            {
                int mid = (start + end) / 2;
                if (nums[mid] == target)
                {
                    return mid;
                }
                else if (nums[mid] < target)
                {
                    start = mid + 1;
                }
                else
                {
                    end = mid - 1;
                }
            }
            return -1;
        }
        #endregion
        #region 33. Search in Rotated Sorted Array
        //4, 5, 6, 7, 0, 1, 2, 3
        //3, 4, 5, 6, 7, 0, 1, 2
        public int RotatedSortArrayI(int[] nums, int target)
        {
            if (nums.Length == 0) return -1;
            int start = 0;
            int end = nums.Length - 1;
            while (start <= end)
            {
                int mid = (start + end) / 2;
                if (nums[mid] == target)
                {
                    return mid;
                }
                else if (nums[start] > nums[mid])
                {
                    if (target < nums[start] && nums[mid] < target)
                    {
                        start = mid + 1;
                    }
                    else //if (target < nums[start] && nums[mid] > target || target >= nums[start])
                    {
                        end = mid - 1;
                    }
                }
                else if (nums[start] <= nums[mid])
                {
                    if (target < nums[start] || target >= nums[start] && nums[mid] < target)
                    {
                        start = mid + 1;
                    }
                    else //if (target >= nums[start] && nums[mid] > target)
                    {
                        end = mid - 1;
                    }
                }
            }
            return -1;
        }
        #endregion
        #region 81. Search in Rotated Sorted Array II
        //2,5,6,0,0,1,2
        //0,0,1,2,2,5,6
        //1,3,1,1,1
        //1,1,1,1,3
        public bool RotatedSortArrayII(int[] nums, int target)
        {
            if (nums.Length == 0) return false;
            int start = 0;
            int end = nums.Length - 1;
            while (start <= end)
            {
                int mid = (start + end) / 2;
                if (nums[mid] == target)
                {
                    return true;
                }
                else if (nums[start] == nums[mid] && nums[end] == nums[mid])
                {
                    start++;
                    end--;
                }
                else if (nums[start] > nums[mid])
                {
                    if (target < nums[start] && nums[mid] < target)
                    {
                        start = mid + 1;
                    }
                    else //if (target < nums[start] && nums[mid] > target || target >= nums[start])
                    {
                        end = mid - 1;
                    }
                }
                else if (nums[start] <= nums[mid])
                {
                    if (target < nums[start] || target >= nums[start] && nums[mid] < target)
                    {
                        start = mid + 1;
                    }
                    else //if (target >= nums[start] && nums[mid] > target)
                    {
                        end = mid - 1;
                    }
                }
            }
            return false;
        }
        #endregion
        #region 162. Find Peak Element
        //1,2,1,3,5,6,4
        public int FindPeakElement(int[] nums)
        {
            if (nums.Length == 0 || nums.Length == 1) return 0;
            int start = 0;
            int end = nums.Length - 1;
            while (start <= end)
            {
                int mid = (start + end) / 2;
                if (nums[mid] < nums[mid + 1])
                {
                    start = mid + 1;
                }
                else
                {
                    end = mid - 1;
                }
            }
            return start;
        }
        #endregion
        #region 153. Find Minimum in Rotated Sorted Array

        // Input: [3,4,5,1,2] 
        // Output: 1
        //2 3 4 5 1
        //1 2 3 4 5 
        //5,1,2,3,4
        //4 5 1 2 3 
        public int FindMin(int[] nums)
        {
            if (nums.Length == 0) return 0;
            int start = 0;
            int end = nums.Length - 1;
            if (nums[start] < nums[end]) return nums[0];
            while (start < end)
            {
                int mid = (start + end) >> 1;
                if (nums[mid] > nums[end])
                {
                    start = mid + 1;
                }
                else
                {
                    end = mid;
                }
            }
            return nums[start];
        }
        #endregion

        #region 154. Find Minimum in Rotated Sorted Array II

        // Input: [3,4,5,1,2] 
        // Output: 1
        //2 3 4 5 1
        //1 2 3 4 5 
        //5,1,2,3,4
        //4 5 1 2 3 
        public int FindMinII(int[] nums)
        {
            if (nums.Length == 0) return 0;
            int start = 0;
            int end = nums.Length - 1;
            if (nums[start] < nums[end]) return nums[0];
            while (start < end)
            {
                int mid = (start + end) >> 1;
                if (nums[mid] > nums[end])
                {
                    start = mid + 1;
                }
                else
                {
                    end = mid;
                }
            }
            return nums[start];
        }
        #endregion
    }
}
