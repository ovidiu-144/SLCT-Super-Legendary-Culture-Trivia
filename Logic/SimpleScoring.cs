using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    /// <summary>
    /// Implementare in care nu ai de pierdut daca raspunzi gresit
    /// </summary>
    public class SimpleScoring : IScoringStrategy
    {
        public int CalculateScore(bool isCorrect, int timeElapsed)
        {
            //Daca e raspuns corect 1, altfel 0
            return isCorrect ? 1 : 0;
        }
    }
}
