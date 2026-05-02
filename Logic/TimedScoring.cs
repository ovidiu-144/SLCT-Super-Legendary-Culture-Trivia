using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class TimedScoring : IScoringStrategy
    {
        public int CalculateScore(bool isCorrect, int timeElapsed)
        {

            //ceva la stilu cred
            if (!isCorrect)
                return 0;
            if (timeElapsed < 5)        return 3;
            else if (timeElapsed < 10)  return 2;
            else                        return 1;
        }
    }
}
