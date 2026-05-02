using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class ScoreManager
    {
        private int _totalScore;
        private IScoringStrategy _strategy;

        ScoreManager(IScoringStrategy strategy)
        {
            _strategy = strategy;
        }
        void UpdateScore(bool isCorrect, int timeElapsed)
        {
            throw new NotImplementedException();
        }

        public int TotalScore => _totalScore;

        void Reset()
        {
            throw new NotImplementedException();
        }

    }
}
