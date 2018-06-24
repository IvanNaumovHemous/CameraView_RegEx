using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace CameraView
{
    class CameraView
    {
        static void Main(string[] args)
        {
            var RegexMatches = GetRegexMatches();
            PrintRegexMatches(RegexMatches);

        }

        private static void PrintRegexMatches(MatchCollection regexMatches)
        {
            var printMatches = regexMatches.Cast<Match>().Select(x => x.Value.Trim()).ToArray();
            Console.WriteLine(string.Join(", ", printMatches));
        }

        private static MatchCollection GetRegexMatches()
        {
            var input = Console.ReadLine().Split(' ').ToArray();
            int skip = int.Parse(input[0]);
            int take = int.Parse(input[1]);
            var text = Console.ReadLine();
            var pattern = $@"(?<=\|<.{{{skip}}})[^|]{{0,{take}}}";
            var matches = Regex.Matches(text, pattern);
            return matches;
        }
    }
}
