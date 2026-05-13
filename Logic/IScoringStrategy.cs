using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    /// <summary>
    /// Interfata pentru sablonul Strategy
    /// </summary>
    public interface IScoringStrategy
    {
        /// <summary>
        /// Calculeaza scorul in functie de strategie
        /// </summary>
        /// <param name="isCorrect">Verifica daca s-a raspuns corect la intrebare</param>
        /// <param name="timeElapsed">Verifica timpul in care a raspuns la intrebare</param>
        /// <returns></returns>
        int CalculateScore(bool isCorrect);
    }
}
