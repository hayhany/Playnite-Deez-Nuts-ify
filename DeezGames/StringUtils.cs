using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DeezGames
{
    /* RULES:
     * 
     * 1. if has "of" add deez nuts after (removes all text after) ✅
     * 2. if has (the) but without (of) before it, remove all after, add deez nuts and add last word ✅
     * 3. if has (') add deez nuts before it
     * 4. if has (a) remove "a", add deez nuts and remove everything after
     * 5. if has (Edition) replace word before
     * 6. if not meeting any, add "of Deez Nuts" after
     */

    public static class StringUtils
    {
        public static string DeezNutsify(string inputString)
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

            return inputString += " of Deez Nuts";
        }

        public static bool GetFollowsSecondRule(string[] inputSplit, int wordIndex)
        {
            if (wordIndex == 0)
                return true;

            return inputSplit[wordIndex - 1].ToLower().Equals("of");
        }

        public static string GetUntilEndAndAddDeez(string[] inputSplit, int endIndex, bool addLastWord)
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
