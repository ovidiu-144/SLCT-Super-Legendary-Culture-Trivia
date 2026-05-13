using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    /// <summary>
    /// Clasa care se ocupa cu Scorul utilizatorului
    /// </summary>
    public class ScoreManager
    {
        private int _totalScore;
        private IScoringStrategy _strategy;

        /// <summary>
        /// Constructor care verifica ce fel de strategie este
        /// </summary>
        /// <param name="strategy">Strategia aleasa de utilizator</param>
        /// <exception cref="Exception"></exception>
        public ScoreManager(string strategy)
        {
            switch (strategy) {
                case "Simple":
                    _strategy = new SimpleScoring();
                    break;
                case "Negative":
                    _strategy = new NegativeScoring();
                    break;
                case "Streak":
                    _strategy = new StreakScoring();
                    break;
                default:
                    throw new InvalidStrategyException(strategy);
            }
        }
        /// <summary>
        /// Actualizeaza scorul in functie de strategie
        /// </summary>
        /// <param name="isCorrect">Verifica daca s-a raspuns corect la intrebare</param>
        /// <param name="timeElapsed">Verifica timpul in care a raspuns la intrebare</param>
        public void UpdateScore(bool isCorrect)
        {
            _totalScore += _strategy.CalculateScore(isCorrect);
        }

        /// <summary>
        /// Getter pentru Scor
        /// </summary>
        public int TotalScore => _totalScore;

        /// <summary>
        /// Reseteaza Scorul
        /// </summary>
        public void Reset()
        {
            _totalScore = 0; // modificam in functie de strategie
        }

    }
}
