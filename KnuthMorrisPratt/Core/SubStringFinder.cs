using System;
using System.Collections.Generic;
using System.Linq;

namespace Core
{
    public class SubStringFinder
    {
        protected internal int[] Failure(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return new int[0];
            }

            int size = s.Length;
            var res = new int[size];

            for (int i = 1; i < size; i++)
            {
                int j = res[i - 1];

                while (j > 0 && s[i] != s[j])
                {
                    j = res[j - 1];
                }

                if (s[i] == s[j])
                    j++;

                res[i] = j;
            }

            return res;
        }

    
        protected internal int[] IndexesOf(string input, string subString, Func<string, int[]> failureFunc)
        {
            if (subString == null)
            {
                throw new ArgumentNullException(nameof(subString));
            }

            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }
            
            var prefixes = failureFunc(subString);
            var res = new List<int>();
            
            var j = 0;
            for (var i = 0; i < input.Length; i++)
            {
                while (j > 0 && input[i] != subString[j])
                {
                    j = prefixes[j-1];
                }
                
                if (input[i] == subString[j])
                {
                    j = j + 1;
                }

                if (j == subString.Length)
                {
                    res.Add(i - subString.Length + 1);
                    j = prefixes[j-1];
                }
            }
            return res.ToArray();
        }

        protected internal int IndexOf(string input, string subString, Func<string, int[]> failureFunc)
        {
            if (subString == null)
            {
                throw new ArgumentNullException(nameof(subString));
            }

            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            var prefixes = failureFunc(subString);
            
            var j = 0;
            for (var i = 0; i < input.Length; i++)
            {
                while (j > 0 && input[i] != subString[j])
                {
                    j = prefixes[j-1];
                }
                
                if (input[i] == subString[j])
                {
                    j = j + 1;
                }

                if (j == subString.Length)
                {
                    return i - subString.Length + 1;
                }
            }
            return -1;
        }        

        public int[] IndexesOf(string input, string subString)
        {
            return IndexesOf(input, subString, Failure);
        }

        public int IndexOf(string input, string subString)
        {
            return IndexOf(input, subString, Failure);
        }
    }
}
