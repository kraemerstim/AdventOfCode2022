using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace AdventOfCode2022.solutions
{
    public class Day1 : ProjectDay
    {
        
        
        public override void Run()
        {
            var stopper = Stopwatch.StartNew();
            
            var sums = new List<int>();
            var curSum = 0;
            AOCUtility.FileLines(@"resources/day1/input.txt").ForEach(s =>
            {
                if (s == "")
                {
                    sums.Add(curSum);
                    curSum = 0;
                }
                else
                {
                    curSum += Int32.Parse(s);
                }
            });
            sums.Add(curSum);

            Log($"{sums.Max()}", Main.LogLevel.Result1);
            
            var orderedList = sums.OrderBy(i => i).Reverse().ToList();
            
            Log($"stopped at: {stopper.Elapsed}");
            stopper.Restart();
            
            Log($"{orderedList[0] + orderedList[1] + orderedList[2]}", Main.LogLevel.Result2);
            
            Log($"stopped at: {stopper.Elapsed}");
    }
}

}