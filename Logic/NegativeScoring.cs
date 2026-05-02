using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class NegativeScoring : IScoringStrategy
    {
        public int CalculateScore(bool isCorrect, int timeElapsed)
        {
            return isCorrect ? 1 : -1;
        }
    }
}
