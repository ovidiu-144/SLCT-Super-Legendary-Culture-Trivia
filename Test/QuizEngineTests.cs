// Proiect:      SLCT – Super Legendary Culture Trivia
// Fișier:       QuizEngineTests.cs
// Autor:        Turnea David-Catalin
// Echipă:       Alesia, Ioana, Ovidiu, Catalin
// Descriere:    Fisierul contine clasa de testare pentru QuizEngine,
//               verificând funcționalitatea principalelor metode și
//               comportamentul acestora în diferite scenarii


using NUnit.Framework;
using Logic;
using DBManagement;
using System.IO;
using System;

namespace QuizApp.Tests
{
    /// <summary>
    /// Clasa pentru testarea QuizEngine
    /// </summary>
    [TestFixture]
    public class QuizEngineTests
    {
        private QuizEngine _engine;
        private string _tempFilePath;

        /// <summary>
        /// Initializare pentru fiecare test - creeaza un fisier temporar cu intrebari si instanta de QuizEngine
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            _tempFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Questions.json");
            File.WriteAllText(_tempFilePath, @"
            [
                { ""Text"": ""Q1"", ""Options"": [""A"",""B"",""C""], ""CorrectAnswer"": 1, ""Category"": ""Geografie"" },
                { ""Text"": ""Q2"", ""Options"": [""X"",""Y"",""Z""], ""CorrectAnswer"": 0, ""Category"": ""Geografie"" },
                { ""Text"": ""Q3"", ""Options"": [""1"",""2"",""3""], ""CorrectAnswer"": 2, ""Category"": ""Geografie"" }
            ]");

            _engine = new QuizEngine("Simple");
        }

        /// <summary>
        /// Curatarea dupa fiecare test - sterge fisierul temporar creat
        /// </summary>
        [TearDown]
        public void TearDown()
        {
            if (File.Exists(_tempFilePath))
                File.Delete(_tempFilePath);
        }

        /// <summary>
        /// Verifica daca startul unui quiz cu o categorie valida incarca intrebarile corespunzatoare si seteaza totalul de intrebari
        /// </summary>
        [Test]
        public void StartQuiz_ValidCategory_ShouldLoadQuestions()
        {
            _engine.StartQuiz("Geografie");
            Assert.That(_engine.TotalQuestions, Is.GreaterThan(0));
        }

        /// <summary>
        /// Verifica daca startul unui quiz cu o categorie invalida nu incarca nicio intrebare si seteaza totalul de intrebari la zero
        /// </summary>
        [Test]
        public void StartQuiz_InvalidCategory_ShouldHaveNoQuestions()
        {
            _engine.StartQuiz("Astronomie");
            Assert.That(_engine.TotalQuestions, Is.EqualTo(0));
        }

        /// <summary>
        /// Verifica daca trimiterea unui raspuns corect pentru intrebarea curenta returneaza true, 
        /// indicand ca raspunsul a fost evaluat ca fiind corect.
        /// </summary>
        [Test]
        public void SubmitAnswer_CorrectAnswer_ShouldReturnTrue()
        {
            _engine.StartQuiz("Geografie");
            // CorrectAnswer pentru Q1 este 1, dar GetQuestions face shuffle
            // Asa ca verificam doar ca returneaza bool corect
            bool result = _engine.SubmitAnswer(_engine.CurrentQuestion.CorrectAnswer);
            Assert.That(result, Is.True);
        }

        /// <summary>
        /// Verifica daca trimiterea unui raspuns gresit pentru intrebarea curenta returneaza false,
        /// </summary>
        [Test]
        public void SubmitAnswer_WrongAnswer_ShouldReturnFalse()
        {
            _engine.StartQuiz("Geografie");
            int wrongAnswer = (_engine.CurrentQuestion.CorrectAnswer + 1) % _engine.CurrentQuestion.Options.Length;
            bool result = _engine.SubmitAnswer(wrongAnswer);
            Assert.That(result, Is.False);
        }

        /// <summary>
        /// Verifica daca apelarea metodei NextQuestion avanseaza indexul curent, permitand trecerea la urmatoarea intrebare din quiz.
        /// </summary>
        [Test]
        public void NextQuestion_ShouldAdvanceIndex()
        {
            _engine.StartQuiz("Geografie");
            int indexInitial = _engine.CurrentIndex;
            _engine.NextQuestion();
            Assert.That(_engine.CurrentIndex, Is.EqualTo(indexInitial + 1));
        }

        /// <summary>
        /// Verifica daca metoda IsFinished returneaza true dupa ce s-au parcurs toate intrebarile din quiz, 
        /// indicand ca quizul a fost finalizat cu succes.
        /// </summary>
        [Test]
        public void IsFinished_AfterAllQuestions_ShouldReturnTrue()
        {
            _engine.StartQuiz("Geografie");
            // Avansam prin toate intrebarile
            while (!_engine.IsFinished())
                _engine.NextQuestion();
            Assert.That(_engine.IsFinished(), Is.True);
        }

        /// <summary>
        /// Verifica daca metoda IsFinished returneaza false la inceputul quizului, indicand ca quizul nu a fost finalizat 
        /// si ca exista intrebari disponibile pentru a fi parcurse.
        /// </summary>
        [Test]
        public void IsFinished_AtStart_ShouldReturnFalse()
        {
            _engine.StartQuiz("Geografie");
            Assert.That(_engine.IsFinished(), Is.False);
        }

        /// <summary>
        /// Verifica daca apelarea metodei Reset reseteaza indexul curent la zero, permitand reluarea quizului de la prima intrebare,
        /// </summary>
        [Test]
        public void Reset_ShouldSetIndexToZero()
        {
            _engine.StartQuiz("Geografie");
            _engine.NextQuestion();
            _engine.Reset();
            Assert.That(_engine.CurrentIndex, Is.EqualTo(0));
        }

        /// <summary>
        /// Verifica daca trimiterea unui raspuns corect pentru intrebarea curenta creste scorul, 
        /// asigurandu-se ca scorul este mai mare decat zero dupa evaluarea raspunsului corect.
        /// </summary>
        [Test]
        public void Score_AfterCorrectAnswer_ShouldBeGreaterThanZero()
        {
            _engine.StartQuiz("Geografie");
            _engine.SubmitAnswer(_engine.CurrentQuestion.CorrectAnswer);
            Assert.That(_engine.Score, Is.GreaterThan(0));
        }
    }
}