using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    /// <summary>
    /// Implementare care te taxeaza daca raspunzi gresit
    /// </summary>
    public class NegativeScoring : IScoringStrategy
    {
        public int CalculateScore(bool isCorrect)
        {
            return isCorrect ? 1 : -1;
        }
    }
}
