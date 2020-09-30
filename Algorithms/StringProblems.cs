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

        #region 392. Is Subsequence
        //Given a string s and a string t, check if s is subsequence of t.
        // A subsequence of a string is a new string which is formed from the original string by deleting some (can be none)
        // of the characters without disturbing the relative positions of the remaining characters. (ie, "ace" is a subsequence of "abcde" while "aec" is not).

        // Input: s = "abc", t = "ahbgdc"
        // Output: true

        // Input: s = "axc", t = "ahbgdc"
        // Output: false

        public bool IsSubsequence(string s, string t)
        {
            int i = 0;
            int j = 0;
            while (i < s.Length && j < t.Length)
            {
                if (s[i] == t[j])
                {
                    i++;
                    j++;
                }
                else
                {
                    j++;
                }
            }
            return i == s.Length;
        }
        #endregion
    }
}