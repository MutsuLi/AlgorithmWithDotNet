using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using System.Text;
using System.Linq;
using Algorithms;

namespace UnitTest
{
    public class Problems
    {
        public int id;
        public string name;
        public List<int> ParamsList;
        private static readonly BlockingCollection<string> _blockqueue = new BlockingCollection<string>();
        private static Dictionary<string, string> _result = new Dictionary<string, string>();
        public Problems(int id, string name, List<int> ParamsList)
        {
            this.id = id;
            this.name = name;
            this.ParamsList = ParamsList;
        }
        public static async void prepareParams(Dictionary<string, List<List<int>>> ParallelList)
        {
             Parallel.ForEach(ParallelList,  (pair) =>
               {
                    Task.Run(() =>
                   {
                       _result.Add(pair.Key, LinkListProblems.handler(pair.Key, ParallelList[pair.Key]));
                       _blockqueue.Add(pair.Key);
                   });
               });
        }

        public static void prepareResult()
        {
            while (!_blockqueue.IsCompleted)
            {
                Parallel.ForEach(_blockqueue.GetConsumingEnumerable(), async (name) =>
                {
                    await Task.Run(() =>
                    {
                        Console.WriteLine(name + ": " + _result[name] + "\r\n");
                    });
                });
            }
        }

    }

}