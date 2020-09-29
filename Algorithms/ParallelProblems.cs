using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Concurrent;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading.Tasks.Dataflow;

namespace Algorithms
{

    public class ParallelProblems
    {
        public static class ConcurrentQueue
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

                var taskKeyMax = Environment.ProcessorCount / 2;

                //生产key 和 消费key的两个任务
                var taskKeys = Task.Factory.StartNew(() => ParallelGennerateMD5Keys(taskKeyMax));

                var taskHexMax = Environment.ProcessorCount - taskKeyMax;
                var taskHexStrings = new Task[taskHexMax];
                for (int i = 0; i < taskHexMax; i++)
                {
                    taskHexStrings[i] = Task.Factory.StartNew(() => ConverKeysToHex(taskKeys));
                }

                //等待两个任务结束
                Task.WaitAll(taskHexStrings);

                Console.WriteLine("结束时间：" + sw.Elapsed);
                Console.WriteLine("key的总数是{0}", _keyQueue.Count);
            }

        }
        public static class ConcurrentBag
        {
            private static int NUM_AES_KEYS = 1800000;
            private static ConcurrentBag<string> _sentencesBag;
            private static ConcurrentBag<string> _capWrodsInSentenceBag;
            private static ConcurrentBag<string> _finalSentencesBag;

            private static volatile bool _producingSentences = false;
            private static volatile bool _capitalWords = false;

            private static void ProduceSentences()
            {
                string[] rawSentences =
                {
                "并发集合你可知",
                "ConcurrentBag 你值得拥有",
                "stoneniqiu",
                "博客园",
                ".Net并发编程学习",
                "Reading for you",
                "ConcurrentBag 是个无序集合"
            };
                try
                {
                    Console.WriteLine("ProduceSentences...");
                    _sentencesBag = new ConcurrentBag<string>();
                    var random = new Random();
                    for (int i = 0; i < NUM_AES_KEYS; i++)
                    {
                        var sb = new StringBuilder();
                        sb.Append(rawSentences[random.Next(rawSentences.Length)]);
                        sb.Append(' ');
                        _sentencesBag.Add(sb.ToString());
                    }

                }
                finally
                {
                    _producingSentences = false;
                }
            }

            private static void CapitalizeWordsInSentence()
            {
                SpinWait.SpinUntil(() => _producingSentences);

                try
                {
                    Console.WriteLine("CapitalizeWordsInSentence...");
                    _capitalWords = true;
                    while ((!_sentencesBag.IsEmpty) || _producingSentences)
                    {
                        string sentence;
                        if (_sentencesBag.TryTake(out sentence))
                        {
                            _capWrodsInSentenceBag.Add(sentence.ToUpper() + "stoneniqiu");
                        }
                    }
                }
                finally
                {
                    _capitalWords = false;
                }
            }

            private static void RemoveLettersInSentence()
            {
                SpinWait.SpinUntil(() => _capitalWords);
                Console.WriteLine("RemoveLettersInSentence...");
                while (!_capWrodsInSentenceBag.IsEmpty || _capitalWords)
                {
                    string sentence;
                    if (_capWrodsInSentenceBag.TryTake(out sentence))
                    {
                        _finalSentencesBag.Add(sentence.Replace("stonenqiu", ""));
                    }
                }
            }

            public static void Main(string[] args)
            {
                Console.WriteLine("ConcurrentBag start...");
                var sw = Stopwatch.StartNew();

                _sentencesBag = new ConcurrentBag<string>();
                _capWrodsInSentenceBag = new ConcurrentBag<string>();
                _finalSentencesBag = new ConcurrentBag<string>();

                _producingSentences = true;

                Parallel.Invoke(ProduceSentences, CapitalizeWordsInSentence, RemoveLettersInSentence);

                Console.WriteLine("_sentencesBag的总数是{0}", _sentencesBag.Count);
                Console.WriteLine("_capWrodsInSentenceBag的总数是{0}", _capWrodsInSentenceBag.Count);
                Console.WriteLine("_finalSentencesBag的总数是{0}", _finalSentencesBag.Count);
                Console.WriteLine("总时间：{0}", sw.Elapsed);
            }
        }

        public static class BlockingCollection
        {
            private static int NUM_SENTENCE = 1800000;
            private static BlockingCollection<string> _sentencesBC;
            private static BlockingCollection<string> _capWrodsInSentenceBC;
            private static BlockingCollection<string> _finalSentencesBC;

            private static void ProduceSentences()
            {
                string[] rawSentences =
                {
                "并发集合你可知",
                "ConcurrentBag 你值得拥有",
                "stoneniqiu",
                "博客园",
                ".Net并发编程学习",
                "Reading for you",
                "ConcurrentBag 是个无序集合"
            };

                Console.WriteLine("ProduceSentences...");
                _sentencesBC = new BlockingCollection<string>();
                var random = new Random();
                for (int i = 0; i < NUM_SENTENCE; i++)
                {
                    var sb = new StringBuilder();
                    sb.Append(rawSentences[random.Next(rawSentences.Length)]);
                    sb.Append(' ');
                    _sentencesBC.Add(sb.ToString());
                }
                //让消费者知道，生产过程已经完成
                _sentencesBC.CompleteAdding();

            }

            private static void CapitalizeWordsInSentence()
            {
                Console.WriteLine("CapitalizeWordsInSentence...");
                //生产者是否完成
                while (!_sentencesBC.IsCompleted)
                {
                    string sentence;
                    if (_sentencesBC.TryTake(out sentence))
                    {
                        _capWrodsInSentenceBC.Add(sentence.ToUpper() + "stoneniqiu");
                    }
                }
                //让消费者知道，生产过程已经完成
                _capWrodsInSentenceBC.CompleteAdding();
            }

            private static void RemoveLettersInSentence()
            {
                //SpinWait.SpinUntil(() => _capitalWords);
                Console.WriteLine("RemoveLettersInSentence...");
                while (!_capWrodsInSentenceBC.IsCompleted)
                {
                    string sentence;
                    if (_capWrodsInSentenceBC.TryTake(out sentence))
                    {
                        _finalSentencesBC.Add(sentence.Replace("stonenqiu", ""));
                    }
                }
            }

            public static void Main(string[] args)
            {
                Console.WriteLine("BlockingCollection start...");
                var sw = Stopwatch.StartNew();

                _sentencesBC = new BlockingCollection<string>(NUM_SENTENCE);
                _capWrodsInSentenceBC = new BlockingCollection<string>(NUM_SENTENCE);
                _finalSentencesBC = new BlockingCollection<string>(NUM_SENTENCE);

                Parallel.Invoke(ProduceSentences, CapitalizeWordsInSentence, RemoveLettersInSentence);

                Console.WriteLine("_sentencesBag的总数是{0}", _sentencesBC.Count);
                Console.WriteLine("_capWrodsInSentenceBag的总数是{0}", _capWrodsInSentenceBC.Count);
                Console.WriteLine("_finalSentencesBag的总数是{0}", _finalSentencesBC.Count);
                Console.WriteLine("总时间：{0}", sw.Elapsed);
            }
        }
        public static class TplProblems
        {
            public async static Task Main()
            {
                var multiplyBlock = new TransformBlock<int, int>(item => item * 2);
                var subtractBlock = new TransformBlock<int, int>(item => item - 2);
                var options = new DataflowLinkOptions { PropagateCompletion = true };
                multiplyBlock.LinkTo(subtractBlock, options);
                // 第一个块的完成情况自动传递给第二个块。    
                multiplyBlock.Complete();
                await subtractBlock.Completion;
            }
        }
    }
}