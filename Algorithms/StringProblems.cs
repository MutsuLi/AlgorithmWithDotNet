using System;
using System.Collections.Generic;
namespace Algorithms
{
    public class StringProblems
    {
        #region 49. Group Anagrams
        //Input: ["eat", "tea", "tan", "ate", "nat", "bat"]
        // ["ate","eat","tea"],
        // ["nat","tan"],
        // ["bat"]
        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            List<IList<string>> result = new List<IList<string>>();
            Dictionary<String, List<String>> Dict = new Dictionary<string, List<String>>();
            foreach (string str in strs)
            {
                char[] temp = str.ToCharArray();
                Array.Sort(temp);
                String key = new String(temp);
                if (Dict.ContainsKey(key))
                {
                    Dict[key].Add(str);
                }
                else
                {
                    Dict.Add(key, new List<string>() { str });
                }
            }
            foreach (var each in Dict)
            {
                result.Add(each.Value);
            }
            return result;
        }
        #endregion
    }
}