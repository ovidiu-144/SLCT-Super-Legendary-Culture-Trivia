// Proiect:      SLCT – Super Legendary Culture Trivia
// Fișier:       SimpleScoring.cs
// Autor:        Turnea David-Catalin
// Echipă:       Alesia, Ioana, Ovidiu, Catalin
// Descriere:    Implementarea interfetei IscoringStrategy, avand logica legata cu scorul normal


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
        /// <summary>
        /// Daca raspunzi corect primesti 1 pct, daca nu 0.
        /// </summary>
        /// <param name="isCorrect"></param>
        /// <returns></returns>
        public int CalculateScore(bool isCorrect)
        {
            //Daca e raspuns corect 1, altfel 0
            return isCorrect ? 1 : 0;
        }
    }
}
