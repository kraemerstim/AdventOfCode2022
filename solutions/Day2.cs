using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2022.solutions
{
    public class Day2 : ProjectDay
    {
        private static int Resolve(string enemy, string own)
        {
            var points = 0;
            switch (enemy)
            {
                case "A":
                    points = own switch
                    {
                        "X" => 4,
                        "Y" => 8,
                        "Z" => 3,
                        _ => points
                    };
                    break;
                case "B":
                    points = own switch
                    {
                        "X" => 1,
                        "Y" => 5,
                        "Z" => 9,
                        _ => points
                    };
                    break;
                case "C":
                    points = own switch
                    {
                        "X" => 7,
                        "Y" => 2,
                        "Z" => 6,
                        _ => points
                    };
                    break;
            }

            return points;
        }

        private static int Resolve2(string enemy, string own)
        {
            var points = 0;
            switch (enemy)
            {
                case "A":
                    points = own switch
                    {
                        "X" => 3,
                        "Y" => 4,
                        "Z" => 8,
                        _ => points
                    };
                    break;
                case "B":
                    points = own switch
                    {
                        "X" => 1,
                        "Y" => 5,
                        "Z" => 9,
                        _ => points
                    };
                    break;
                case "C":
                    points = own switch
                    {
                        "X" => 2,
                        "Y" => 6,
                        "Z" => 7,
                        _ => points
                    };
                    break;
            }

            return points;
        }

        public override void Run()
        {
            var stopper = Stopwatch.StartNew();

            var searchTerm = new Regex(@"^(?<enemy>\w) (?<own>\w)$");
            var matches = AOCUtility.FileLines(@"resources/day2/input.txt").Select(line => searchTerm.Match(line))
                .Select(match => (match.Groups["enemy"].Value, match.Groups["own"].Value)).ToList();

            var points = matches.Select(tuple => Resolve(tuple.Item1, tuple.Item2)).Sum();
            Log($"{points}", Main.LogLevel.Result1);

            var points2 = matches.Select(tuple => Resolve2(tuple.Item1, tuple.Item2)).Sum();
            Log($"{points2}", Main.LogLevel.Result2);

            Log($"stopped at: {stopper.Elapsed}");
        }
    }
}