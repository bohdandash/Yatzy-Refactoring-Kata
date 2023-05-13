using System.Linq;
using System;

namespace Yatzy
{
    public class Yatzy
    {
        private const int NumDice = 5;
        private const int NumSides = 6;
        private readonly int[] dice;

        public Yatzy(params int[] dice)
        {
            if (dice.Length != NumDice)
            {
                throw new ArgumentException("You must provide exactly five dice values.");
            }

            this.dice = dice;
        }

        public  int Chance(params int[] dice)
        {
            return dice.Sum();
        }

        public int yatzy(params int[] dice)
        {
            var counts = new int[NumSides];
            foreach (var die in dice)
            {
                counts[die - 1]++;
            }
            return counts.Any(count => count == NumDice) ? 50 : 0;
        }

        public int Ones(params int[] dice)
        {
            return dice.Count(die => die == 1);
        }

        public int Twos(params int[] dice)
        {
            return dice.Count(die => die == 2) * 2;
        }

        public int Threes(params int[] dice)
        {
            return dice.Count(die => die == 3) * 3;
        }

        public int Fours()
        {
            return dice.Count(die => die == 4) * 4;
        }

        public int Fives()
        {
            return dice.Count(die => die == 5) * 5;
        }

        public int Sixes()
        {
            return dice.Count(die => die == 6) * 6;
        }

        public int ScorePair(params int[] dice)
        {
            var counts = new int[NumSides];
            foreach (var die in dice)
            {
                counts[die - 1]++;
            }
            for (var i = NumDice; i >= 0; i--)
            {
                if (counts[i] >= 2)
                {
                    return (i + 1) * 2;
                }
            }
            return 0;
        }

        public int TwoPair(params int[] dice)
        {
            var counts = new int[NumSides];
            foreach (var die in dice)
            {
                counts[die - 1]++;
            }
            var n = 0;
            var score = 0;
            for (var i = NumDice; i >= 0; i--)
            {
                if (counts[i] >= 2)
                {
                    n++;
                    score += (i + 1) * 2;
                }
            }
            return n == 2 ? score : 0;
        }

        public int ThreeOfAKind(params int[] dice)
        {
            return GetKindScore(dice, 3);
        }

        public int FourOfAKind(params int[] dice)
        {
            return GetKindScore(dice, 4);
        }

        private int GetKindScore(int[] dice, int kind)
        {
            var counts = new int[NumSides];
            foreach (var die in dice)
            {
                counts[die - 1]++;
            }
            for (var i = 0; i < 6; i++)
            {
                if (counts[i] >= kind)
                {
                    return (i + 1) * kind;
                }
            }
            return 0;
        }

       
    }

    public class Program
    {
        public static void Main()
        {
            var yatzy = new Yatzy(1, 3, 5, 2, 1);

            // simulate a game of Yatzy
            Console.WriteLine("Score for chance: " + yatzy.Chance());
            Console.WriteLine("Score for ones: " + yatzy.Ones(1, 2, 3, 4, 5));
            Console.WriteLine("Score for twos: " + yatzy.Twos(1, 2, 3, 2, 6));
            Console.WriteLine("Score for threes: " + yatzy.Threes(1, 2, 3, 2, 3));
            Console.WriteLine("Score for fours: " + yatzy.Fours());
            Console.WriteLine("Score for fives: " + yatzy.Fives());
            Console.WriteLine("Score for sixes: " + yatzy.Sixes());
            Console.WriteLine("Score for one pair: " + yatzy.ScorePair(3, 4, 3, 5, 6));
            Console.WriteLine("Score for two pairs: " + yatzy.TwoPair(3, 3, 5, 4, 5));
            Console.WriteLine("Score for three of a kind: " + yatzy.ThreeOfAKind(3, 3, 3, 4, 5));
            Console.WriteLine("Score for four of a kind: " + yatzy.FourOfAKind(3, 3, 3, 3, 5));
            Console.WriteLine("Score for yatzy: " + yatzy.yatzy(4, 4, 4, 4, 4));

            Console.ReadLine();
        }
    }
}
