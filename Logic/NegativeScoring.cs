// Proiect:      SLCT – Super Legendary Culture Trivia
// Fișier:       NegativeScoring.cs
// Autor:        Turnea David-Catalin
// Echipă:       Alesia, Ioana, Ovidiu, Catalin
// Descriere:    Implementarea interfetei IscoringStrategy, avand logica legata cu scorul negativ

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
        /// <summary>
        /// Daca raspunzi corect ai +1 punct, daca pui gresit ai -1 punct
        /// </summary>
        /// <param name="isCorrect">Indexul ales</param>
        /// <returns></returns>
        public int CalculateScore(bool isCorrect)
        {
            return isCorrect ? 1 : -1;
        }
    }
}
