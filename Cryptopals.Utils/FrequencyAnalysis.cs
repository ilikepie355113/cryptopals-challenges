using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Cryptopals.Utils
{
    public class FrequencyAnalysis : IComparable<FrequencyAnalysis>
    {
        private static readonly Dictionary<char, double> frequencies = InitFrequencies();
        public string Text { get; }
        public double Score { get; }

        public FrequencyAnalysis(string text)
        {
            Text = text;
            Score = CalculateScore();
        }

        private double CalculateScore()
        {
            string text = Text.ToLower();
            double length = text.Length; // need double for division below
            double score = 0;

            foreach (char c in frequencies.Keys)
            {
                score += Math.Abs(frequencies[c] - (text.Where(x => x == c).Count() / length)); // diff between actual and expected freq
            }

            score += .1 * Regex.Matches(text, @"[^a-z ]").Count; // Weight all non alpha characters

            return score;
        }

        private static Dictionary<char, double> InitFrequencies()
        {
            return new Dictionary<char, double>
            {
                {'a', .0655},
                {'b', .0127},
                {'c', .0227},
                {'d', .0335},
                {'e', .1021},
                {'f', .0197},
                {'g', .0164},
                {'h', .0486},
                {'i', .0573},
                {'j', .0011},
                {'k', .0057},
                {'l', .0336},
                {'m', .0202},
                {'n', .0570},
                {'o', .0620},
                {'p', .0150},
                {'q', .0009},
                {'r', .0497},
                {'s', .0533},
                {'t', .0751},
                {'u', .0230},
                {'v', .0079},
                {'w', .0169},
                {'x', .0015},
                {'y', .0147},
                {'z', .0007},
                {' ', .1832}
            }; // sums to 1.0
        }


        public int CompareTo(FrequencyAnalysis that)
        {
            if (Score < that.Score) return -1;
            else if (Score > that.Score) return 1;
            else return Text.CompareTo(that.Text); // Needed so can use equal Scores as keys in SortedDictionary
        }

        override
        public string ToString()
        {
            return $"{Text} --- {Math.Truncate(Score * 1000) / 1000}";
        }
    }
}
