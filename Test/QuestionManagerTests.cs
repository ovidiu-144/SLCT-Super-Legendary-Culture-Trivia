using System;
using System.Collections.Generic;
using System.Text;
using DBManagement;
using NUnit.Framework;

namespace Test
{
    [TestFixture]
    public class QuestionManagerTests
    {
        private QuestionManager _manager;
        private string _tempFilePath;

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

        [TearDown]
        public void TearDown()
        {
            if (File.Exists(_tempFilePath))
                File.Delete(_tempFilePath);
        }

        [Test]
        public void LoadQuestions_ValidPath_ShouldPopulateList()
        {
            var categories = _manager.GetCategories();
            Assert.That(categories, Is.Not.Empty);
        }

        [Test]
        public void LoadQuestions_InvalidPath_ShouldThrow()
        {
            Assert.Throws<FileNotFoundException>(() =>
                _manager.LoadQuestions("fisier_inexistent.json"));
        }

        [Test]
        public void GetQuestions_ExistingCategory_ShouldReturnOnlyThatCategory()
        {
            var result = _manager.GetQuestions("Geografie");
            Assert.That(result, Is.Not.Empty);
            Assert.That(result.All(q => q.Category == "Geografie"), Is.True);
        }

        [Test]
        public void GetQuestions_UnknownCategory_ShouldReturnEmpty()
        {
            var result = _manager.GetQuestions("Astronomie");
            Assert.That(result, Is.Empty);
        }

        [Test]
        public void GetCategories_ShouldReturnUniqueValues()
        {
            var categories = _manager.GetCategories();
            Assert.That(categories.Count, Is.EqualTo(categories.Distinct().Count()));
        }
    }
}
