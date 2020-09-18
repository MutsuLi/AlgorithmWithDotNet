using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Concurrent;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;


namespace Algorithms
{

    public class Parallelization
    {
        private static int NUM_AES_KEYS = 180000;
        private static ConcurrentQueue<string> _keyQueue;
        private static ConcurrentQueue<byte[]> _byteArraysQueue;
        private static void ParallelGennerateMD5Keys(int maxDegree)
        {
            var parallelOptions = new ParallelOptions { MaxDegreeOfParallelism = maxDegree };
            var sw = Stopwatch.StartNew();
            _keyQueue = new ConcurrentQueue<string>();
            Parallel.ForEach(Partitioner.Create(1, NUM_AES_KEYS + 1), parallelOptions, range =>
             {
                 var md5M = MD5.Create();
                 for (int i = range.Item1; i < range.Item2; i++)
                 {
                     byte[] data = Encoding.Unicode.GetBytes(Environment.UserName + i);
                     byte[] result = md5M.ComputeHash(data);
                     _byteArraysQueue.Enqueue(result);
                 }
             });
            Console.WriteLine("MD5结束时间：" + sw.Elapsed);
        }

        private static void ConverKeysToHex(Task taskProducer)
        {
            var sw = Stopwatch.StartNew();
            while (taskProducer.Status == TaskStatus.Running || taskProducer.Status == TaskStatus.WaitingToRun || _byteArraysQueue.Count > 0)
            {
                byte[] result;
                if (_byteArraysQueue.TryDequeue(out result))
                {
                    string hexString = convert2hexStr(result);
                    _keyQueue.Enqueue(hexString);
                }
            }
            Console.WriteLine("key结束时间：" + sw.Elapsed);
        }
        public static string convert2hexStr(byte[] buffer)
        {
            StringBuilder sb = new StringBuilder();
            for (int index = 0; index < buffer.Length; index++)
            {
                sb.Append(((int)buffer[index]).ToString("X2"));
            }
            return sb.ToString();
        }
        public static void Main(string[] args)
        {
            Console.WriteLine("任务开始...");
            var sw = Stopwatch.StartNew();
            _byteArraysQueue = new ConcurrentQueue<byte[]>();
            _keyQueue = new ConcurrentQueue<string>();

            //生产key 和 消费key的两个任务
            var taskKeys = Task.Factory.StartNew(() => ParallelGennerateMD5Keys(Environment.ProcessorCount - 1));
            var taskHexString = Task.Factory.StartNew(() => ConverKeysToHex(taskKeys));

            string lastKey;
            //隔半秒去看一次。
            while (taskHexString.Status == TaskStatus.Running || taskHexString.Status == TaskStatus.WaitingToRun)
            {
                Console.WriteLine("_keyqueue的个数是{0},_byteArraysQueue的个数是{1}", _keyQueue.Count, _byteArraysQueue.Count);
                if (_keyQueue.TryPeek(out lastKey))
                {
                    //  Console.WriteLine("第一个Key是{0}",lastKey);
                }
                Thread.Sleep(500);
            }
            //等待两个任务结束
            Task.WaitAll(taskKeys, taskHexString);

            Console.WriteLine("结束时间：" + sw.Elapsed);
            Console.WriteLine("key的总数是{0}", _keyQueue.Count);
        }

    }
}