using System;
using System.Collections.Generic;
using System.Text;
using DBManagement;
using NUnit.Framework;

namespace Test
{
    [TestFixture]
    public class QuestionTests
    {
        private Question _question;

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

        [Test]
        public void ValidAttributes_ShouldSetCorrectly()
        {
            Assert.That(_question.Text, Is.EqualTo("Unitatea de măsură pentru forță este?"));
            Assert.That(_question.CorrectAnswer, Is.EqualTo(1));
            Assert.That(_question.Category, Is.EqualTo("Fizica"));
        }

        [Test]
        public void CorrectAnswer_ShouldBeValidIndex()
        {
            Assert.That(_question.CorrectAnswer, Is.GreaterThanOrEqualTo(0));
            Assert.That(_question.CorrectAnswer, Is.LessThan(_question.Options.Length));
        }

        [Test]
        public void Options_ShouldNotBeEmpty()
        {
            Assert.That(_question.Options, Is.Not.Empty);
        }
    }
}
