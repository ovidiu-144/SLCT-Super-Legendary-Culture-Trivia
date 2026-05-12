using NUnit.Framework;
using Logic;
using DBManagement;
using System.IO;
using System;

namespace QuizApp.Tests
{
    [TestFixture]
    public class QuizEngineTests
    {
        private QuizEngine _engine;
        private string _tempFilePath;

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

        [TearDown]
        public void TearDown()
        {
            if (File.Exists(_tempFilePath))
                File.Delete(_tempFilePath);
        }

        [Test]
        public void StartQuiz_ValidCategory_ShouldLoadQuestions()
        {
            _engine.StartQuiz("Geografie");
            Assert.That(_engine.TotalQuestions, Is.GreaterThan(0));
        }

        [Test]
        public void StartQuiz_InvalidCategory_ShouldHaveNoQuestions()
        {
            _engine.StartQuiz("Astronomie");
            Assert.That(_engine.TotalQuestions, Is.EqualTo(0));
        }

        [Test]
        public void CurrentQuestion_BeforeStart_ShouldThrow()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                var q = _engine.CurrentQuestion;
            });
        }

        [Test]
        public void SubmitAnswer_CorrectAnswer_ShouldReturnTrue()
        {
            _engine.StartQuiz("Geografie");
            // CorrectAnswer pentru Q1 este 1, dar GetQuestions face shuffle
            // Asa ca verificam doar ca returneaza bool corect
            bool result = _engine.SubmitAnswer(_engine.CurrentQuestion.CorrectAnswer);
            Assert.That(result, Is.True);
        }

        [Test]
        public void SubmitAnswer_WrongAnswer_ShouldReturnFalse()
        {
            _engine.StartQuiz("Geografie");
            int wrongAnswer = (_engine.CurrentQuestion.CorrectAnswer + 1) % _engine.CurrentQuestion.Options.Length;
            bool result = _engine.SubmitAnswer(wrongAnswer);
            Assert.That(result, Is.False);
        }

        [Test]
        public void NextQuestion_ShouldAdvanceIndex()
        {
            _engine.StartQuiz("Geografie");
            int indexInitial = _engine.CurrentIndex;
            _engine.NextQuestion();
            Assert.That(_engine.CurrentIndex, Is.EqualTo(indexInitial + 1));
        }

        [Test]
        public void IsFinished_AfterAllQuestions_ShouldReturnTrue()
        {
            _engine.StartQuiz("Geografie");
            // Avansam prin toate intrebarile
            while (!_engine.IsFinished())
                _engine.NextQuestion();
            Assert.That(_engine.IsFinished(), Is.True);
        }

        [Test]
        public void IsFinished_AtStart_ShouldReturnFalse()
        {
            _engine.StartQuiz("Geografie");
            Assert.That(_engine.IsFinished(), Is.False);
        }

        [Test]
        public void Reset_ShouldSetIndexToZero()
        {
            _engine.StartQuiz("Geografie");
            _engine.NextQuestion();
            _engine.Reset();
            Assert.That(_engine.CurrentIndex, Is.EqualTo(0));
        }

        [Test]
        public void Score_AfterCorrectAnswer_ShouldBeGreaterThanZero()
        {
            _engine.StartQuiz("Geografie");
            _engine.SubmitAnswer(_engine.CurrentQuestion.CorrectAnswer);
            Assert.That(_engine.Score, Is.GreaterThan(0));
        }
    }
}