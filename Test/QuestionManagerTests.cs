// Proiect:      SLCT – Super Legendary Culture Trivia
// Fișier:       QuizForm.cs
// Autor:        Turnea David-Catalin
// Echipă:       Alesia, Ioana, Ovidiu, Catalin
// Descriere:    Fisierul contine clasa de testare pentru QuestionManager,
//               care se ocupa cu incarcarea intrebarilor dintr-un fisier JSON


using System;
using System.Collections.Generic;
using System.Text;
using DBManagement;
using NUnit.Framework;

namespace Test
{
    /// <summary>
    /// Clasa de testare pentru QuestionManager
    /// </summary>
    [TestFixture]
    public class QuestionManagerTests
    {
        private QuestionManager _manager;
        private string _tempFilePath;

        /// <summary>
        /// Initializare pentru fiecare test: creează un fișier temporar cu întrebări și instanțiază QuestionManager
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            _tempFilePath = Path.GetTempFileName();
            File.WriteAllText(_tempFilePath, @"
            [
                { ""Text"": ""Q1"", ""Options"": [""A"",""B"",""C""], ""CorrectAnswer"": 1, ""Category"": ""Geografie"" },
                { ""Text"": ""Q2"", ""Options"": [""X"",""Y"",""Z""], ""CorrectAnswer"": 0, ""Category"": ""Geografie"" },
                { ""Text"": ""Q3"", ""Options"": [""1"",""2"",""3""], ""CorrectAnswer"": 2, ""Category"": ""Sport"" }
            ]");

            _manager = new QuestionManager(_tempFilePath);
        }

        /// <summary>
        /// Curatarea după fiecare test: șterge fișierul temporar creat
        /// </summary>
        [TearDown]
        public void TearDown()
        {
            if (File.Exists(_tempFilePath))
                File.Delete(_tempFilePath);
        }

        /// <summary>
        /// Incarcarea întrebărilor dintr-un fișier valid ar trebui să populeze lista de întrebări și categorii
        /// </summary>
        [Test]
        public void LoadQuestions_ValidPath_ShouldPopulateList()
        {
            var categories = _manager.GetCategories();
            Assert.That(categories, Is.Not.Empty);
        }

        /// <summary>
        /// Incarcarea întrebărilor dintr-un fișier inexistent ar trebui să arunce o excepție de tip FileNotFoundException
        /// </summary>
        [Test]
        public void LoadQuestions_InvalidPath_ShouldThrow()
        {
            Assert.Throws<FileNotFoundException>(() =>
                _manager.LoadQuestions("fisier_inexistent.json"));
        }

        /// <summary>
        /// Verificarea funcției GetQuestions pentru o categorie existentă ar trebui să returneze doar întrebările din acea categorie
        /// </summary>
        [Test]
        public void GetQuestions_ExistingCategory_ShouldReturnOnlyThatCategory()
        {
            var result = _manager.GetQuestions("Geografie");
            Assert.That(result, Is.Not.Empty);
            Assert.That(result.All(q => q.Category == "Geografie"), Is.True);
        }

        /// <summary>
        /// Verificarea funcției GetQuestions pentru o categorie inexistentă ar trebui să returneze o listă goală
        /// </summary>
        [Test]
        public void GetQuestions_UnknownCategory_ShouldReturnEmpty()
        {
            var result = _manager.GetQuestions("Astronomie");
            Assert.That(result, Is.Empty);
        }

        /// <summary>
        /// Verificarea funcției GetCategories ar trebui să returneze o listă de categorii unică, fără duplicate
        /// </summary>
        [Test]
        public void GetCategories_ShouldReturnUniqueValues()
        {
            var categories = _manager.GetCategories();
            Assert.That(categories.Count, Is.EqualTo(categories.Distinct().Count()));
        }
    }
}
