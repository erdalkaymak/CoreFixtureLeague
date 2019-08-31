using System;
using System.Collections.Generic;
using System.Text;

namespace CoreLeague
{
    public static class StringExtension
    {
        public static string Reverse (this String name,char separator)
        {
            string[] words = name.Split(separator);
            Array.Reverse(words);           
            return string.Join(separator, words);
        }

        public static bool IsUnique(this String str,char separator)
        {

            for (int i = 0; i < str.Length; i++)
                for (int j = i + 1; j < str.Length; j++)
                    if(str[i]!=separator || str[j] != separator)
                    {
                        if (str[i] == str[j])
                            return false;
                    }
                    

            return true;
        }
    }
}
