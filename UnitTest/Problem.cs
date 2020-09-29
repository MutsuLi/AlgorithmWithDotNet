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
        private static ConcurrentDictionary<string, string> _result = new ConcurrentDictionary<string, string>();
        public Problems(int id, string name, List<int> ParamsList)
        {
            this.id = id;
            this.name = name;
            this.ParamsList = ParamsList;
        }
        public static void prepareParams(Dictionary<string, List<List<int>>> ParallelList, Func<string, IList<List<int>>, string> function)
        {
            List<Task> tasklist = new List<Task>();;
            Parallel.ForEach(ParallelList, (pair) =>
             {
                 lock (_result)
                 {
                     _result.TryAdd(pair.Key, function(pair.Key, ParallelList[pair.Key]));
                 }
                 _blockqueue.Add(pair.Key);
             });
            _blockqueue.CompleteAdding();
        }

        public static void prepareResult()
        {
            foreach (var name in _blockqueue.GetConsumingEnumerable())
            {
                Console.WriteLine(name + ": " + _result[name] + "\r\n");
            }
        }

        
    }

}