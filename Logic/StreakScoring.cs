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
