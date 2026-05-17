// Proiect:      SLCT – Super Legendary Culture Trivia
// Fișier:       StreakScoring.cs
// Autor:        Turnea David-Catalin
// Echipă:       Alesia, Ioana, Ovidiu, Catalin
// Descriere:    Implementarea interfetei IscoringStrategy, avand logica legata cu raspunsuri consecutive



using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    /// <summary>
    /// Implementare in care conteaza rapiditatea raspunsului
    /// </summary>
    public class StreakScoring : IScoringStrategy
    {
        private int _currentStreak = 0;
        /// <summary>
        /// Daca raspunzi la mai multe corec una dupa alta, scorul creste gradual 1, 2, 3. Se opreste la 3
        /// </summary>
        /// <param name="isCorrect">Indexul ales</param>
        /// <returns></returns>
        public int CalculateScore(bool isCorrect)
        {

            //ceva la stilu cred
            if (!isCorrect)
            {
                _currentStreak = 0;
                return 0;
            }
            if (_currentStreak < 3)
                _currentStreak++;
            return _currentStreak;
        }
    }
}
