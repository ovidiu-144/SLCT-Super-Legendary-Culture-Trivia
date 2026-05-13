using System;
using System.Collections.Generic;
using System.Text;
using DBManagement;

namespace Logic
{
    /// <summary>
    /// Clasa ce se ocupa de logica din spatele intrebarilor (avansare, verificare raspunsuri)
    /// </summary>
    public class QuizEngine
    {
        private List<Question> _questions;
        private int _currentIndex;
        private ScoreManager _scoreManager;
        private QuestionManager _questionManager;

        /// <summary>
        /// Constructor care creeaza ScoreManager, QuestionManager
        /// </summary>
        /// <param name="strategy">Atribut pentru sablonul Strategy</param>
        public QuizEngine(String strategy)
        {
            //creem alt QuizEngine doar daca schimbam strategia

            //O sa trimitem un string pentru strategie
            _scoreManager = new ScoreManager(strategy);

            _questionManager = new QuestionManager();

            _questions = new List<Question>();
            _currentIndex = 0;
        }

        //Ar trebui sa pun introduc toate intrebarile din categoria respectiva in memorie
        //Vedem daca ar trebui aici sa incarcam intrebarile in memorie din fisierele externe,
        //sau o facem in Meniu

        /// <summary>
        /// Actualizeaza intrebarile cu ce are in memorie
        /// </summary>
        /// <param name="category">Numele categoriei din care luam intrebarile</param>
        public void StartQuiz(string category)
        {
            _questions = _questionManager.GetQuestions(category);
            //eventual poate marcarea unui flag sau ceva
        }

        /// <summary>
        /// Returneaza intrebarea curenta
        /// </summary>
        public Question CurrentQuestion
        {
            get
            {
                //Ca sa nu avem probleme daca este apelata cand nu trebuie
                if (_questions.Count == 0)
                    throw new InvalidOperationException("Nu exista intrebari incarcate");
                return _questions[_currentIndex];
            }
        }
        /// <summary>
        /// Getter pentru numarul total de intrebari
        /// </summary>
        public int TotalQuestions => _questions.Count;
        /// <summary>
        /// Getter pentru indexul intrebarii curente
        /// </summary>
        public int CurrentIndex => _currentIndex;



        /// <summary>
        /// Calculam scorul dupa raspunsul dat
        /// </summary>
        /// <param name="optionIndex">Varianta aleasa de utilizator</param>
        /// <returns></returns>
        public bool SubmitAnswer (int optionIndex)
        {
            /*Cred ca pentru suffle, ar trebui sa luam cumva
            De ex, intrebarea sa fie de forma
              Intrebare ? 1.RaspunsA  2.RaspunsB  3.RaspunsC  4.RaspunsD
             pe interfata afisam doar RaspunsA B C D
             iar la raspuns corect am avea 1, 2, 3, 4
             astfel daca am amesteca raspunsurile, varianta corecta ar ramane
            doar  in functie de primul index

            Si am putea avea ceva de genu
            
            int answer = Int32.Parse (CurrentQuestion[optionIndex][0]); // -> Acum answer are acea valoare
            bool isCorrect = (CurrentQuestion.CorrectAnswer == answer);
            */
            
            //Verificam daca este corect raspunsul
            bool isCorrect = (CurrentQuestion.CorrectAnswer == optionIndex);

            //Actualizam scorul in functie de raspuns

            //ar trebui si timeElapsed dar, deocamdata lasam doar atat
            //Este oricum by default 0
            _scoreManager.UpdateScore(isCorrect);

            //Trimitem inapoi ca sa stie interfata ce sa faca (Poate scrie in anumit fel cand e corect)
            return isCorrect;
        }
        /// <summary>
        /// Returneaza daca s-au terminat intrebarile sau nu
        /// </summary>
        /// <returns></returns>
        public bool IsFinished()
        {
            return _currentIndex == _questions.Count;
        }
        /// <summary>
        /// Getter pentru scor
        /// </summary>
        public int Score => _scoreManager.TotalScore;

        /// <summary>
        /// Metoda care amesteca optiunile intrebarilor aleatoriu
        /// </summary>
        public void ShuffleOptions()
        {
            Random rnd = new Random();
            string[] options = CurrentQuestion.Options;
            
            //Luam raspunsul corect
            string correctAnswer = options[CurrentQuestion.CorrectAnswer];
            
            //Amestecam raspunsurile
            rnd.Shuffle(options);

            //Luam indexul corect
            int newIndex = Array.IndexOf(options, correctAnswer);

            //Setam in intrebare, ca sa putem trimite spre interfata
            CurrentQuestion.Options = options;
            CurrentQuestion.CorrectAnswer = newIndex;
        }

        /// <summary>
        /// Merge la urmatoarea intrebare
        /// </summary>
        public void NextQuestion()
        {
            _currentIndex++;
            if (_currentIndex != TotalQuestions)
                ShuffleOptions();
        }

        /// <summary>
        /// Reseteaza scorul si intrebarile
        /// </summary>
        public void Reset()
        {
            _scoreManager.Reset();
            _currentIndex = 0;

            //Deodata cu asta ar trebui facut si un shuffle pentru intrebari eventual
            //Sau cu alte categorii?
        }
    }
}
