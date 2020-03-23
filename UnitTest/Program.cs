﻿using System;
using System.Diagnostics;
using Algorithms;
namespace UniTest
{
    class Program
    {
        static void Main(string[] args)
        {
            BacktrackProlems test = new BacktrackProlems();
            // Console.WriteLine("---1.ArrayProblems---");
            int[] newArr = { -1, 0, 1, 2, -1, -4 };
            ArrayProblems test1 = new ArrayProblems();

            var result = test1.ThreeSum(newArr);
            Console.WriteLine(ArrayProblems.toString(result));
            // int[] newArr2 = { 2, 1, 0, -1 };
            // var result2 = test.FourSum(newArr2, 2);
            // Console.WriteLine(ArrayProblems.toString(result2));
            // Console.WriteLine("---2.DynamicProgramming---");
            // int[] newArr3 = { -2, 1, -3, 4, -1, 2, 1, -5, 4 };
            DynamicProgramming test2 = new DynamicProgramming();
            // var result3 = test2.MaxSubArraySum(newArr3);
            // Console.WriteLine(result3);
            // var result4 = test2.climbStair(60);
            // Console.WriteLine(result4);
            // int[] newArr5 = { 1, 100, 1, 1, 1, 100, 1, 1, 100, 1 };
            // var result5 = test2.MinCostClimbingStairs(newArr5);
            // Console.WriteLine(result5);
            // int[][] newArr6 = new int[][] { new int[2] { 1, 3 }, new int[2] { 2, 6 }, new int[2] { 8, 10 }, new int[2] { 15, 18 } };
            // var result6 = test.mergeIntervals(newArr6);
            // Console.WriteLine(ArrayProblems.toString(result6));
            // int[] newArr7 = { -2, 1, -3, 4, -1, 2, 1, -5, 4 };
            // var result7 = test2.MaxSeqSubArray(newArr7);
            // Console.WriteLine(result7);
            // int[] newArr8 = { 1, 2, 3 };
            // Console.WriteLine(ArrayProblems.toString(test.Permute(newArr8)));
            //test.CombinationSum3(2, 18);
            //int[] newArr9 = { 1, 2, 2 };
            //test.SubsetsWithDup(newArr9);
            //test.GetPermutation(9, 273815);
            //a=a^b b=b^a^b=a a=a^b^a=b
            int[] newArr16 = { -1, 2, 1, -4 };
            var result16 = test1.ThreeSumClosest(newArr16, 1);
            Console.WriteLine(result16);
            int[] newArr31 = { 4, 3, 2, 1 };
            test1.NextPermutation(newArr31);
            int[] newArrtest = { 2, 3, 1 };
            Console.WriteLine(test1.cantorExpansion(newArrtest));
            test1.deCantorExpansion(5, 96);
            int[][] newArr64 = { new int[] { 1, 2, 5 }, new int[] { 3, 2, 1 } };
            Console.WriteLine(test2.MinPathSum(newArr64));
            int[] newArr229 = { 2, 2, 9, 3, 9, 3, 9, 3, 9, 3, 9, 3, 9, 3, 9, 3, 9 };
            Console.WriteLine(test1.MajorityElement(newArr229));
            Console.WriteLine("UniquePaths:" + test2.UniquePaths(7, 3));
            int[] newArr137 = { 2, 2, 2, 3, 1, 5, 1, 1, 5, 5 };
            Console.WriteLine(test1.SingleNumber(newArr137));
            int[] newArr209 = { 5, 1, 3, 5, 10, 7, 4, 9, 2, 8, 15 };
            Console.WriteLine(test1.MinSubArrayLen(15, newArr209));
            //[[0,1,0,0,0],[1,0,0,0,0],[0,0,0,0,0],[0,0,0,0,0]]
            int[][] newArr63 = { new int[] { 0, 1, 0, 0, 0 }, new int[] { 1, 0, 0, 0, 0 }, new int[] { 0, 0, 0, 0, 0 }, new int[] { 0, 0, 0, 0, 0 } };
            Console.WriteLine("UniquePathsWithObstacles:" + test2.UniquePathsWithObstacles(newArr63));
            int[] newArr152 = { 2, -2, 3, 4 };
            Console.WriteLine("MaxProduct:" + test2.MaxProduct(newArr152));
            int[] newArr300 = { 1, 5, 2, 6, 3, 7, 4 };
            Console.WriteLine("LengthOfLIS:" + test2.LengthOfLIS(newArr300));
            int[][] newArr120 = { new int[] { 2 }, new int[] { 3, 4 }, new int[] { 6, 5, 7 }, new int[] { 4, 1, 8, 3 } };
            Console.WriteLine("MinimumTotal:" + test2.MinimumTotal(newArr120));
            char[][] newArr221 = { new char[] { '1', '0', '1', '0', '0' }, new char[] { '1', '0', '1', '1', '1' }, new char[] { '1', '1', '1', '1', '1' }, new char[] { '1', '0', '0', '1', '0' } };
            Console.WriteLine("MaximalSquare:" + test2.MaximalSquare(newArr221));
            BinarySearch test4 = new BinarySearch();
            int[] Arr33 = { 2, 5, 6, 0, 0, 1, 2 };
            Console.WriteLine("RotatedSortArrayI:" + test4.RotatedSortArrayI(Arr33, 0));
            int[] Arr81 = { 1, 3, 1, 1, 1, 1 };
            Console.WriteLine("RotatedSortArrayII:" + test4.RotatedSortArrayII(Arr81, 3));
            int[] Arr162 = { 3, 2, 1 };
            Console.WriteLine("FindPeakElement:" + test4.FindPeakElement(Arr162));
            int[] Arr153 = { 4, 5, 1, 2, 3 };
            Console.WriteLine("FindMin:" + test4.FindMin(Arr153));
        }

        //private static void ThreadFuncOne()
        //{
        //    for (int i = 100; i < 105; i++)
        //    {
        //        Console.WriteLine(Thread.CurrentThread.Name + "：i = " + i);
        //    }
        //    Console.WriteLine(Thread.CurrentThread.Name + "‘s job has finished");
        //}

        //static void Main(string[] args)
        //{
        //    Thread.CurrentThread.Name = "MainThread";
        //    int num = 5;
        //    Thread[] threads = new Thread[num];
        //    //启动任务处理线程
        //    for (int i = 0; i < num; i++)
        //    {
        //        threads[i] = new Thread(new ThreadStart(ThreadFuncOne));
        //        threads[i].Name = "thread-" + i.ToString();
        //        threads[i].Start();
        //    }
        //    //等待所有任务处理完成
        //    for (int j = 0; j < num; j++)
        //    {
        //        threads[j].Join();
        //        Console.WriteLine(threads[j].Name + " joined");
        //    }
        //    //主线程开始处理……
        //    Console.WriteLine(Thread.CurrentThread.Name + " will process after all jobs has finished");
        //    Console.Read();
        //}

        //static void Main()
        //{
        //    string text = "t1";
        //    Console.WriteLine("start t1"+DateTime.Now.ToString());
        //    Thread t1 = new Thread(() => Console.WriteLine(text));
        //    Console.WriteLine("start t2"+DateTime.Now.ToString());
        //    text = "t2";
        //    Thread t2 = new Thread(() => Console.WriteLine(text));
        //    t1.IsBackground = true;
        //    t2.IsBackground = true;
        //    t1.PriorityClass = ProcessPriorityClass.High;
        //    t1.Start();
        //    t2.Start();

        //    Console.WriteLine("t2:Status" + t2.IsBackground.ToString());
        //}

        //static void Print(object messageObj)
        //{
        //    for (int i = 0; i < 10; i++)
        //    {
        //        int temp = i;
        //        new Thread(() => Console.WriteLine(temp)).Start();
        //    }
        //}
    }
}
