using System;
using System.Collections.Generic;
using System.Text;
using DBManagement;
using NUnit.Framework;

namespace Test
{
    /// <summary>
    /// Clasa de testare pentru Question, verificând validitatea atributelor și constrângerile acestora
    /// </summary>
    [TestFixture]
    public class QuestionTests
    {
        private Question _question;

        /// <summary>
        /// Initializare a unui obiect Question cu atribute valide pentru testare
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            _question = new Question
            {
                Text = "Unitatea de măsură pentru forță este?",
                Options = new string[] { "Joule", "Newton", "Watt", "Pascal" },
                CorrectAnswer = 1,
                Category = "Fizica"
            };
        }

        /// <summary>
        /// Verificarea atributelor pentru a se asigura că sunt setate corect și corespund valorilor așteptate
        /// </summary>
        [Test]
        public void ValidAttributes_ShouldSetCorrectly()
        {
            Assert.That(_question.Text, Is.EqualTo("Unitatea de măsură pentru forță este?"));
            Assert.That(_question.CorrectAnswer, Is.EqualTo(1));
            Assert.That(_question.Category, Is.EqualTo("Fizica"));
        }

        /// <summary>
        /// Verificarea corectitudinii indexului pentru răspunsul corect, asigurându-se că acesta este un index valid în array-ul de opțiuni
        /// </summary>
        [Test]
        public void CorrectAnswer_ShouldBeValidIndex()
        {
            Assert.That(_question.CorrectAnswer, Is.GreaterThanOrEqualTo(0));
            Assert.That(_question.CorrectAnswer, Is.LessThan(_question.Options.Length));
        }

        /// <summary>
        /// Verificarea că array-ul de opțiuni nu este gol, asigurându-se că există cel puțin o opțiune disponibilă pentru întrebarea dată
        /// </summary>
        [Test]
        public void Options_ShouldNotBeEmpty()
        {
            Assert.That(_question.Options, Is.Not.Empty);
        }
    }
}
