using System;

namespace Core
{
    public static class StringExtension {
        
        private static readonly Lazy<SubStringFinder> searchProvider = new Lazy<SubStringFinder>();

        public static int[] IndexesOf(this string input, string subString)
        {
            return searchProvider.Value.IndexesOf(input, subString);
        }

        public static int IndexOf(this string input, string subString)
        {
            return searchProvider.Value.IndexOf(input, subString);
        }
    }
}