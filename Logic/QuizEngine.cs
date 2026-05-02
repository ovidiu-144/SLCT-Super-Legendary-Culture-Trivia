using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class QuizEngine
    {
        //Deocamdata nu avem Questions
        //private List<Question> _questions;

        //lasam string pe moment
        private List<String> _questions;
        private int _currentIndex;
        private ScoreManager _scoreManager;

        //nu este logica pt QuestionManager
        //private QuestionManger _questionManager;

        void StartQuiz(string category)
        {
            throw new NotImplementedException();
        }

        //Question = string
        String GetCurrentQuestion => _questions[_currentIndex];
        
        bool SubmitAnswer (int optionIndex)
        {
            throw new NotImplementedException();
        }

        bool IsFinished()
        {
            throw new NotImplementedException();
        }

        int GetScore()
        {
            throw new NotImplementedException();
        }

        void NextQuestion()
        {
            throw new NotImplementedException();
        }
    }
}
