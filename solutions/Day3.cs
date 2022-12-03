using System.Diagnostics;
using System.Linq;

namespace AdventOfCode2022.solutions
{
    public class Day3 : ProjectDay
    {
        public class Backpack
        {
            private readonly string _leftCompartment;
            private readonly string _rightCompartment;
            private readonly string _fullString;

            public Backpack(string fullItems)
            {
                _leftCompartment = fullItems[..(fullItems.Length / 2)];
                _rightCompartment = fullItems[(fullItems.Length / 2)..];
                _fullString = fullItems;
            }

            public char GetCharInBothCompartments()
            {
                return _leftCompartment.ToCharArray().First(c => _rightCompartment.Contains(c));
            }
            
            public char CompareToTwoBackpacks(Backpack target1, Backpack target2)
            {
                return _fullString.ToCharArray().First(c => target1._fullString.Contains(c) && target2._fullString.Contains(c));
            }

            public static int GetPointsForChar(char c)
            {
                if (c is <= 'z' and >= 'a')
                {
                    return c - 'a' + 1;
                }

                return c - 'A' + 27;
            }
            

        }

        public override void Run()
        {
            var stopper = Stopwatch.StartNew();

            var backpacks = AOCUtility.FileLines(@"resources/day3/input.txt").Select(s => new Backpack(s)).ToList();
            var backpacksum = backpacks.Sum(backpack => Backpack.GetPointsForChar(backpack.GetCharInBothCompartments()));

            Log($"{backpacksum}", Main.LogLevel.Result1);
            
            Log($"stopped at: {stopper.Elapsed}");
            stopper.Restart();

            var index = 0;
            var sum = 0;
            Backpack elfPack1 = null;
            Backpack elfPack2 = null;
            foreach (var backpack in backpacks)
            {
                switch (index)
                {
                    case 0:
                        elfPack1 = backpack;
                        break;
                    case 1:
                        elfPack2 = backpack;
                        break;
                    default:
                        sum += Backpack.GetPointsForChar(backpack.CompareToTwoBackpacks(elfPack1, elfPack2));
                        break;
                }

                index = (index+1)%3;
            }
            
            
            Log($"{sum}", Main.LogLevel.Result2);
            
            Log($"stopped at: {stopper.Elapsed}");
    }
}

}