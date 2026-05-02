using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public interface IScoringStrategy
    {
        int CalculateScore(bool isCorrect, int timeElapsed);
    }
}
