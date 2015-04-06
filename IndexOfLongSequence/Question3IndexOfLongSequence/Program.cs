using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question3IndexOfLongSequence
{
    #region Question 3

    public static partial class MyStringExtension
    {
        public static String IndexOfLongestRun(this String str)
        {
            Dictionary<char, int> charIndex = new Dictionary<char, int>();
            Dictionary<char, int> longestRun = new Dictionary<char, int>();

            char oldChar = str[0];
            int newCount = 0;
            int totalCount = 0;
            int newIndex = 0;
            int highestCount = 0;
            String chars = "";

            charIndex[oldChar] = 0;

            //needed for the below logic to work ( for last letter iteration )
            str = str + "$";

            foreach (char c in str)
            {

                //if subsequent characters are different
                if (oldChar != c)
                {
                    //initialise index with zero or with existing index
                    charIndex[c] = charIndex.ContainsKey(c) ? charIndex[c] : 0;

                    if (longestRun.ContainsKey(oldChar))
                    {
                        //compare old and new sequence length
                        if (longestRun[oldChar] < newCount)
                        {
                            longestRun[oldChar] = newCount;
                            charIndex[oldChar] = newIndex;
                        }
                    }
                    else
                    {
                        longestRun[oldChar] = newCount;
                        charIndex[oldChar] = newIndex;
                    }

                    if (highestCount <= newCount)
                    {
                        highestCount = newCount;
                        if (chars.IndexOf(oldChar) < 0)
                            chars += oldChar;
                    }

                    oldChar = c;
                    newCount = 0;
                    newIndex = totalCount;
                }
                newCount++;
                totalCount++;
            }

            foreach (char item in chars.ToCharArray())
            {
                if (longestRun[item] != highestCount)
                    chars = chars.Replace("" + item, "");
            }

            String result = "";
            foreach (char item in chars.ToCharArray())
            {
                result += "Letter : " + item + " , Count : " + longestRun[item] + " , Index : " + charIndex[item] + "\n\n";
            }

            return result;
        }
    }

    public class Run
    {
        public static void IndexOfLongestRun(string str)
        {
            Console.WriteLine("\nThe input is : " + str + "\n");
            Console.WriteLine(str.IndexOfLongestRun());
        }
        public static void Main(string[] args)
        {
            while (true)
            {
                //IndexOfLongestRun("abcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzccc");
                Console.Write("Enter the Input String : ");
                IndexOfLongestRun(Console.ReadLine());
                //IndexOfLongestRun("aaabbbbceeecccddddbbbbdddd");
                //IndexOfLongestRun("abbcccddddaaaaaacccbba");
            }
        }


    }
    #endregion
}
