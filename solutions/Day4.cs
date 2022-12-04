using System.Diagnostics;
using System.Text.RegularExpressions;

namespace AdventOfCode2022.solutions
{
    public class Day4 : ProjectDay
    {
        public class Assignment
        {
            private readonly int _start;
            private readonly int _end;

            public Assignment(int start, int end)
            {
                _start = start;
                _end = end;
            }

            public bool IsIncludedIn(Assignment target)
            {
                for (var i = _start; i <= _end; i++)
                {
                    if (i < target._start || i > target._end)
                    {
                        return false;
                    }
                }

                return true;
            }
            
            public bool OverlapsWith(Assignment target)
            {
                for (var i = _start; i <= _end; i++)
                {
                    if (i >= target._start && i <= target._end)
                    {
                        return true;
                    }
                }

                return false;
            }
        }
        
        public override void Run()
        {
            var stopper = Stopwatch.StartNew();

            var lines = AOCUtility.FileLines(@"resources/day4/input.txt");
            var assignmentRegex = new Regex(@"^(\d+)-(\d+),(\d+)-(\d+)$");

            var count = 0;
            var count2 = 0;
            foreach (var line in lines)
            {
                var match = assignmentRegex.Match(line);
                if (!match.Success) continue;
                var assignment1 = new Assignment(int.Parse(match.Groups[1].Value), int.Parse(match.Groups[2].Value));
                var assignment2 = new Assignment(int.Parse(match.Groups[3].Value), int.Parse(match.Groups[4].Value));
                if (assignment1.IsIncludedIn(assignment2) || assignment2.IsIncludedIn(assignment1)) count++;
                if (assignment1.OverlapsWith(assignment2)) count2++;
            }

            Log($"{count}", Main.LogLevel.Result1);
            
            Log($"stopped at: {stopper.Elapsed}");
            stopper.Restart();
            
            Log($"{count2}", Main.LogLevel.Result2);
            
            Log($"stopped at: {stopper.Elapsed}");
    }
}

}