using System;
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
            // int[] newArr = { -2, 0, 1, 1, 2 };
            ArrayProblems test1 = new ArrayProblems();
            // var result = test.ThreeSum2(newArr);
            // Console.WriteLine(ArrayProblems.toString(result));
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
            int[] newArr9 = { 10, 1, 2, 7, 6, 1, 5 };
            test.CombinationSum2(newArr9, 8);
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
