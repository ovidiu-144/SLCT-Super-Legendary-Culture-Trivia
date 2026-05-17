// Proiect:      SLCT – Super Legendary Culture Trivia
// Fișier:       ScoreManagerTests.cs
// Autor:        Turnea David-Catalin
// Echipă:       Alesia, Ioana, Ovidiu, Catalin
// Descriere:    Fisierul contine clasa de testare pentru ScoreManager,
//               verificând funcționalitatea principalelor metode
//               și comportamentul acestora în diferite scenarii


using Logic;
using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Test
{
    /// <summary>
    /// Clasa pentru testarea ScoreManager
    /// </summary>
    [TestFixture]
    public class ScoreManagerTests
    {
        /// <summary>
        /// Verifica daca UpdateScore creste scorul pentru raspunsuri corecte in strategia "Simple"
        /// </summary>
        [Test]
        public void UpdateScore_SimpleStrategy_CorrectAnswer_ShouldIncreaseScore()
        {
            var manager = new ScoreManager("Simple");
            manager.UpdateScore(true);
            Assert.That(manager.TotalScore, Is.GreaterThan(0));
        }

        /// <summary>
        /// Verifica daca UpdateScore nu creste scorul pentru raspunsuri gresite in strategia "Simple"
        /// </summary>
        [Test]
        public void UpdateScore_SimpleStrategy_WrongAnswer_ShouldNotIncreaseScore()
        {
            var manager = new ScoreManager("Simple");
            manager.UpdateScore(false);
            Assert.That(manager.TotalScore, Is.EqualTo(0));
        }

        /// <summary>
        /// Verifica daca Reset seteaza scorul la zero in strategia "Simple"
        /// </summary>
        [Test]
        public void Reset_ShouldSetScoreToZero()
        {
            var manager = new ScoreManager("Simple");
            manager.UpdateScore(true);
            manager.Reset();
            Assert.That(manager.TotalScore, Is.EqualTo(0));
        }

        /// <summary>
        /// Verifica daca UpdateScore scade scorul pentru raspunsuri gresite in strategia "Negative"
        /// </summary>
        [Test]
        public void UpdateScore_NegativeStrategy_WrongAnswer_ShouldDecreaseScore()
        {
            var manager = new ScoreManager("Negative");
            manager.UpdateScore(false);
            Assert.That(manager.TotalScore, Is.LessThan(0));
        }
    }
}
