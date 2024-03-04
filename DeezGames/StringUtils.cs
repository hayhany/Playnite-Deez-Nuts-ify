using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DeezGames
{
    public static class StringUtils
    {
        public static string GetDeezNutsified(string inputString)
        {
            string[] split = inputString.Split(' ');

            for (int i = 0; i < split.Length; i++)
            {
                string lowered = split[i].ToLower();

                if (lowered.Equals("of"))
                    return GetUntilEndAndAddDeez(split, i + 1, false);

                else if (lowered.Equals("the") && GetFollowsSecondRule(split, i))
                    return GetUntilEndAndAddDeez(split, i + 1, true);

                else if (lowered.Equals("a"))
                    return GetUntilEndAndAddDeez(split, i, true);

                else if (lowered.Contains("'"))
                    return inputString.Replace(split[i], "Deez Nuts'");

                else if (lowered.Equals("edition"))
                    return inputString.Replace(split[i - 1], "Deez Nuts");
            }

            return inputString + " of Deez Nuts";
        }

        private static bool GetFollowsSecondRule(string[] inputSplit, int wordIndex)
        {
            if (wordIndex == 0)
                return true;

            return inputSplit[wordIndex - 1].ToLower().Equals("of");
        }

        private static string GetUntilEndAndAddDeez(string[] inputSplit, int endIndex, bool addLastWord)
        {
            string output = string.Join(" ", inputSplit, 0, endIndex);

            output += " Deez Nuts ";

            if (addLastWord)
            {
                string last = inputSplit[inputSplit.Length - 1];
                output += last;
            }

            return output;
        }
    }
}
