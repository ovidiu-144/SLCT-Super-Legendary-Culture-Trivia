using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    /// <summary>
    /// Clasa de baza pentru exceptiile personalizate
    /// </summary>
    public class QuizException : Exception
    {
        public QuizException(string message) : base(message) { }
        public QuizException(string message, Exception inner) : base(message, inner) { }
    }
    /// <summary>
    /// Exceptie daca gaseste alta strategie
    /// </summary>
    public class InvalidStrategyException : QuizException
    {
        public string Strategy { get; }

        public InvalidStrategyException(string strategy)
            : base($"Strategia '{strategy}' nu este recunoscuta. Foloseste: Simple, Negative, Timed.")
        {
            Strategy = strategy;
        }
    }
    /// <summary>
    /// Daca nu avem incarcate intrebarile
    /// </summary>
    public class NoQuestionsLoadedException : QuizException
    {
        public NoQuestionsLoadedException()
            : base("Nu exista intrebari incarcate. Apeleaza StartQuiz() inainte.") { }
    }
}
